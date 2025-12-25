using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Enums;
using Web.Models;

namespace Web.Areas.Admin.Controllers;

[Area("Admin")]
public class MenuController(DataContext context) : Controller
{
    private readonly DataContext _context = context;

    public async Task<IActionResult> Index()
    {
        return View(await _context.Menus.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var menu = await _context.Menus
            .FirstOrDefaultAsync(m => m.Id == id);
        if (menu == null)
        {
            return NotFound();
        }

        return View(menu);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Menu menu)
    {
        if (ModelState.IsValid)
        {
            _context.Add(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(menu);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var menu = await _context.Menus.FindAsync(id);
        if (menu == null)
        {
            return NotFound();
        }
        return View(menu);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Menu menu)
    {
        if (id != menu.Id) return NotFound();
        if (!ModelState.IsValid) return View(menu);

        try
        {
            _context.Update(menu);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Menus.AnyAsync(e => e.Id == id))
                return NotFound();

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var menu = await _context.Menus
            .FirstOrDefaultAsync(m => m.Id == id);
        if (menu == null)
        {
            return NotFound();
        }

        return View(menu);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var menu = await _context.Menus.FindAsync(id);
        if (menu != null)
        {
            _context.Menus.Remove(menu);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public static async Task LoadMenus(DataContext context, ViewDataDictionary viewData)
    {
        viewData["TopMenus"] = await context.Menus
            .Where(m => m.Type == MenuType.Top)
            .OrderBy(m => m.Id)
            .ToListAsync();

        viewData["BottomMenus"] = await context.Menus
            .Where(m => m.Type == MenuType.Bottom)
            .OrderBy(m => m.Id)
            .ToListAsync();

        viewData["SubMenus"] = await context.Menus
            .Where(m => m.Type == MenuType.Sub)
            .OrderBy(m => m.Id)
            .ToListAsync();

        viewData["AccountMenus"] = await context.Menus
            .Where(m => m.Type == MenuType.Account)
            .OrderBy(m => m.Id)
            .ToListAsync();
    }
}

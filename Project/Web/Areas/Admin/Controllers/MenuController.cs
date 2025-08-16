using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Areas.Admin.Controllers;

[Area("Admin")]
public class MenuController : Controller
{
    private readonly DataContext _context;

    public MenuController(DataContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Menus.ToListAsync());
    }

    public async Task<IActionResult> Details(int? menuId)
    {
        if (menuId == null)
        {
            return NotFound();
        }

        var menu = await _context.Menus
            .FirstOrDefaultAsync(m => m.Id == menuId);

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
            await _context.AddAsync(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(menu);
    }

    public async Task<IActionResult> Edit(int? menuId)
    {
        if (menuId == null)
        {
            return NotFound();
        }

        var menu = await _context.Menus.FindAsync(menuId);

        if (menu == null)
        {
            return NotFound();
        }

        return View(menu);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int menuId, Menu menu)
    {
        if (menuId != menu.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(menu);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(menu.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        return View(menu);
    }

    public async Task<IActionResult> Delete(int? menuId)
    {
        if (menuId == null)
        {
            return NotFound();
        }

        var menu = await _context.Menus
            .FirstOrDefaultAsync(m => m.Id == menuId);

        if (menu == null)
        {
            return NotFound();
        }

        return View(menu);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int menuId)
    {
        var menu = await _context.Menus.FindAsync(menuId);
        if (menu != null)
        {
            _context.Menus.Remove(menu);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MenuExists(int menuId)
    {
        return _context.Menus.Any(e => e.Id == menuId);
    }
}

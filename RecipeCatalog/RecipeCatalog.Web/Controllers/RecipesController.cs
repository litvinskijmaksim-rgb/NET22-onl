using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeCatalog.Data.Context;
using RecipeCatalog.Data.Entities;

namespace RecipeCatalog.Web.Controllers
{
    public class RecipesController : Controller
    {
        private readonly AppDbContext _context;

        public RecipesController(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var recipes = await _context.Recipes
                .Include(r => r.Category)
                .ToListAsync();
            return View(recipes);
        }

        
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Instructions,CookingTimeMinutes,CategoryId")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                // Помечаем рецепт как созданный пользователем
                recipe.IsUserCreated = true;
                recipe.AverageRating = 0; // начальный рейтинг

                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            return View(recipe);
        }

        public async Task<IActionResult> TopRated()
        {
            var topRecipes = await _context.Recipes
                .Include(r => r.Category)
                .Where(r => r.AverageRating >= 4.8)
                .OrderByDescending(r => r.AverageRating)
                .ToListAsync();

            ViewBag.Title = "Лучшие рецепты (рейтинг 4.8+)";
            return View("Index", topRecipes);
        }
        public async Task<IActionResult> Favorites()
        {
           
            var allRecipes = await _context.Recipes
                .Include(r => r.Category)
                .ToListAsync();

            ViewBag.Title = "Избранные рецепты";
            return View("Index", allRecipes);

        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }
        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name", recipe.CategoryId);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Instructions,CookingTimeMinutes,CategoryId,AverageRating,IsUserCreated")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
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

            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name", recipe.CategoryId);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
        
        public async Task<IActionResult> MyRecipes()
        {
            var myRecipes = await _context.Recipes
                .Include(r => r.Category)
                .Where(r => r.IsUserCreated == true)
                .OrderByDescending(r => r.Id)
                .ToListAsync();

            ViewBag.Title = "Мои рецепты";
            return View("Index", myRecipes);
        }
    }
}
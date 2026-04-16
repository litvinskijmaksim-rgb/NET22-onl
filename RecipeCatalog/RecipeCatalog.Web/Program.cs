using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeCatalog.Data.Context;
using RecipeCatalog.Data.Entities;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 3;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    
    dbContext.Database.EnsureCreated();

    if (!dbContext.Categories.Any())
    {
        var categories = new List<Category>
        {
            new Category { Name = "Пицца", Description = "Итальянская пицца" },
            new Category { Name = "Паста", Description = "Макаронные изделия" },
            new Category { Name = "Мясные блюда", Description = "Блюда из мяса" },
            new Category { Name = "Салаты", Description = "Свежие салаты" },
            new Category { Name = "Азиатская кухня", Description = "Блюда Азии" },
            new Category { Name = "Супы", Description = "Первые блюда" },
            new Category { Name = "Десерты", Description = "Сладкие блюда" },
            new Category { Name = "Выпечка", Description = "Мучные изделия" },
            new Category { Name = "Морепродукты", Description = "Блюда из рыбы и морепродуктов" },
            new Category { Name = "Напитки", Description = "Напитки и коктейли" }
        };
        dbContext.Categories.AddRange(categories);
        dbContext.SaveChanges();
        Console.WriteLine("Категории добавлены");
    }

    
    if (!dbContext.Recipes.Any())
    {
       
        var pizzaCat = dbContext.Categories.First(c => c.Name == "Пицца").Id;
        var pastaCat = dbContext.Categories.First(c => c.Name == "Паста").Id;
        var meatCat = dbContext.Categories.First(c => c.Name == "Мясные блюда").Id;
        var saladCat = dbContext.Categories.First(c => c.Name == "Салаты").Id;
        var asianCat = dbContext.Categories.First(c => c.Name == "Азиатская кухня").Id;
        var soupCat = dbContext.Categories.First(c => c.Name == "Супы").Id;
        var dessertCat = dbContext.Categories.First(c => c.Name == "Десерты").Id;
        var bakeryCat = dbContext.Categories.First(c => c.Name == "Выпечка").Id;
        var seafoodCat = dbContext.Categories.First(c => c.Name == "Морепродукты").Id;
        var drinksCat = dbContext.Categories.First(c => c.Name == "Напитки").Id;

        var recipes = new List<Recipe>
        {
            // 1-10 рецепты
            new Recipe { Title = "Пицца Маргарита", Description = "Классическая итальянская пицца", Instructions = "Замесить тесто, добавить соус и сыр, выпекать", CookingTimeMinutes = 30, CategoryId = pizzaCat, AverageRating = 4.9 },
            new Recipe { Title = "Спагетти Карбонара", Description = "Нежная паста с беконом", Instructions = "Отварить спагетти, смешать с яйцом и сыром", CookingTimeMinutes = 20, CategoryId = pastaCat, AverageRating = 4.8 },
            new Recipe { Title = "Стейк Рибай", Description = "Сочный мраморный стейк", Instructions = "Обжарить на сковороде по 3 минуты с каждой стороны", CookingTimeMinutes = 25, CategoryId = meatCat, AverageRating = 4.9 },
            new Recipe { Title = "Салат Цезарь", Description = "С курицей и пармезаном", Instructions = "Нарезать салат, добавить курицу и соус", CookingTimeMinutes = 15, CategoryId = saladCat, AverageRating = 4.7 },
            new Recipe { Title = "Японский Рамен", Description = "Наваристый суп с лапшой", Instructions = "Варить бульон 12 часов, добавить лапшу", CookingTimeMinutes = 60, CategoryId = asianCat, AverageRating = 4.9 },
            new Recipe { Title = "Севиче", Description = "Рыба в соке лайма", Instructions = "Нарезать рыбу, замариновать", CookingTimeMinutes = 15, CategoryId = saladCat, AverageRating = 4.6 },
            new Recipe { Title = "Тако", Description = "Мексиканские лепешки с мясом", Instructions = "Потушить мясо, подавать в тортилье", CookingTimeMinutes = 30, CategoryId = meatCat, AverageRating = 4.8 },
            new Recipe { Title = "Пад Тай", Description = "Лапша с креветками", Instructions = "Обжарить лапшу с креветками", CookingTimeMinutes = 25, CategoryId = asianCat, AverageRating = 4.8 },
            new Recipe { Title = "Борщ", Description = "Красный борщ со сметаной", Instructions = "Сварить бульон, добавить свеклу и капусту", CookingTimeMinutes = 90, CategoryId = soupCat, AverageRating = 4.9 },
            new Recipe { Title = "Тирамису", Description = "Кофейный десерт", Instructions = "Слои печенья в кофе и крема маскарпоне", CookingTimeMinutes = 40, CategoryId = dessertCat, AverageRating = 5.0 },
            
            
            new Recipe { Title = "Киш Лорен", Description = "Французский открытый пирог с беконом", Instructions = "Раскатать тесто, выложить бекон, залить заливкой, выпекать", CookingTimeMinutes = 50, CategoryId = bakeryCat, AverageRating = 4.7 },
            new Recipe { Title = "Мусака", Description = "Греческая запеканка с баклажанами", Instructions = "Обжарить баклажаны и фарш, выложить слоями, запекать", CookingTimeMinutes = 90, CategoryId = meatCat, AverageRating = 4.8 },
            new Recipe { Title = "Курица Тикка Масала", Description = "Пряная курица в сливочном соусе", Instructions = "Замариновать курицу, обжарить, тушить в соусе", CookingTimeMinutes = 60, CategoryId = asianCat, AverageRating = 4.9 },
            new Recipe { Title = "Паэлья", Description = "Рис с морепродуктами и курицей", Instructions = "Обжарить курицу и морепродукты, добавить рис и бульон", CookingTimeMinutes = 60, CategoryId = seafoodCat, AverageRating = 4.8 },
            new Recipe { Title = "Чизкейк Нью-Йорк", Description = "Классический американский чизкейк", Instructions = "Смешать сыр, яйца, сливки, выпекать на водяной бане", CookingTimeMinutes = 90, CategoryId = dessertCat, AverageRating = 5.0 },
            new Recipe { Title = "Донер Кебаб", Description = "Турецкое мясо с овощами", Instructions = "Замариновать мясо, обжарить, подавать в лаваше", CookingTimeMinutes = 45, CategoryId = meatCat, AverageRating = 4.7 },
            new Recipe { Title = "Кимчи Чиге", Description = "Острый корейский суп с кимчи", Instructions = "Обжарить свинину, добавить кимчи, тофу и варить", CookingTimeMinutes = 30, CategoryId = soupCat, AverageRating = 4.6 },
            new Recipe { Title = "Куриный Тажин", Description = "Марокканское блюдо с курагой", Instructions = "Обжарить курицу со специями, добавить курагу, тушить", CookingTimeMinutes = 75, CategoryId = meatCat, AverageRating = 4.8 },
            new Recipe { Title = "Фо Бо", Description = "Вьетнамский суп с лапшой и говядиной", Instructions = "Варить бульон, добавить лапшу и тонко нарезанную говядину", CookingTimeMinutes = 45, CategoryId = soupCat, AverageRating = 4.9 },
            new Recipe { Title = "Фейжоада", Description = "Бразильское блюдо из фасоли и свинины", Instructions = "Замочить фасоль, тушить с разными видами свинины", CookingTimeMinutes = 120, CategoryId = meatCat, AverageRating = 4.7 },
            new Recipe { Title = "Хумус", Description = "Ливанская закуска из нута", Instructions = "Смешать нут с тахини, лимоном и чесноком", CookingTimeMinutes = 15, CategoryId = saladCat, AverageRating = 4.5 },
            new Recipe { Title = "Венский Шницель", Description = "Австрийская отбивная в панировке", Instructions = "Отбить мясо, обвалять в сухарях, обжарить", CookingTimeMinutes = 25, CategoryId = meatCat, AverageRating = 4.6 },
            new Recipe { Title = "Боба Чай", Description = "Тайваньский напиток с шариками тапиоки", Instructions = "Сварить тапиоку, заварить чай, добавить молоко", CookingTimeMinutes = 20, CategoryId = drinksCat, AverageRating = 4.5 },
            new Recipe { Title = "Мясо с Чимичурри", Description = "Аргентинский стейк с зеленым соусом", Instructions = "Обжарить стейк, смешать петрушку с чесноком и маслом", CookingTimeMinutes = 30, CategoryId = meatCat, AverageRating = 4.8 },
            new Recipe { Title = "Яблочный Штрудель", Description = "Австрийский десерт из слоеного теста", Instructions = "Раскатать тесто, выложить яблоки, свернуть рулетом, выпекать", CookingTimeMinutes = 60, CategoryId = dessertCat, AverageRating = 4.9 }
        };

        dbContext.Recipes.AddRange(recipes);
        dbContext.SaveChanges();
        Console.WriteLine($"Добавлено {recipes.Count} рецептов!");
    }
}


app.Run();
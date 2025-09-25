using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PedidosMVC.Data;
using PedidosMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuración del DbContext con el nombre correcto:
builder.Services.AddDbContext<PedidosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PedidosDb")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PedidosDbContext>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = { "admin", "cliente", "empleado" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var user = await userManager.FindByEmailAsync("admin@correo.com");
    if (user == null)
    {
        user = new ApplicationUser
        {
            UserName = "admin@correo.com",
            Email = "admin@correo.com",
            EmailConfirmed = true
        };
        var result = await userManager.CreateAsync(user, "Admin123");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "admin");
        }
        
    }
    else
    {
        await userManager.AddToRoleAsync(user, "admin");
    }
}

app.Run();

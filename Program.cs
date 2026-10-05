var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddOpenApi();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();
app.MapStaticAssets();
app.MapControllerRoute(name: "default",
 pattern:"{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(name: "Categories",
 pattern:"{controller=Categories}/{action=Index}/{id?}"
);
// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();





app.Run();



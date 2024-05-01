using Microsoft.EntityFrameworkCore;
using UserImage.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// added exception filter: helps to detect and diagnose errors with EFCore migrations
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// end

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// added exception filter: helps to detect and diagnose errors with EFCore migrations
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
// end
// added | 'EnsureCreated' method takes no action if a database for the context exists. If no database exists, it creates the database and schema.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<UserContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context); //for seed(seed occurs once we run this code i.e, run the program)
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

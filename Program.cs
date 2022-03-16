using Microsoft.EntityFrameworkCore;
using portfolio_backend.EmailService;
using portfolio_backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(config=>
    config.UseNpgsql("User ID=orhan;Password=12345;Server=localhost;Port=5432;Database=portfolio;Integrated Security=true;Pooling=true;"));
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var EmailConfig=builder.Configuration.GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();
builder.Services.AddSingleton(EmailConfig);
builder.Services.AddScoped<IEmailSender,EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

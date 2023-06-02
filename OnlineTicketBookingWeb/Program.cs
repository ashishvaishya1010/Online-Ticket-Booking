using OnlineTicketBooking.Repository.IRepository;
using OnlineTicketBooking.Repository;
using OnlineTicketBookingWeb.Services.IServices;
using OnlineTicketBookingWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IEventService, EventService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddHttpClient<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddHttpClient<IUserService, UserService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllersWithViews();

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

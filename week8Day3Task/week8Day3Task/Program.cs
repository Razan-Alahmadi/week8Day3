using week8Day3Task.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



// ------  redis Cache  and IMemoryCache  ------
// add redis connection
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379"; // as port show up in redis-cli
});

// Register IMemoryCache
builder.Services.AddMemoryCache();

//--------------------------------------------------------

// Register services
builder.Services.AddScoped<RedisService>();
builder.Services.AddScoped<InMemoryService>();
//--------------------------------------------------------


// Add HttpClient service for making API calls
builder.Services.AddHttpClient();

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=604800"); // 7 days
    }
});


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

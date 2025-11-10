using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

/*روال اجرایی سایت از اینجا مدیریت میشه و مرحله به مرحله انجام میشه اینا به میدل ور هستن*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDBcontext>(options =>
{
    options.UseSqlServer(
        // حج اقا این نقطه ای که جلو دیتا سورس گذاشتیم میگیم حجیه دیتا بیس همینجاس نترس
        connectionString: "Data source = .;"+
        "Initial Catalog=MyWeb_Db;" +
        "TrustServerCertificate=True;" +
        "Trusted_Connection = True;"
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
/*مسیر دهی سایت ما و برنامه اینجا مدیریت میشه  یعنی ادرس دهی سایت ما به چه شکلی باشد 
 اینحا الان اینطوریه که باید اسم کنتورل را اول بیاریم بعد اکشن مون که ایندکسه  
الان همه چی از هوم مدیریت میشه  که اینجا به صورت پیشفرض کنترولر هوم هست و اکشن هم ایندکس
*/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "blog",
    pattern: "{controller=Blog}/{id?}",
    defaults: new {Controller = "Blog" , action = ""})
    .WithStaticAssets();

app.Run();

using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Subasi.CustomerMS.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            //builder.Services.AddRazorPages().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            builder.Services.AddHttpClient();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(
                JwtBearerDefaults.AuthenticationScheme, opt =>
                {
                    opt.LoginPath = "/Account/Login";
                    opt.LogoutPath = "/Account/Logout";   
                    opt.AccessDeniedPath = "/Account/AccessDenied";
                    opt.Cookie.SameSite = SameSiteMode.Strict;
                   // opt.Cookie.HttpOnly = true;
                    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                    opt.Cookie.Name = "SubasiCustomerMS";
                });

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers(); // enables controllers in endpoint routing
                endpoints.MapDefaultControllerRoute(); // adds the default route {controller=Home}/{action=Index}/{id?}
            });

            app.Run();
        }
    }
}

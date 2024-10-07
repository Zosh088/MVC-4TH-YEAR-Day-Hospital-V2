using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Surgeon__Day_Hospital_.Data;
using System.Configuration;
using System.Data;
// these are the repositories we use in the project..
using Surgeon__Day_Hospital_.DapperLibrary.Repositories.AddressRepo;
using Surgeon__Day_Hospital_.DapperLibrary.Repositories.PatientRepo;
using Surgeon__Day_Hospital_.DapperLibrary.Repositories.SuburbRepo;
using Surgeon__Day_Hospital_.DapperLibrary.Repositories.VitalRepo;
using Surgeon__Day_Hospital_.DapperLibrary.Repositories.AdmissionRepo;
using Surgeon__Day_Hospital_.DapperLibrary.Repositories.DischargeRepo;
using Surgeon__Day_Hospital_.DapperLibrary.Repositories.ScriptRepo;
using Surgeon__Day_Hospital_.DapperLibrary.Repositories.ThreatreBookingRepo;
using Surgeon__Day_Hospital_.Models;
//using Surgeon__Day_Hospital_.DapperLibrary.Repositories.PatientRepo.PatientRepo;

namespace Surgeon__Day_Hospital_
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            // Registering the Repositories
            //builder.Services.AddTransient<IAddressRepo, AddressRepo>();
            //builder.Services.AddTransient<IPatientRepository, PatientRepo>();
            builder.Services.AddScoped<AddressRepo>();
            builder.Services.AddScoped<PatientRepo>();
            builder.Services.AddScoped<SubRepo>();
            builder.Services.AddScoped<VitalRepo>();
            builder.Services.AddScoped<AdmissionRepo>();
            builder.Services.AddScoped<DischargeRepo>();
            builder.Services.AddScoped<ScriptRecordRepo>();
            builder.Services.AddScoped<BookingRepo>();
            builder.Services.AddScoped<User>();
            builder.Services.AddTransient<IDbConnection>(options => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            //// Register the UserManager service
            //builder.Services.AddScoped(provider => provider.GetService<UserManager<IdentityUser>>());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();




            // Seed data..
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Nurse", "Surgeon", "Pharmacist", "Admin" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var UserManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                var users = new User[]
                {
                    // This are our Admins
                    new User{ Email = "admin@gmail.com", Password = "Password123!", Role = "Admin", ContactNo = "0817715570", HCRNo = "474521", Name = "Zenande",Surname="Mjali" },

                    // These are our Surgeons
                    new User{ Email = "charmaine@gmail.com", Password = "Password123!", Role = "Surgeon", ContactNo = "0712345678", HCRNo = "976431", Name = "Charmaine",Surname="Meintjies"  },
                    new User { Email = "nicky.mostert@nmmu.ac.za", Password = "Password123!", Role = "Surgeon", ContactNo = "0722345678", HCRNo = "316497", Name = "Jacobs",Surname="Moloi" },
                    new User { Email = "david@gmail.com", Password = "Password123!", Role = "Surgeon", ContactNo = "0732345678", HCRNo = "718293", Name = "David",Surname="Greeff" },

                    //These are our Pharmacists
                    new User { Email = "dorothy@gmail.com", Password = "Password123!", Role = "Pharmacist", ContactNo = "0612345678", HCRNo = "123456", Name = "Dorothy",Surname="Daniels" },
                    new User { Email = "lindile@gmail.com", Password = "Password123!", Role = "Pharmacist", ContactNo = "0622345678", HCRNo = "234567", Name = "Lindile",Surname="Hadebe" },
                    new User { Email = "marcel@gmail.com", Password = "Password123!", Role = "Pharmacist", ContactNo = "0632345678", HCRNo = "345678", Name = "Marcel",Surname="Van Niekerk" },

                    //These are our Nurses
                    new User    { Email = "nicky.mostert@mandela.ac.za", Password = "Password123!", Role = "Nurse" , ContactNo = "0642345678", HCRNo = "987654", Name = "Vanessa",Surname="Meintjies"},
                    new User { Email = "lesedi@gmail.com", Password = "Password123!", Role = "Nurse", ContactNo = "0652345678", HCRNo = "765432", Name = "Lesedi",Surname="Moloi" },
                    new User { Email = "thabo@gmail.com", Password = "Password123!", Role = "Nurse", ContactNo = "0662345678", HCRNo = "654321", Name = "Thabo",Surname="Moloi" }
                };

                foreach (var userInfo in users)
                {
                    if (await UserManager.FindByEmailAsync(userInfo.Email) == null)
                    {
                        var user = new User()
                        {
                            UserName = userInfo.Email,
                            Email = userInfo.Email,
                            Password = userInfo.Password,
                            Role = userInfo.Role,
                            ContactNo = userInfo.ContactNo,
                            HCRNo = userInfo.HCRNo,
                            Name = userInfo.Name,
                            Surname = userInfo.Surname,


                        };


                        await UserManager.CreateAsync(user, userInfo.Password);

                        await UserManager.AddToRoleAsync(user, userInfo.Role);
                    }

                }


            }

            app.Run();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
                options.Cookie.HttpOnly = true; // Prevents JavaScript from accessing session cookies
                options.Cookie.IsEssential = true; // Required for session cookies
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession(); // Enable session

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

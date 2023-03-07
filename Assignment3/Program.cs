using Assignment3.Data;
using Assignment3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tweetinvi;
using VaderSharp2;

namespace Assignment3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var userClient = new TwitterClient("AAx9UfdCemph0Pg0t8Moq5c6L", "LbhoERpFGjBESYSNjTHuRvE0R80cGxZBx5lJWanM5lFpO2Hs63", "1455230009153503238-WTxQgoYUAQ3D9PTSsUu8stHkmJvuVe", "2ZVnM9tWbCSNAhyJcyC4WPIgiIbUWZ77MTLSx2Qb8TkW3");
            //var searchResponse = await userClient.SearchV2.SearchTweetsAsync("hello");
            //var tweets = searchResponse.Tweets;
            //var analyzer = new SentimentIntensityAnalyzer();
            //double tweetAverage = 0;
            //for (int i = 0;i < tweets.Length; i++)
            //{
            //    Console.WriteLine(tweets[i].Text);
                //var results = analyzer.PolarityScores(tweets[i].Text);

                //Console.WriteLine("Compound score: " + results.Compound);
                //tweetAverage+= results.Compound;
            //}

            //Console.WriteLine("Average compound score: " + tweetTotal / tweets.Lengths);

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();

            //MovieTweetsVM movieVM = new MovieTweetsVM();
            //movieVM.CompoundSentiment();
        }


    }
}
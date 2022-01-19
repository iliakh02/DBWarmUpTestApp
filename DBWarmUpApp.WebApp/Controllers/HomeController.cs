using DBWarmUpApp.Domain;
using DBWarmUpApp.Domain.Entities;
using DBWarmUpApp.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DBWarmUpApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IBlogRepository repository;

        public HomeController(ILogger<HomeController> logger, IBlogRepository repo)
        {
            this.repository = repo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> PrivacyAsync()
        {
            // ExecuteWarmup();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            //for (var i = 0; i < 6; i++)
            {
                //LogMessageCollector.RunNumber = i;
                repository.Blogs();
            }
            stopwatch.Stop();
            Console.WriteLine("First query:" + stopwatch.ElapsedMilliseconds);
            //LogMessageCollector.CollateResults();

            //var resultFormat = "{0,-70} {1,5:N1} {2,5:N1} {3,5:N1} {4,5:N1} {5,5:N1} {6,5:N1}";
            //Console.WriteLine(resultFormat, "Event", "Run1", "Run2", "Run3", "Run4", "Run5", "Run6");
            //foreach (var result in LogMessageCollector.Results)
            //{
            //    Console.WriteLine(string.Format(resultFormat, result.EventName, result.ElapsedTimes[0], result.ElapsedTimes[1], result.ElapsedTimes[2], result.ElapsedTimes[3], result.ElapsedTimes[4], result.ElapsedTimes[5]));
            //}
            //Console.WriteLine(string.Format(resultFormat, "Totals", LogMessageCollector.Results.Sum(x => x.ElapsedTimes[0]), LogMessageCollector.Results.Sum(x => x.ElapsedTimes[1]), LogMessageCollector.Results.Sum(x => x.ElapsedTimes[2]), LogMessageCollector.Results.Sum(x => x.ElapsedTimes[3]), LogMessageCollector.Results.Sum(x => x.ElapsedTimes[4]), LogMessageCollector.Results.Sum(x => x.ElapsedTimes[5])));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void ExecuteWarmup()
        {
            // Seen here: https://github.com/dotnet/efcore/issues/15568
            _ = repository.Blogs();
        }

    }
}
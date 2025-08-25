
using _6letterword.Business;
using _6letterword.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program {
  private static void Main(string[] args) {
    // Register DI. Would usually be somewhere else
    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddScoped<IStringCombinationFinder, StringCombinationFinder>();
        builder.Services.AddScoped<IStringCombinationFinderTdd, IStringCombinationFinderTdd>();
    using IHost host = builder.Build();

    var allTextEntries = File.ReadAllText("input.txt").Split("\n").ToList();

    Console.WriteLine($"Input file read. Words found: {allTextEntries.Count()}");

    var startTime = DateTimeOffset.UtcNow.Ticks;

    var finder = host.Services.GetRequiredService<IStringCombinationFinder>();
    var allCombinations = finder.FindCombinations(allTextEntries);

    var endTime = DateTimeOffset.UtcNow.Ticks;
    var totalTimeSpent = TimeSpan.FromTicks(endTime - startTime);

    Console.WriteLine($"Found {allCombinations.Count()} combinations in {totalTimeSpent.TotalSeconds} seconds.");
    foreach (var item in allCombinations) {
      Console.WriteLine(item.ToString());
    }
    Console.WriteLine("Press enter to exit.");
    Console.ReadLine();
  }
}
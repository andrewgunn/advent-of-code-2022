using System.Reflection;
using AdventOfCode;

var dayTypes = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(type => typeof(IDay).IsAssignableFrom(type))
    .Where(type => !type.IsAbstract)
    .Where(type => !type.IsInterface);

foreach (var dayType in dayTypes.OrderBy(day => day.Name))
{
    var day = (IDay)Activator.CreateInstance(dayType);
    
    Console.WriteLine(day.GetType().Name);
    
    day.Part1();
    day.Part2();

    Console.WriteLine();
}

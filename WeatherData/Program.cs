using System.Text;

const string file = @"weather.dat";
if (File.Exists(file))
{
    var dayNumber = string.Empty;
    var minSpan = 1000;
    var weatherData = File.ReadLines(file, Encoding.UTF8);
    foreach (var line in weatherData.Skip(2).Take(30))
    {
        var lineArr = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var tempSpan = int.Parse(lineArr[1][..2]) - int.Parse(lineArr[2][..2]);
        if (tempSpan < minSpan)
        {
            minSpan = tempSpan;
            dayNumber = lineArr[0];
        }
    }
    Console.WriteLine($"The day with the minimum span is day {dayNumber}");
}
else
{
    Console.WriteLine("File doesn't exist.");
}
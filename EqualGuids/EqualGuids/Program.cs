using System.Diagnostics;

var guid1 = Guid.NewGuid();
var guid2 = Guid.NewGuid();
long counter = 0;

Console.WriteLine("First guid: " + guid1);

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

Console.ForegroundColor = ConsoleColor.Green;

while (!guid1.Equals(guid2))
{
    guid2 = Guid.NewGuid();
    Console.WriteLine(guid2);
    counter++;
    Console.SetCursorPosition(0, Console.CursorTop - 1);
}

stopwatch.Stop();

TimeSpan ts = stopwatch.Elapsed;
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Second equal guid: " + guid2);

Console.WriteLine("Searching time: " + elapsedTime);

Console.WriteLine("Number of attempts: " + counter);

using KTPO.Gatin.Lib.LogAn;

class Program
{
    static void Main()
    {
        var analyzer = new LogAnalyzer();

        Console.WriteLine(analyzer.IsValidLogFileName("file.Gatin")); // true
        Console.WriteLine(analyzer.IsValidLogFileName("file.txt"));    // false
    }
}
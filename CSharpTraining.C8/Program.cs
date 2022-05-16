// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8

using CSharpTraining.C8.Constants;
using CSharpTraining.C8.Models;

#region readonly-members
var point = new Point()
{
    X = 1,
    Y = 2
};
Console.WriteLine(point.ToString());
Console.WriteLine(point.Name);
#endregion


#region switch-expressions
static string GetRainbowName(Rainbow rainbow) => rainbow switch
{
    Rainbow.Orange => "Orange",
    Rainbow.Red => "Red",
    _ => rainbow.ToString()
};
Console.WriteLine(GetRainbowName(Rainbow.Red));
#endregion


#region property-patterns
static decimal ComputeSalesTax(Address address, decimal salePrice) => address switch
{
    { Name: "C" } => salePrice * 1,
    { State: "S" } => salePrice * 2,
    { Name: "E", State: "D" } => salePrice * 1,
    _ => salePrice * 0,
};
Console.WriteLine(ComputeSalesTax(new Address() { Name = "E", State = "D" }, 12));
#endregion


#region tuple-patterns
static string RockPaperScissors(string first, string second) => (first, second) switch
{
    ("paper", "rock") => "Paper win.",
    _ => "Try again please"
};
Console.WriteLine(RockPaperScissors("paper", "rock"));
#endregion


#region positional-patterns
static Quadrant GetQuadrant(Point point) => point switch
{
    (1d, 1d) => Quadrant.OnBorder,
    _ => Quadrant.Unknown
};
Console.WriteLine(GetQuadrant(new Point("Ali", 1d, 1d)));
#endregion


#region using-declarations
static string GetFile()
{
    using var file = new StreamReader(@"C:\Windows\iis.log");
    return file.ReadToEnd();
}
Console.WriteLine(GetFile());
#endregion


#region static-local-functions
static void WriteText()
{
    Console.WriteLine("Completed");
}
WriteText();
#endregion


#region asynchronous-streams
static async IAsyncEnumerable<int> WriteNumberAsync()
{
    for (int i = 0; i < 6; i++)
    {
        await Task.Delay(1);
        yield return i;
    }
}

await foreach (var i in WriteNumberAsync())
{
    Console.WriteLine(i.ToString());
}
#endregion


#region indices-and-ranges
var words = new string[]
{
                // index from start    index from end
    "The",      // 0                   ^9
    "quick",    // 1                   ^8
    "brown",    // 2                   ^7
    "fox",      // 3                   ^6
    "jumped",   // 4                   ^5
    "over",     // 5                   ^4
    "the",      // 6                   ^3
    "lazy",     // 7                   ^2
    "dog"       // 8                   ^1
};              // 9 (or words.Length) ^0

Console.WriteLine($"The last word is {words[^1]}"); // writes "dog"

var quickBrownFox = words[1..4]; // quick, brown, fox
var lazyDog = words[^2..^0]; // lazy, dog
var allWords = words[..]; // contains "The" through "dog".
var firstPhrase = words[..4]; // contains "The" through "fox"
var lastPhrase = words[6..]; // contains "the", "lazy" and "dog"

Range phrase = 1..4;
var quickBrownFox2 = words[phrase];
var quickBrownFox3 = words[new Range(1, 4)];
#endregion


#region null-coalescing-assignment
List<int>? numbers = null;
int? index = null;

numbers ??= new List<int>();
numbers.Add(index ??= 17);
numbers.Add(index ??= 20);

Console.WriteLine(string.Join(" ", numbers));  // output: 17 17
Console.WriteLine(index);  // output: 17
Console.WriteLine();
#endregion


#region unmanaged-constructed-types
unsafe static void DisplaySize<T>() where T : unmanaged
{
    Console.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes");
    // enhancement-of-interpolated-verbatim-strings
}

DisplaySize<Coordinate<int>>();
DisplaySize<Coordinate<double>>();
#endregion


#region stackalloc-in-nested-expressions
unsafe static void StackAllocTest()
{
    Span<int> numbers = stackalloc[] { 1, 2, 3, 4, 5, 6 };
    var ind = numbers.IndexOfAny(stackalloc[] { 2, 4, 6, 8 });
    Console.WriteLine(ind);  // output: 1
}
StackAllocTest();
#endregion

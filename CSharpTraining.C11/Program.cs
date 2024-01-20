// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-11
using CSharpTraining.C11.Models;

#region generic-attributes
[Generic<string>]
static string Method() => default!;

[Generic<ValueTuple<int, int>>]
static string Method2() => default!;
#endregion

#region numeric-intptr-and-uintptr
int number1 = 12131;
int number2 = Int32.Parse("123");
uint number3 = 2385723852;

long number4 = 721682146124124124;
ulong number6 = 4127498172481241;

IntPtr pointer1 = IntPtr.Parse("1241241");
nint pointer2 = IntPtr.Zero;
#endregion

#region newlines-in-string-interpolations
string userName = "Can";
double point = 12.4;
string message = $"Hello {userName}, your point is {point} and your level is {point switch
{
    > 90 => "Excellant!",
    > 80 => "Perfect",
    > 70 => "Good",
    > 50 => "Not Bad",
    _ => "Bad",
}}";
#endregion

#region list-patterns
int[] numbers = new int[] { 1, 2, 3, 4, 5 };

if (numbers is [1, 2, 3, 4, 5]) { Console.WriteLine("True"); }
if (numbers is not [1, 2, 3, 4, 5, 6]) { Console.WriteLine("False"); }
if (numbers is [0 or 1, <= 2, >= 3, 4 or >= 4, 5 or <= 5 or <= 6 or >= 4]) { Console.WriteLine("True"); }

string[] texts = new string[] { "Jhon", "Jack", "Jimmy" };

if (texts is ["Jhon", "Jack", "Jimmy"]) { Console.WriteLine("True"); }
if (texts is not ["Jack", "Jimmy"]) { Console.WriteLine("False"); }
#endregion

#region raw-string-literals
string htmlTemplate = """
    <html>
        <div class="body">
            This is a long message.
            It has several lines.
                Some are indented
                        more than others.
            Some should start at the first column.
            Some have "quoted text" in them.
        </div>
    </html>
    """;
Console.WriteLine(htmlTemplate);

var location = $$"""
   Hello {{userName}}, your point {{point}}
   """;
Console.WriteLine(location);
#endregion
// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

#region global-using-directives
/* https://docs.microsoft.com/en-us/dotnet/core/project-sdk/msbuild-props#using
 * 
 * Included below block in .csproj file
 * 
 * <ItemGroup>
      <Using Include="CSharpTraining.C10.Models"/>
    </ItemGroup>
 */
#endregion


#region improvements-of-structure-types
var m1 = new Measurement();
Console.WriteLine(m1);  // output: NaN (Undefined)

var m2 = default(Measurement);
Console.WriteLine(m2);  // output: 0 ()

var ms = new Measurement[2];
Console.WriteLine(string.Join(", ", ms));  // output: 0 (), 0 ()
#endregion


#region extended-property-patterns
static bool IsConferenceDay(DateTime date) => date is { Year: 2020, Month: 5, Day: 19 or 20 or 21 };

Console.WriteLine(IsConferenceDay(new DateTime(2020, 5, 19)));
Console.WriteLine(IsConferenceDay(new DateTime(2020, 5, 20)));
Console.WriteLine(IsConferenceDay(new DateTime(2020, 5, 25)));
#endregion


#region lambda-expression-improvements
Func<int, int> square = x => x * x;
Console.WriteLine(square(5));

Expression<Func<int, int>> e = x => x * x;
Console.WriteLine(e);
#endregion


#region constant-interpolated-strings
const string Language = "C#";
const string Platform = ".NET";
const string Version = "10.0";
const string FullProductName = $"{Platform} - Language: {Language} Version: {Version}";
#endregion

#region callerargumentexpression-attribute-diagnostics
static void Validate(object condition, [CallerArgumentExpression("condition")] string? message = null)
{
    if (message != null)
    {
        Console.WriteLine($"Argument failed validation: <{message}>");
    }
}
Validate(new { test = "qwer" });
#endregion
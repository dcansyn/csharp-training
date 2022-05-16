// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9

using CSharpTraining.C9.Models;
using Newtonsoft.Json;

#region record-types
User user = new("Can", 2022, "DCANSYN"); // fit-and-finish-features
Console.WriteLine($"{user.Name} - {user.Year} - {user.Text}");

static User? GetUserData()
{
    try
    {
        using var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "http://echo.jsontest.com/Name/dcansyn/Year/2022/Text/hello-world");
        var response = httpClient.Send(request);
        using var reader = new StreamReader(response.Content.ReadAsStream());
        var responseBody = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<User>(responseBody);
    }
    catch (Exception)
    {
        return null;
    }
}

var serviceUser = GetUserData();
if (serviceUser != null)
    Console.WriteLine($"{serviceUser.Name} - {serviceUser.Year} - {serviceUser.Text}");
#endregion


#region value-equality
var phoneNumbers = new string[2];
Person person1 = new("Nancy", "Davolio", phoneNumbers);
Person person2 = new("Nancy", "Davolio", phoneNumbers);
Console.WriteLine(person1 == person2); // output: True

person1.PhoneNumbers[0] = "555-1234";
Console.WriteLine(person1 == person2); // output: True

Console.WriteLine(ReferenceEquals(person1, person2)); // output: False
#endregion


#region nondestructive-mutation
Person person3 = new("Nancy", "Davolio", new string[] { });
Console.WriteLine(person3);
// output: Person { FirstName = Nancy, LastName = Davolio }

Person person4 = person3 with { FirstName = "John" };
Console.WriteLine(person4);
// output: Person { FirstName = John, LastName = Davolio }
Console.WriteLine(person3 == person4); // output: False

person4 = person3 with { LastName = "Test" };
Console.WriteLine(person4);
// output: Person { FirstName = Nancy, LastName = Test }
Console.WriteLine(person3 == person4); // output: False

person4 = person3 with { };
Console.WriteLine(person3 == person4); // output: True
#endregion


#region inheritance
Person teacher = new Teacher("Nancy", "Davolio", 3);
Console.WriteLine(teacher);
#endregion


#region init-only-setters
var now = new WeatherObservation
{
    RecordedAt = DateTime.Now,
    TemperatureInCelsius = 20,
    PressureInMillibars = 998.0m
};
Console.WriteLine(now);
#endregion


#region pattern-matching-enhancements
static bool IsLetter(char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

Console.WriteLine(IsLetter('2'));
Console.WriteLine(IsLetter('D'));
Console.WriteLine(IsLetter('c'));
#endregion
using System.Text;
using ConsolePlaygrouns;

var json = @"{""clientId"": 1, ""name"": ""Name"", ""surname"": ""Surname"", ""middleName"": ""MiddleName"",
 ""citizenship"": ""KGZ"", ""placeOfBirth"": ""KGZ"", ""birthDate"": ""1995-10-21"", ""gender"": ""MAL"",
 ""martialStatus"":""NMR"", ""nationality"":""Brabras"", ""number"": ""996550877613"", ""issueOrganization"": ""Brarbas"",
""issueOrganizationSubdivision"":""Brabras"", ""issueDate"":""2000-01-01"", ""endDate"": ""2040-01-01"", ""vatNumber"": ""123""}";
var stringContent = new StringContent(json,
    Encoding.UTF8,
    "application/json");
var configuration = new ClientMonitoringHttpClientConfiguration
{
    BaseUri = "http://localhost:8050",
    Timeout = TimeSpan.FromSeconds(10)
};


using var httpClient = new HttpClient();
var baseUri = configuration.BaseUri;
if (!baseUri.EndsWith("/"))
    baseUri += "/";

httpClient.BaseAddress = new Uri(baseUri);
httpClient.DefaultRequestHeaders.Add("ssl-client-subject-dn", "CN=admin-01");
using var timeoutCts = new CancellationTokenSource();
var token = timeoutCts.Token;

var responseMessage = await httpClient.PostAsync("payment-system-client/edit", stringContent, token);


Console.ReadLine();


using System.Text;
using ConsolePlaygrouns;

// var json = @"{""clientId"": 1, ""name"": ""Name"", ""surname"": ""Surname"", ""middleName"": ""MiddleName"",
//  ""citizenship"": ""KGZ"", ""placeOfBirth"": ""KGZ"", ""birthDate"": ""1995-10-21"", ""gender"": ""MAL"",
//  ""martialStatus"":""NMR"", ""nationality"":""Brabras"", ""number"": ""996550877613"", ""issueOrganization"": ""Brarbas"",
// ""issueOrganizationSubdivision"":""Brabras"", ""issueDate"":""2000-01-01"", ""endDate"": ""2040-01-01"", ""vatNumber"": ""123""}";
// var stringContent = new StringContent(json,
//     Encoding.UTF8,
//     "application/json");
// var configuration = new ClientMonitoringHttpClientConfiguration
// {
//     BaseUri = "http://localhost:8050",
//     Timeout = TimeSpan.FromSeconds(10)
// };


// httpClient.BaseAddress = new Uri(baseUri);
// httpClient.DefaultRequestHeaders.Add("ssl-client-subject-dn", "CN=admin-01");
// using var timeoutCts = new CancellationTokenSource();
// var token = timeoutCts.Token;

// var responseMessage = await httpClient.PostAsync("payment-system-client/edit", stringContent, token);

const string fileName = @"C:\Users\testXML.xml";

if (File.Exists(fileName))
{
    File.Delete(fileName);
}

using var httpClient = new HttpClient(new HttpClientHandler { AllowAutoRedirect = true });
{
    httpClient.DefaultRequestHeaders.Add("User-Agent",
                                         "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:77.0) Gecko/20100101 Firefox/77.0");
    var baseUri = "https://sanctionslistservice.ofac.treas.gov/api/PublicationPreview/exports/SDN_ENHANCED.XML";
    
    var result      = await httpClient.GetAsync(baseUri);
    // Uri redirectUrl = result.Headers.Location;
    //
    // var    content = await httpClient.GetAsync(redirectUrl);
    //
    // string xml = await content.Content.ReadAsStringAsync();
    Console.WriteLine(result.StatusCode);
    
    await using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
    {
        await fileStream.WriteAsync(await result.Content.ReadAsByteArrayAsync());
        await fileStream.FlushAsync();
    }
}
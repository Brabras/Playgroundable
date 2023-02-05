using System.Net;
using System.Text;
using ConsolePlaygrouns.Validation;
using CSharpFunctionalExtensions;

namespace ConsolePlaygrouns;

public static class HttpExtensions
{
    public static async Task<HttpResponseMessage> PostAsync<TRequest>(this HttpClient httpClient,
                                                                      string requestUri,
                                                                      TRequest request,
                                                                      CancellationToken cancellationToken)
        where TRequest : notnull
    {
        var requestJson = SystemJsonSerializer.Serialize(request);

        var stringContent = new StringContent(requestJson,
                                              Encoding.UTF8,
                                              "application/json");

        return await httpClient.PostAsync(requestUri, stringContent, cancellationToken);
    }

    public static async Task<Result<TResponse, SystemError>> AsResultAsync<TResponse>(this HttpResponseMessage response,
                                                                                      CancellationToken cancellationToken)
    {
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync(cancellationToken);
            return SystemJsonSerializer.Deserialize<TResponse>(jsonResponse);
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var errorJson = await response.Content.ReadAsStringAsync(cancellationToken);

            return SystemJsonSerializer.Deserialize<SystemError>(errorJson);
        }

        return SystemError.InternalServerError;
    }

    public static async Task<UnitResult<SystemError>> AsUnitResultAsync(this HttpResponseMessage response,
                                                                        CancellationToken cancellationToken)
    {
        if (response.StatusCode == HttpStatusCode.OK)
        {
            return UnitResult.Success<SystemError>();
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var errorJson = await response.Content.ReadAsStringAsync(cancellationToken);

            return SystemJsonSerializer.Deserialize<SystemError>(errorJson);
        }

        return SystemError.InternalServerError;
    }
}
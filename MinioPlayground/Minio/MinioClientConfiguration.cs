namespace MinioPlayground.Minio;

public sealed class MinioClientConfiguration
{
    public string Endpoint { get; init; } = null!;

    public string AccessKey { get; init; } = null!;

    public string SecretKey { get; init; } = null!;
}
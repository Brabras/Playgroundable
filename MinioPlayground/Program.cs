using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel.Args;
using MinioPlayground.Minio;

var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json");

var configuration = configurationBuilder.Build();

var clientConfiguration = configuration.GetSection("MinioClient").Get<MinioClientConfiguration>()!;

var minioClient = new MinioClient()
                  .WithEndpoint(clientConfiguration.Endpoint)
                  .WithCredentials(accessKey: clientConfiguration.AccessKey,
                                   secretKey: clientConfiguration.SecretKey)
                  .Build();

//
await using var file       = File.Open("Content/3.jpg", FileMode.Open);
await using var memoryStream  = new MemoryStream();
await file.CopyToAsync(memoryStream);

memoryStream.Position = 0;
var putObjectArgs = new PutObjectArgs()
                    .WithBucket("bucket")
                    .WithObject("3.jpg")
                    .WithStreamData(memoryStream)
                    .WithObjectSize(memoryStream.Length)
                    .WithContentType("application/jpg");

await minioClient.PutObjectAsync(putObjectArgs);

// var getObjectArgs = new GetObjectArgs()
//                     .WithBucket("bucket")
//                     .WithObject("3.jpg")
//                     .WithCallbackStream(stream => stream.CopyTo(file));
//
// var res = await minioClient.GetObjectAsync(getObjectArgs);
//
//
// var removeObjectArgs = new RemoveObjectArgs()
//                        .WithBucket("bucket")
//                        .WithObject("3sds.jpg");
//
// await minioClient.RemoveObjectAsync(removeObjectArgs);
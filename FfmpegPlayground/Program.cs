using FFMpegCore;
using FFMpegCore.Arguments;
using FFMpegCore.Enums;
using FFMpegCore.Pipes;

var inputPath = "./TestVideos/TestVideo.webm";

var text1 = @"
Осмонкулов
Надырбек
Османович

21.12.1985
";

var text2 = @"
Поверните голову направо
";

var text3 = @"
Поверните голову налево
";

var text4 = @"
Смотрите прямо в камеру
";

var targetSize = VideoSize.Original;

var info = await FFProbe.AnalyseAsync(inputPath);
var origHeight = info.PrimaryVideoStream.Height;
var origWidth = info.PrimaryVideoStream.Width;

if (origHeight * origWidth > 921_600)
    targetSize = VideoSize.Hd;

var inputBytes = File.ReadAllBytes(inputPath);
var inputStream = new MemoryStream(inputBytes);

var inputPipe = new StreamPipeSource(inputStream);

var streamSample = new MemoryStream();

var outputPipe = new StreamPipeSink(streamSample);

var ffMpegArgumentProcessor = FFMpegArguments
    .FromPipeInput(inputPipe)
    .OutputToPipe(outputPipe, options => options
        .ForceFormat("webm")
        .WithVideoFilters(filterOptions => filterOptions
            .Scale(targetSize)
            .DrawText(DrawTextOptions.Create($"{text1}", "Arial")
                .WithParameter("box", "1")
                .WithParameter("boxcolor", "black@0.5")
                .WithParameter("fontcolor", "white")
                .WithParameter("fontsize", "24")
                .WithParameter("x", "0")
                .WithParameter("y", "0")
                .WithParameter("enable", "'between(t, 15, 20)'"))
        )
        .WithCustomArgument(@"-an")
    );

await ffMpegArgumentProcessor.ProcessAsynchronously();

var outputPath = "./TestVideos/TestVideoHD.webm";

await using var outputStream = File.Create(outputPath);
await outputStream.WriteAsync(streamSample.GetBuffer());
await outputStream.FlushAsync();

//
// .DrawText(DrawTextOptions.Create($"{text2}", "Arial")
//         .WithParameter("enable", "'between(t, 5, 10)'")
//         .WithParameter("box", "1")
//         .WithParameter("boxcolor", "black@0.5")
//         .WithParameter("fontcolor", "white")
//         .WithParameter("fontsize", "24")
//         .WithParameter("x", "(w-text_w)")
//         .WithParameter("y", "0"))
//     .DrawText(DrawTextOptions.Create($"{text3}", "Arial")
//         .WithParameter("enable", "'between(t, 10, 15)'")
//         .WithParameter("box", "1")
//         .WithParameter("boxcolor", "black@0.5")
//         .WithParameter("fontcolor", "white")
//         .WithParameter("fontsize", "24")
//         .WithParameter("x", "(w-text_w)")
//         .WithParameter("y", "0"))
//     .DrawText(DrawTextOptions.Create($"{text4}", "Arial")
//         .WithParameter("enable", "'between(t, 15, 20)'")
//         .WithParameter("box", "1")
//         .WithParameter("boxcolor", "black@0.5")
//         .WithParameter("fontcolor", "white")
//         .WithParameter("fontsize", "24")
//         .WithParameter("x", "(w-text_w)")
//         .WithParameter("y", "0")
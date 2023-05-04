using FFMpegCore;
using FFMpegCore.Arguments;
using FFMpegCore.Enums;

var inputPath = "./videos/TestVideoBefore.mp4";
var outputPath = "./videos/TestVideoAfter.mp4";

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

try
{
    var targetSize = VideoSize.Original;

    var info = await FFProbe.AnalyseAsync(inputPath);
    var videoStream = info.PrimaryVideoStream;

    if (videoStream is not null)
    {
        Console.WriteLine($"Width: {videoStream.Width}");
        Console.WriteLine($"Height: {videoStream.Height}");
        Console.WriteLine($"CodecName: {videoStream.CodecName}");
        Console.WriteLine($"PixelFormat: {videoStream.PixelFormat}");

        var origHeight = videoStream.Height;
        var origWidth = videoStream.Width;
        if (origHeight * origWidth > 921_600)
            targetSize = VideoSize.Hd;
    }

    await FFMpegArguments
        .FromFileInput(inputPath)
        .OutputToFile(outputPath, true, options => options
            .ForceFormat("mp4")
            .WithVideoFilters(filterOptions => filterOptions
                .Scale(targetSize)
                .DrawText(DrawTextOptions.Create($"{text1}", "Arial")
                    .WithParameter("box", "1")
                    .WithParameter("boxcolor", "black@0.5")
                    .WithParameter("fontcolor", "white")
                    .WithParameter("fontsize", "24")
                    .WithParameter("x", "0")
                    .WithParameter("y", "0"))
                .DrawText(DrawTextOptions.Create($"{text2}", "Arial")
                    .WithParameter("enable", "'between(t, 3, 6)'")
                    .WithParameter("box", "1")
                    .WithParameter("boxcolor", "black@0.5")
                    .WithParameter("fontcolor", "white")
                    .WithParameter("fontsize", "24")
                    .WithParameter("x", "(w-text_w)/2")
                    .WithParameter("y", "0"))
                .DrawText(DrawTextOptions.Create($"{text3}", "Arial")
                    .WithParameter("enable", "'between(t, 6, 9)'")
                    .WithParameter("box", "1")
                    .WithParameter("boxcolor", "black@0.5")
                    .WithParameter("fontcolor", "white")
                    .WithParameter("fontsize", "24")
                    .WithParameter("x", "(w-text_w)/2")
                    .WithParameter("y", "0"))
                .DrawText(DrawTextOptions.Create($"{text4}", "Arial")
                    .WithParameter("enable", "'between(t, 9, 12)'")
                    .WithParameter("box", "1")
                    .WithParameter("boxcolor", "black@0.5")
                    .WithParameter("fontcolor", "white")
                    .WithParameter("fontsize", "24")
                    .WithParameter("x", "(w-text_w)/2")
                    .WithParameter("y", "0")
                ))
            .WithCustomArgument("-an")
        ).ProcessAsynchronously();
}
catch (Exception e)
{
    Console.WriteLine(e);
}
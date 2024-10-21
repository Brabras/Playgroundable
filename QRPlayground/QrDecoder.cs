using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace QRPlayground;

public static class Decoder
{
    public static string? Decode(byte[] bytes, string fileName)
    {
        Console.WriteLine(fileName);
        using var image = Image.Load<Rgba32>(bytes);
        if (image.Width > image.Height)
        {
            image.Mutate(x => x.Rotate(90));
        }

        var reader = new QRCodeReader();

        var coordinates = Coordinates.Create(image.Width, image.Height);

        var angleSteps = new List<int> { 90, 10, 1 };

        foreach (var step in angleSteps)
        {
            var stepResult = Cycle(reader, image, coordinates, step, fileName);

            if (stepResult is not null)
                return stepResult;
        }

        return null;
    }

    private static string? Cycle(
        QRCodeReader reader,
        Image<Rgba32> image,
        Coordinates[] coordinates,
        int angleStep,
        string fileName
    )
    {
        foreach (var coordinate in coordinates)
        {
            using var croppedImage = image.Clone(
                                                 x => x.Crop(
                                                             new Rectangle(
                                                                           coordinate.X,
                                                                           coordinate.Y,
                                                                           coordinate.Width,
                                                                           coordinate.Height
                                                                          )
                                                            )
                                                );

            for (var angle = 0; angle < 360; angle += angleStep)
            {
                using var rotatedImage = croppedImage.Clone(i => i.Rotate(angle));

                // rotatedImage.Save($"Results/{coordinate.Name}{angle}{fileName}");

                var luminanceSource = new ImageSharpLuminanceSource(rotatedImage);
                var binarizer       = new HybridBinarizer(luminanceSource);
                var binaryBitmap    = new BinaryBitmap(binarizer);
                var decodedResult = reader.decode(binaryBitmap);

                IterationCounter.Increment();
                if (decodedResult is not null)
                {
                    return decodedResult.Text;
                }
            }
        }

        return null;
    }

    private sealed class ImageSharpLuminanceSource : LuminanceSource
    {
        public ImageSharpLuminanceSource(Image<Rgba32> image)
            : base(image.Width, image.Height)
        {
            Matrix = new byte[Width * Height];
            image.ProcessPixelRows(
                                   accessor =>
                                   {
                                       for (var y = 0; y < Height; y++)
                                       {
                                           var row = accessor.GetRowSpan(y);
                                           for (var x = 0; x < Width; x++)
                                           {
                                               var pixel = row[x];
                                               Matrix[y * Width + x] = (byte)((pixel.R + pixel.G + pixel.B) / 3);
                                           }
                                       }
                                   }
                                  );
        }

        public override byte[] Matrix { get; }

        public override byte[] getRow(int y, byte[] row)
        {
            Array.Copy(Matrix, y * Width, row, 0, Width);
            return row;
        }
    }

    private sealed class Coordinates
    {
        public string Name { get; init; } = null!;
        public int X { get; private init; }
        public int Y { get; private init; }
        public int Width { get; private init; }
        public int Height { get; private init; }

        private Coordinates()
        {
        }

        public static Coordinates[] Create(int width, int height)
        {
            return
            [
                new Coordinates
                {
                    Name   = "up",
                    X      = width / 2 - width / 10,
                    Y      = 0,
                    Width  = width / 5,
                    Height = width / 5
                },
                new Coordinates
                {
                    Name   = "down",
                    X      = width / 2 - width / 10,
                    Y      = height - width / 5,
                    Width  = width / 5,
                    Height = width / 5
                }
            ];
        }
    }
}
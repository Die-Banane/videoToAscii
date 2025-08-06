using System;
using System.Security.Cryptography.X509Certificates;
using FFMpegCore.Arguments;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace videoToAscii;

public class Renderer
{
    private List<string> _buffer = new();

    public Renderer()
    {
        foreach (var frame in Directory.GetFiles(@"frames"))
        {
            _buffer.Add(Render(Image.Load<Rgba32>(frame)));
        }
    }

    public async Task PlayVideo()
    {
        foreach (var frame in _buffer)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(frame);
            await Task.Delay(TimeSpan.FromMilliseconds(83.2));
        }
    }

    private string Render(Image<Rgba32> frame)
    {
        string finalRender = "";

        double[,] brightnessValues = GetBrightness(frame);

        for (int y = 0; y < frame.Height; y++)
        {
            for (int x = 0; x < frame.Width; x++)
            {
                finalRender += brightnessValues[x, y] switch
                {
                    0 => "  ",
                    0.1 => "..",
                    0.2 => "::",
                    0.3 => "--",
                    0.4 => "==",
                    0.5 => "++",
                    0.6 => "**",
                    0.7 => "##",
                    0.8 => "%%",
                    _ => "@@"
                };
            }

            finalRender += "\n";
        }

        return finalRender;
    }
    private double[,] GetBrightness(Image<Rgba32> frame)
    {
        double[,] brightnessValues = new double[frame.Width, frame.Height];

        for (int y = 0; y < frame.Height; y++)
        {
            for (int x = 0; x < frame.Width; x++)
            {
                Rgba32 pixel = frame[x, y];

                brightnessValues[x, y] = Math.Round(((pixel.R + pixel.G + pixel.B) / 3) / 255.0, 1);
            }
        }

        return brightnessValues;
    }
}
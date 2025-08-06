using System;
using FFMpegCore;
using FFMpegCore.Arguments;

namespace videoToAscii;

public class FFMpegUtil
{
    public static void Extract(string input)
    {
        CLear();

        if (!Directory.Exists(@"frames"))
            Directory.CreateDirectory(@"frames");

        FFMpegArguments
            .FromFileInput(input)
            .OutputToFile(@"frames/out-%04d.png", true, options => options
                .Resize(60, 34))
            .ProcessSynchronously();
    }

    private static void CLear()
    {
        foreach (var file in Directory.GetFiles(@"frames"))
        {
            File.Delete(file);
        }
    }
}
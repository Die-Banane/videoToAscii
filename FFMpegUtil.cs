using FFMpegCore;

namespace videoToAscii;

public class FFMpegUtil
{
    public static void Extract(string input)
    {
        if (!Directory.Exists(@"frames"))
            Directory.CreateDirectory(@"frames");

        CLear();

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
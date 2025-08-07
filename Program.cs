using FFMpegCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using videoToAscii;

string input = @"/home/jonas/Downloads/testvideo.mp4";

FFMpegUtil.Extract(input);

var renderer = new Renderer();

await renderer.PlayVideo();

//var image = Image.Load<Rgba32>(@"/home/jonas/Schreibtisch/Projekte/videoToAscii/frames/out-0001.png");

//Console.Write(Renderer.Render(image));
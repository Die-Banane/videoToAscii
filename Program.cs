using videoToAscii;

string input = @"/home/jonas/Downloads/testvideo.mp4";

FFMpegUtil.Extract(input);

var renderer = new Renderer();

await renderer.PlayVideo();
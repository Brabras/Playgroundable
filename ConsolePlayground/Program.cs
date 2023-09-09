var origWidth = 720;
var origHeight = 1280;
var maxWidth = 720;
var maxHeight = 720;

var widthScale = (decimal)maxWidth / origWidth;
var heightScale = (decimal)maxHeight / origHeight;
var scale = Math.Min(widthScale, heightScale);
var scaledWidth = origWidth * scale;
var scaledHeight = origHeight * scale;

Console.WriteLine(scaledWidth);
Console.WriteLine(scaledHeight);
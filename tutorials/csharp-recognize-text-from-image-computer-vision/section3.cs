using IronOcr;

using var input = new OcrInput();
// Load at least one image
input.LoadImage("/path/file.png");

input.FindTextRegion(Scale: 2.0, Binarize: true);
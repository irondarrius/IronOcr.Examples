using IronOcr;
using IronSoftware.Drawing;
using System.Collections.Generic;
using System.Linq;

int pageIndex = 0;
using var input = new OcrInput();
input.LoadImage("/path/file.png");

var selectedPage = input.GetPages().ElementAt(pageIndex);
// List<Rectangle> regions = selectedPage.GetTextRegions();
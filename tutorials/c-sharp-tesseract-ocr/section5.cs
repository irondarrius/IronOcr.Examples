using IronOcr;

var text = new IronTesseract().Read("img.png").Text;
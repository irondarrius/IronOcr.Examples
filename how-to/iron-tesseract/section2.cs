IronTesseract ocr = new IronTesseract
{
    Configuration = new TesseractConfiguration
    {
        ReadBarCodes = false,
        RenderHocr = true,
        TesseractVariables = null,
        WhiteListCharacters = null,
        BlackListCharacters = "`ë|^",
    },
    MultiThreaded = false,
    Language = OcrLanguage.English,
    EnableTesseractConsoleMessages = true, // False as default
};
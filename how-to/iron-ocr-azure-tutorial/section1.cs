using IronOcr;
namespace IronOcr.Examples.HowTo.IronOcrAzureTutorial
{
    public static class Section1
    {
        public static void Run()
        {
            var Ocr = new IronTesseract();
                        using (var input = new OcrInput())
                        {
                            input.Title = "Divine Comedy - Purgatory"; //Give title to input document 
                            //Supply optional password and name of document
                     		input.AddPdf("..\\Documents\\Purgatorio.pdf", "dante");
                            var Result = Ocr.Read(input); //Read the input file
                            
            				Result.SaveAsSearchablePdf("SearchablePDFDocument.pdf"); 
                        }
        }
    }
}
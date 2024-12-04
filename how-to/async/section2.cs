using IronOcr;
namespace ironocr.Async
{
    public class Section2
    {
        public void Run()
        {
            IronTesseract ocr = new IronTesseract();
            
            OcrPdfInput largePdf = new OcrPdfInput("chapter1.pdf");
            
            Func<OcrResult> reader = () =>
            {
                return ocr.Read(largePdf);
            };
            
            OcrReadTask readTask = new OcrReadTask(reader.Invoke);
            // Start the OCR task asynchronously
            readTask.Start();
            
            // Continue with other tasks while OCR is in progress
            DoOtherTasks();
            
            // Wait for the OCR task to complete and retrieve the result
            OcrResult result = await Task.Run(() => readTask.Result);
            
            Console.Write($"##### OCR RESULTS ###### \n {result.Text}");
            
            largePdf.Dispose();
            readTask.Dispose();
            
            static void DoOtherTasks()
            {
                // Simulate other tasks being performed while OCR is in progress
                Console.WriteLine("Performing other tasks...");
                Thread.Sleep(2000); // Simulating work for 2000 milliseconds
            }
        }
    }
}
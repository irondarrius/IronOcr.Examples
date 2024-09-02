// Export searchable PDF byte
byte[] pdfByte = ocrResult.SaveAsSearchablePdfBytes();

// Export searchable PDF stream
Stream pdfStream = ocrResult.SaveAsSearchablePdfStream();
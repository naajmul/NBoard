using System;
using System.IO;
using System.Windows.Media.Imaging;
using NBoard.Models;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace NBoard.Services
{
    public class ExportService
    {
        public static void ExportToPDF(Document document, string outputPath)
        {
            try
            {
                using (PdfWriter writer = new PdfWriter(outputPath))
                {
                    using (PdfDocument pdfDoc = new PdfDocument(writer))
                    {
                        Document layoutDoc = new Document(pdfDoc);
                        layoutDoc.Add(new Paragraph($"NBoard Document: {document.Name}"));
                        layoutDoc.Add(new Paragraph($"Created: {document.Created}"));
                        layoutDoc.Add(new Paragraph($"Modified: {document.Modified}"));
                        layoutDoc.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting to PDF: {ex.Message}");
            }
        }

        public static void ExportToPNG(BitmapSource bitmap, string outputPath)
        {
            try
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));

                using (FileStream stream = new FileStream(outputPath, FileMode.Create))
                {
                    encoder.Save(stream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting to PNG: {ex.Message}");
            }
        }

        public static void ExportToSVG(Document document, string outputPath)
        {
            try
            {
                string svgContent = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
                svgContent += "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"1920\" height=\"1080\">\n";
                svgContent += $"  <!-- NBoard Export: {document.Name} -->\n";
                svgContent += "</svg>";

                File.WriteAllText(outputPath, svgContent);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting to SVG: {ex.Message}");
            }
        }

        public static void ExportToJSON(Document document, string outputPath)
        {
            try
            {
                DocumentManager.SaveDocument(document);
                File.Copy(document.FilePath, outputPath, true);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting to JSON: {ex.Message}");
            }
        }
    }
}
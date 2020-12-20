using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace TWAIN
{
    public static class PDFProcessing
    {
        public static Stream CreatePages(List<Image> images)
        {
            var documentStream = new MemoryStream();

            PdfDocument document = new PdfDocument();

            foreach (var image in images)
            {
                var page = new PdfPage
                {
                    Size = PdfSharp.PageSize.A4
                };

                page.TrimMargins.All = 0;

                document.Pages.Add(page);

                XGraphics xGraphics = XGraphics.FromPdfPage(page);

                using (var memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, ImageFormat.Jpeg);

                    XImage xImage = XImage.FromStream(memoryStream);

                    xGraphics.DrawImage(xImage, 0, 0);
                }
            }

            document.Save(documentStream, false);

            return documentStream;
        }
    }
}

using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Windows.Forms;

namespace TWAIN.Controllers
{
    public class ScansController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var selectDeviceDialog = Program.Context._TWSelectDevice = new TWSelectDevice();

            selectDeviceDialog.BringToFront();

            switch (selectDeviceDialog.ShowDialog())
            {
                case DialogResult.OK:
                    var documentStream = PDFProcessing.CreatePages(selectDeviceDialog.Images);

                    return CreateFileResponse("scanned-document.pdf", documentStream);
                case DialogResult.Cancel:
                    return CreateErrorResponse("Scan was canceled.");
                case DialogResult.Abort:
                    return CreateErrorResponse("Scan failed.");
                default:
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        private HttpResponseMessage CreateErrorResponse(string errorMessage)
        {
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);

            var messageContent = new StringContent(errorMessage);

            messageContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpResponseMessage.Content = messageContent;

            return httpResponseMessage;
        }

        private HttpResponseMessage CreateFileResponse(string fileName, Stream fileStream)
        {
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(fileStream)
            };

            httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };

            httpResponseMessage.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            return httpResponseMessage;
        }
    }
}

using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TiendaRopa.Clases;

namespace TiendaRopa.Controllers
{
    [RoutePrefix("uploadFiles")]
    public class UploadFilesController : ApiController
    {
        [HttpPost]
        [Route("subir")]
        public async Task<HttpResponseMessage> GrabarArchivo(HttpRequestMessage Request, string Datos, string Proceso)
        {
            clsUpload upload = new clsUpload();
            upload.request = Request;
            upload.Datos = Datos;
            upload.Proceso = Proceso;
            return await upload.GrabarArchivo(false);
        }
    }
}
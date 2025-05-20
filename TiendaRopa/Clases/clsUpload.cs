using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace TiendaRopa.Clases
{
    public class clsUpload
    {
        public HttpRequestMessage request { get; set; }
        public string Datos { get; set; }
        public string Proceso { get; set; }

        public async Task<HttpResponseMessage> GrabarArchivo(bool Actualizar)
        {
            if (!request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(System.Net.HttpStatusCode.UnsupportedMediaType);

            string root = HttpContext.Current.Server.MapPath("~/Archivos");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await request.Content.ReadAsMultipartAsync(provider);
                List<string> Archivos = new List<string>();
                foreach (MultipartFileData file in provider.FileData)
                {
                    string fileName = file.Headers.ContentDisposition.FileName.Trim('"');
                    if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                        fileName = Path.GetFileName(fileName);

                    if (File.Exists(Path.Combine(root, fileName)))
                    {
                        if (Actualizar)
                        {
                            File.Delete(Path.Combine(root, fileName));
                            File.Move(file.LocalFileName, Path.Combine(root, fileName));
                        }
                        else
                        {
                            File.Delete(file.LocalFileName);
                            return request.CreateErrorResponse(HttpStatusCode.Conflict, "El archivo ya existe");
                        }
                    }
                    else
                    {
                        Archivos.Add(fileName);
                        File.Move(file.LocalFileName, Path.Combine(root, fileName));
                    }
                }
                if (Archivos.Count > 0)
                {
                    string respuesta = ProcesarArchivos(Archivos);
                    return request.CreateResponse(HttpStatusCode.OK, respuesta);
                }
                else
                {
                    return request.CreateErrorResponse(HttpStatusCode.Conflict, "No se subieron archivos nuevos");
                }
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error al cargar el archivo: " + ex.Message);
            }
        }

        private string ProcesarArchivos(List<string> Archivos)
        {
            switch (Proceso.ToUpper())
            {
                case "PRODUCTO":
                    clsFotoProducto fotos = new clsFotoProducto();
                    fotos.IdProducto = Convert.ToInt32(Datos); // Datos debe ser el IdProducto
                    fotos.Archivos = Archivos;
                    return fotos.GrabarFotos();
                default:
                    return "Proceso no válido";
            }
        }
    }
}
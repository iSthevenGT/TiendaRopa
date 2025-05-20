using System;
using System.Collections.Generic;
using System.Linq;
using TiendaRopa.Models;

namespace TiendaRopa.Clases
{
    public class clsFotoProducto
    {
        private DBTiendaRopaEntities DBTienda = new DBTiendaRopaEntities();
        public int IdProducto { get; set; }
        public List<string> Archivos { get; set; }

        public string GrabarFotos()
        {
            try
            {
                if (Archivos != null && Archivos.Count > 0)
                {
                    foreach (string archivo in Archivos)
                    {
                        FotoProducto foto = new FotoProducto();
                        foto.IdProducto = IdProducto;
                        foto.Ruta = archivo;
                        DBTienda.FotoProductoes.Add(foto);
                        DBTienda.SaveChanges();
                    }
                    return "Fotos guardadas correctamente";
                }
                else
                {
                    return "No se enviaron archivos para guardar";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<FotoProducto> ConsultarPorProducto(int idProducto)
        {
            return DBTienda.FotoProductoes.Where(f => f.IdProducto == idProducto).ToList();
        }

        public string Eliminar(int idFoto)
        {
            var foto = DBTienda.FotoProductoes.FirstOrDefault(f => f.IdFoto == idFoto);
            if (foto == null) return "Foto no encontrada";
            DBTienda.FotoProductoes.Remove(foto);
            DBTienda.SaveChanges();
            return "Foto eliminada correctamente";
        }
    }
}
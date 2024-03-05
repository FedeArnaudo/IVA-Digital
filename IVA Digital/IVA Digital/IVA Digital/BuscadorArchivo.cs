using System.IO;
using System.Linq;

namespace IVA_Digital
{
    public class BuscadorArchivo
    {
        private string archivoEncontrado;
        public BuscadorArchivo()
        {

        }

        public bool BuscarArchivo(string rutaArchivo, string nombreArchivo)
        {
            if (!(nombreArchivo.EndsWith("txt") || nombreArchivo.EndsWith("TXT")))
            {
                nombreArchivo += ".TXT";
            }
            SetArchivoEncontrado(Path.Combine(rutaArchivo, nombreArchivo));

            // Realizar la búsqueda del archivo
            string[] archivosEncontrados = Directory.GetFiles(rutaArchivo, nombreArchivo, SearchOption.AllDirectories);

            if (archivosEncontrados.Length > 0 && archivosEncontrados.Contains(Path.Combine(rutaArchivo, nombreArchivo)))
            {
                return true;
            }
            else
            {
                //return $"No se ha encontrado el archivo en la ubicacion: {Path.Combine(rutaArchivo, nombreArchivo)}";
                return false;
            }
        }
        public void SetArchivoEncontrado(string archivoEncontrado)
        {
            this.archivoEncontrado = archivoEncontrado;
        }

        public string GetArchivoEncontrado()
        {
            return archivoEncontrado;
        }
    }
}

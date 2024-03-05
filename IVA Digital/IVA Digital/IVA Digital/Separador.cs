using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace IVA_Digital
{
    internal class Separador
    {
        private readonly List<string> renglones = new List<string>();
        public Separador()
        {

        }

        public void Separar(string filePath)
        {
            try
            {
                // Lee todas las líneas del archivo y las almacena en un array
                string[] lineas = File.ReadAllLines(filePath);

                // Muestra cada línea en la consola
                //Console.WriteLine("Contenido del archivo:");
                foreach (string linea in lineas)
                {
                    renglones.Add(linea);
                }
            }
            catch (FileNotFoundException)
            {
                _ = MessageBox.Show("Archivo no encontrado");

            }
            catch (IOException e)
            {
                _ = MessageBox.Show($"Error de E/S: {e.Message}");
            }
        }

        public string Listar()
        {
            string listar = "LISTADO DE RENGLONES:\n";
            foreach (string renglon in GetRenglones())
            {
                listar += renglon + "\n";
            }
            return listar;
        }

        public List<string> GetRenglones()
        {
            return renglones;
        }
    }
}

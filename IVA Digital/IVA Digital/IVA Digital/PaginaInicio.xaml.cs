using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IVA_Digital
{
    /// <summary>
    /// Interaction logic for PaginaInicio.xaml
    /// </summary>
    public partial class PaginaInicio : Page
    {
        private readonly BuscadorArchivo BuscadorArchivo = new BuscadorArchivo();
        private readonly Separador separador = new Separador();
        private readonly List<Registro> registros;

        public PaginaInicio(List<Registro> registros)
        {
            InitializeComponent();
            this.registros = registros;
        }

        private void Validar_Click(object sender, RoutedEventArgs e)
        {
            if (BuscadorArchivo.BuscarArchivo(TextBoxRutaArchivo.Text, TextBoxNombreArchivo.Text))
            {
                _ = MessageBox.Show($"Se ha encontrado el archivo: {BuscadorArchivo.GetArchivoEncontrado()}.");
                separador.Separar(BuscadorArchivo.GetArchivoEncontrado());
                foreach (string s in separador.GetRenglones())
                {
                    registros.Add(new Registro(s));
                }

                // Accede al botón en la ventana principal desde el control de usuario
                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    if (mainWindow.FindName("BtnBusquedaRapida") is Button BtnBusquedaRapida)
                    {
                        // Habilita el botón en la ventana principal
                        BtnBusquedaRapida.IsEnabled = true;
                    }
                    if (mainWindow.FindName("BtnFiltro") is Button BtnFiltro)
                    {
                        // Habilita el botón en la ventana principal
                        BtnFiltro.IsEnabled = true;
                    }
                }
            }
            else
            {
                _ = MessageBox.Show($"No se ha encontrado el archivo: {BuscadorArchivo.GetArchivoEncontrado()}.");
            }
        }

        public List<Registro> GetRegistros()
        {
            return registros;
        }
    }
}

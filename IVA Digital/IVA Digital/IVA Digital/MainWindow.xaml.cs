using IVA_Digital.Views;
using System.Collections.Generic;
using System.Windows;

namespace IVA_Digital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly List<Registro> registros = new List<Registro>();
        private readonly PaginaInicio PaginaInicio = new PaginaInicio(registros);
        public MainWindow()
        {
            InitializeComponent();
            _ = FrameInicio.NavigationService.Navigate(PaginaInicio);
            BtnBusquedaRapida.IsEnabled = false;
            BtnFiltro.IsEnabled = false;
        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            _ = FrameInicio.NavigationService.Navigate(PaginaInicio);
        }

        private void BtnBusquedaRapida_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Buscar(registros);
        }
    }
}

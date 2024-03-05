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

namespace IVA_Digital.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Buscar : UserControl
    {
        private List<Registro> registros;
        public Buscar(List<Registro> registros)
        {
            InitializeComponent();
            this.registros = registros;
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            if (registros.Any())
            {
                if (CheckBoxRenglon.IsChecked == true)
                {
                    if (NRenglon.Text != null && NRenglon.Text != "")
                    {
                        MostrarDatosPorNumero(int.Parse(NRenglon.Text));
                    }
                    else
                    {
                        _ = MessageBox.Show("Debe ingresar algun dato");
                    }
                }
                else if (CheckBoxCuit.IsChecked == true)
                {
                    if (NCuit.Text != null && NCuit.Text != "")
                    {
                        MostrarDatosPorCuit(NCuit.Text);
                    }
                    else
                    {
                        _ = MessageBox.Show("Debe ingresar algun dato");
                    }
                }
                else
                {
                    _ = MessageBox.Show("Debe tildar Numero de Renglon o Numero de Cuit.");
                }
            }
            else
            {
                _ = MessageBox.Show("Debe validar el archivo primero.");
            }
        }

        public void MostrarDatosPorNumero(int num)
        {
            num -= 1;
            if (num >= 0 && num < registros.Count)
            {
                GridDatos.ItemsSource = registros[num].GetDatosRenglon();
            }
            else
            {
                _ = MessageBox.Show($"El numero debe estar entre: 1 y {registros.Count}.");
            }
        }

        public void MostrarDatosPorCuit(string num)
        {
            bool encontrado = false;
            if (double.Parse(num) > 10000000000 && double.Parse(num) < 99999999999)
            {
                foreach (Registro registro in registros)
                {
                    if (registro.NumeroIdentificacionComprobante.EndsWith(num))
                    {
                        GridDatos.ItemsSource = registro.GetDatosRenglon();
                        encontrado = true;
                        break;
                    }
                }
            }
            else
            {
                _ = MessageBox.Show($"Formato de Cuit incorrecto: {num}.");
            }
            if (!encontrado)
            {
                _ = MessageBox.Show($"El Cuit {num.Substring(0, 2)}-{num.Substring(2, 7)}-{num.Substring(10, 1)} no ha sido encontrado.");
            }
        }

        private void CheckBoxRenglon_Unchecked(object sender, RoutedEventArgs e)
        {
            GridRowCuit.IsEnabled = true;
            CheckBoxCuit.IsChecked = true;
            GridRowRenglon.IsEnabled = false;
            NRenglon.Text = "";
        }

        private void CheckBoxCuit_Unchecked(object sender, RoutedEventArgs e)
        {
            GridRowRenglon.IsEnabled = true;
            CheckBoxRenglon.IsChecked = true;
            GridRowCuit.IsEnabled = false;
        }

        private void TextBoxNumerico_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Verificar si el texto ingresado es un número
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                // Si no es un número, marcar el evento como manejado para evitar que el TextBox procese la entrada
                e.Handled = true;
            }
        }
    }
}

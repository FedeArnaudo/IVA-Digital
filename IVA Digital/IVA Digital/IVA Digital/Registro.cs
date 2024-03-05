using System;
using System.Collections.Generic;

namespace IVA_Digital
{
    public class DatosRenglon
    {
        public DatosRenglon(string descripcion, string codigoDeNumeros, int cantidadDeDigitos)
        {
            Descripcion = descripcion;
            CodigoDeNumeros = codigoDeNumeros;
            CantidadDeDigitos = cantidadDeDigitos;
        }
        public string Descripcion { get; private set; }
        public string CodigoDeNumeros { get; private set; }
        public int CantidadDeDigitos { get; private set; }
    }

    public class Registro
    {
        private readonly Dictionary<string, string> filasDeDatos = new Dictionary<string, string>();
        private readonly List<DatosRenglon> datosRenglons = new List<DatosRenglon>();
        public Registro(string renglon)
        {
            Renglon = renglon;
            Rellenar();
        }

        private void Rellenar()
        {
            FechaComp = Renglon.Substring(0, 8);
            //FechaComp = double.Parse(Renglon.Substring(0, 8));
            TipoComp = Renglon.Substring(8, 3);
            Pdv = Renglon.Substring(11, 5);
            //Pdv = int.Parse(Renglon.Substring(11, 5));
            NumeroDeComprobane = Renglon.Substring(16, 20);
            NumeroDeComprobanteHasta = Renglon.Substring(36, 20);
            CodigoDocumentoComprador = Renglon.Substring(56, 2);
            //CodigoDocumentoComprador = double.Parse(Renglon.Substring(56, 2));
            NumeroIdentificacionComprobante = Renglon.Substring(58, 20);
            DenominacionComprador = Renglon.Substring(78, 30);
            ImporteTotalOperacion = Renglon.Substring(108, 15);
            ImpConceptosNoNetoGravado = Renglon.Substring(123, 15);
            PerceprcionANoCat = Renglon.Substring(138, 15);
            ImporteOperacionesExe = Renglon.Substring(153, 15);
            ImpuestosNacionales = Renglon.Substring(168, 15);
            IngresosBrutos = Renglon.Substring(183, 15);
            ImpuestosMunicipales = Renglon.Substring(198, 15);
            ImpuestosInternos = Renglon.Substring(213, 15);
            CodigoDeMoneda = Renglon.Substring(228, 3);
            TipoDeCambio = Renglon.Substring(231, 10);
            CantidadDeAlicuotas = Renglon.Substring(241, 1);
            CodigoDeOperacion = Renglon.Substring(242, 1);
            OtrosTributos = Renglon.Substring(243, 15);
            FechaVencimiento = Renglon.Substring(258, 8);

            SetFilasDeDatos();
            SetDatosRenglon();
        }

        public void SetFilasDeDatos()
        {
            filasDeDatos.Add("Fecha de Comprobante", FechaComp);
            filasDeDatos.Add("Tipo de Comprobante", TipoComp);
            filasDeDatos.Add("Punto de Venta", Pdv);
            filasDeDatos.Add("Numero de Comprobante", NumeroDeComprobane);
            filasDeDatos.Add("Numero de Comprobante Hasta", NumeroDeComprobanteHasta);
            filasDeDatos.Add("Codigo de Documento del Comprador", CodigoDocumentoComprador);
            filasDeDatos.Add("Numero de Identificacion del Comprobante", NumeroIdentificacionComprobante);
            filasDeDatos.Add("Denominacion del Comprador", DenominacionComprador);
            filasDeDatos.Add("Importe Total de la Operacion", ImporteTotalOperacion);
            filasDeDatos.Add("Importe total de conceptos que no integran el precio neto gravado", ImpConceptosNoNetoGravado);
            filasDeDatos.Add("Percepción a no categorizados", PerceprcionANoCat);
            filasDeDatos.Add("Importe de operaciones exentas", ImporteOperacionesExe);
            filasDeDatos.Add("Pagos a cuenta de impuestos Nacionales", ImpuestosNacionales);
            filasDeDatos.Add("Importe de percepciones de Ingresos Brutos", IngresosBrutos);
            filasDeDatos.Add("Importe de percepciones impuestos Municipales", ImpuestosMunicipales);
            filasDeDatos.Add("Importe impuestos internos", ImpuestosInternos);
            filasDeDatos.Add("Código de moneda", CodigoDeMoneda);
            filasDeDatos.Add("Tipo de cambio", TipoDeCambio);
            filasDeDatos.Add("Cantidad de alícuotas de IVA", CantidadDeAlicuotas);
            filasDeDatos.Add("Código de operación", CodigoDeOperacion);
            filasDeDatos.Add("Otros Tributos", OtrosTributos);
            filasDeDatos.Add("Fecha de Vencimiento o Pago", FechaVencimiento);
        }

        public Dictionary<string, string> GetFilasDeDatos()
        {
            return filasDeDatos;
        }

        public void SetDatosRenglon()
        {
            foreach (string key in GetFilasDeDatos().Keys)
            {
                string value = GetFilasDeDatos()[key];
                datosRenglons.Add(new DatosRenglon(key, value, value.Length));
            }
        }

        public List<DatosRenglon> GetDatosRenglon()
        {
            return datosRenglons;
        }

        public void Mostrar()
        {
            Console.WriteLine($"Fecha de Comprobante: {FechaComp}\nTipo de Comprobante: {TipoComp}\nPunto de Venta: {Pdv}\n" +
                $"Numero de Comprobante: {NumeroDeComprobane}\nNumero de Comprobante Hasta: {NumeroDeComprobanteHasta}\n" +
                $"Codigo de Documento del Comprador: {CodigoDocumentoComprador}\nNumero de Identificacion del Comprobante: {NumeroIdentificacionComprobante}\n" +
                $"Denominacion del Comprador: {DenominacionComprador}\nImporte Total de la Operacion: {ImporteTotalOperacion}\n" +
                $"Importe total de conceptos que no integran el precio neto gravado: {ImpConceptosNoNetoGravado}\n" +
                $"Percepción a no categorizados: {PerceprcionANoCat}\nImporte de operaciones exentas: {ImporteOperacionesExe}\n" +
                $"Pagos a cuenta de impuestos Nacionales: {ImpuestosNacionales}\nImporte de percepciones de Ingresos Brutos: {IngresosBrutos}\n" +
                $"Importe de percepciones impuestos Municipales: {ImpuestosMunicipales}\nImporte impuestos internos: {ImpuestosInternos}\n" +
                $"Código de moneda: {CodigoDeMoneda}\nTipo de cambio: {TipoDeCambio}\nCantidad de alícuotas de IVA: {CantidadDeAlicuotas}\n" +
                $"Código de operación: {CodigoDeOperacion}\nOtros Tributos: {OtrosTributos}\nFecha de Vencimiento o Pago: {FechaVencimiento}\n" +
                $"Total de Strings: {8 + 3 + 5 + 20 + 20 + 2 + 20 + 30 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 3 + 10 + 1 + 1 + 15 + 8}");
        }

        protected string Renglon { get; private set; }
        public string FechaComp { get; private set; }
        public string TipoComp { get; private set; }
        public string Pdv { get; private set; }
        public string NumeroDeComprobane { get; private set; }
        public string NumeroDeComprobanteHasta { get; private set; }
        public string CodigoDocumentoComprador { get; private set; }
        public string NumeroIdentificacionComprobante { get; private set; }
        public string DenominacionComprador { get; private set; }
        public string ImporteTotalOperacion { get; private set; }
        public string ImpConceptosNoNetoGravado { get; private set; }
        public string PerceprcionANoCat { get; private set; }
        public string ImporteOperacionesExe { get; private set; }
        public string ImpuestosNacionales { get; private set; }
        public string IngresosBrutos { get; private set; }
        public string ImpuestosMunicipales { get; private set; }
        public string ImpuestosInternos { get; private set; }
        public string CodigoDeMoneda { get; private set; }
        public string TipoDeCambio { get; private set; }
        public string CantidadDeAlicuotas { get; private set; }
        public string CodigoDeOperacion { get; private set; }
        public string OtrosTributos { get; private set; }
        public string FechaVencimiento { get; private set; }

    }
}

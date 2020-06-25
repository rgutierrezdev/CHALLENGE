/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.MODELOS;
using CodingChallenge.Data.RECURSOS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingChallenge.Data.CLASES
{
    public static class Reporte
    {
        static Dictionary<string, string> Idiomas = new Dictionary<string, string>
        {
            {"INGLES","en-US"},
            {"FRANCES","fr"}
        };
        /// <summary>
        /// figuras recibe un listado de figuras generico, idioma recibe el nombre el idioma a usar (cadena vacia usa el idioma neutral es-AR)
        /// </summary>
        /// <param name="figuras"></param>
        /// <param name="idioma"></param>
        /// <returns></returns>
        public static string Imprimir(List<Figura> figuras, string idioma)
        {
            #region VALIDACIONES
            string idiomaSint = "";
            if (Idiomas.TryGetValue(idioma.ToUpper(), out idiomaSint))            
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(idiomaSint);
            
            if (!figuras.Any()) 
                return new StringBuilder("<h1>"+Idioma.LISTA_VACIA+"</h1>").ToString();
            #endregion

            
            #region VARIABLES
            int numeroFiguras = 0;
            double areaFiguras = 0;
            double perimetroFiguras = 0;
            StringBuilder sb = new StringBuilder();
            #endregion

            //SETEO LOS TIPOS DE FIGURA
            figuras.ForEach(f => f.actualizarTipoFigura());
            //CABECERA
            sb.Append("<h1>" + Idioma.CABECERA + "</h1>");

            //CUERPO
            var listasPorTipo = figuras.GroupBy(f => f.Tipo_Figura)
                                       .Select(grp => grp.ToList())
                                       .ToList();

            foreach (var lista in listasPorTipo)
            {
                int numeroFiguraAUX = 0;
                double areaFiguraAUX = 0;
                double perimetroFiguraAux = 0;
                string tipoFigura = "";

                foreach (var figura in lista)
                {
                    tipoFigura = figura.Tipo_Figura;
                    areaFiguraAUX += figura.CalcularArea();
                    perimetroFiguraAux += figura.CalcularPerimetro();
                    numeroFiguraAUX++;
                }

                sb.Append(ObtenerLinea(numeroFiguraAUX, areaFiguraAUX, perimetroFiguraAux, tipoFigura));
                numeroFiguras += numeroFiguraAUX;
                areaFiguras += areaFiguraAUX;
                perimetroFiguras += perimetroFiguraAux;
            }
                        
            //PIE
            sb.Append(Idioma.TOTAL +":<br/>");
            sb.Append( numeroFiguras + " " + Idioma.FORMAS + " ");
            sb.Append(Idioma.PERIMETRO + " " + perimetroFiguras.ToString("#.##") + " ");
            sb.Append(Idioma.AREA + " " + areaFiguras.ToString("#.##"));
            
            return sb.ToString();
        }
        static string ObtenerLinea(int Cantidad, double Area, double Perimetro, string NombreFigura)
        {
            return Cantidad > 0 ? $"{Cantidad} {Pluralizar(Cantidad, NombreFigura)} | " + Idioma.AREA + $" {Area:#.##} | " + Idioma.PERIMETRO + $" {Perimetro:#.##} <br/>" : String.Empty;
        }
        static string Pluralizar(int Cantidad, string Singular)
        {
            return Cantidad > 1 ? Singular + "s" : Singular;
        }        
    }
}

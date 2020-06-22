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
        static Dictionary<Type, int> diccionario = new Dictionary<Type, int>
        {
            { typeof(FiguraCuadrado),0},
            { typeof(FiguraCirculo),1},
            { typeof(FiguraRectangulo),2},
            { typeof(FiguraTrianguloEquilatero),3},
            { typeof(FiguraTrapecio),4}
        };

        public static string Imprimir(List<Figura> figuras)
        {                      
            if (!figuras.Any()) return new StringBuilder("<h1>"+Idioma.LISTA_VACIA+"</h1>").ToString();

            StringBuilder sb = new StringBuilder();

            #region CONTADORES
            int numeroCuadrados = 0;
            int numeroCirculos = 0;
            int numeroTriangulos = 0;
            int numeroRectangulos = 0;
            int numeroTrapecios = 0;
            #endregion 

            #region ACUMULADORES
            double areaCuadrados = 0;
            double areaCirculos = 0;
            double areaTriangulos = 0;
            double areaRectangulos = 0;
            double areaTrapecios = 0;

            double perimetroCuadrados = 0;
            double perimetroCirculos = 0;
            double perimetroTriangulos = 0;
            double perimetroRectangulos = 0;
            double perimetroTrapecios = 0;
            #endregion

            foreach (Figura f in figuras)
            {
                switch (diccionario[f.GetType()]){
                    case Constantes.CUADRADO:
                        Calcular(ref areaCuadrados, ref perimetroCuadrados, ref numeroCuadrados, f);
                        break;
                    case Constantes.CIRCULO:
                        Calcular(ref areaCirculos, ref perimetroCirculos, ref numeroCirculos, f);
                        break;
                    case Constantes.RECTANGULO:
                        Calcular(ref areaRectangulos, ref perimetroRectangulos, ref numeroRectangulos, f);
                        break;
                    case Constantes.TRIANGULO_EQUILATERO:
                        Calcular(ref areaTriangulos, ref perimetroTriangulos, ref numeroTriangulos, f);
                        break;
                    case Constantes.TRAPECIO:
                        Calcular(ref areaTrapecios, ref perimetroTrapecios, ref numeroTrapecios, f);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(Idioma.FORMA_DESCONOCIDA);
                }
            }

            //CABECERA
            sb.Append("<h1>" + Idioma.CABECERA + "</h1>");
            //CUERPO
            sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Idioma.CUADRADO));
            sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Idioma.CIRCULO));
            sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, Idioma.TRIANGULO));
            sb.Append(ObtenerLinea(numeroRectangulos, areaRectangulos, perimetroRectangulos, Idioma.RECTANGULO));
            sb.Append(ObtenerLinea(numeroTrapecios, areaTrapecios, perimetroTrapecios, Idioma.TRAPECIO));
            //PIE
            sb.Append(Idioma.TOTAL +":<br/>");
            sb.Append( (numeroCuadrados + numeroCirculos + numeroTriangulos + numeroRectangulos + numeroTrapecios) + " " + Idioma.FORMAS + " ");
            sb.Append(Idioma.PERIMETRO + " " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroRectangulos + perimetroTrapecios).ToString("#.##") + " ");
            sb.Append(Idioma.AREA + " " + (areaCuadrados + areaCirculos + areaTriangulos + areaRectangulos + areaTrapecios).ToString("#.##"));

            return sb.ToString();
        }
        static string ObtenerLinea(int Cantidad, double Area, double Perimetro, string NombreFigura)
        {
            return Cantidad > 0 ? $"{Cantidad} {Pluralizar(Cantidad, NombreFigura)} | " + Idioma.AREA + $" {Area:#.##} | " + Idioma.PERIMETRO + $" {Perimetro:#.##} <br/>" : String.Empty;
        }
        static void Calcular(ref double Area, ref double Perimetro, ref int Cantidad, Figura Figura)
        {
            Area += Figura.CalcularArea();
            Perimetro += Figura.CalcularPerimetro();
            Cantidad++;
        }
        static string Pluralizar(int Cantidad, string Singular)
        {
            return Cantidad > 1 ? Singular + "s" : Singular;
        }        
    }
}

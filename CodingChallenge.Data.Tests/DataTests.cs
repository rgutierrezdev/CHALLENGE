using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using CodingChallenge.Data.CLASES;
using CodingChallenge.Data.MODELOS;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        #region LISTA VACIA - 3 IDIOMAS
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>¡Lista vacía de formas!</h1>",Reporte.Imprimir(new List<Figura>()));
        }
        [TestCase]
        public void TestResumenListaVaciaEnIngles()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Assert.AreEqual("<h1>¡Empty list of shapes!</h1>", Reporte.Imprimir(new List<Figura>()));
        }
        [TestCase]
        public void TestResumenListaVaciaEnFrances()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("FR");
            Assert.AreEqual("<h1>¡Liste vide de formes!</h1>", Reporte.Imprimir(new List<Figura>()));
        }
        #endregion

        #region LISTA CON UN CUADRADO - 3 IDIOMAS
        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var figuras = new List<Figura> {new FiguraCuadrado(5)};
            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25",resumen);
        }
        [TestCase]
        public void TestResumenListaConUnCuadradoEnIngles()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            var figuras = new List<Figura> { new FiguraCuadrado(5) };
            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual("<h1>Shapes report</h1>1 Square | Area 25 | Perimeter 20 <br/>TOTAL:<br/>1 shapes Perimeter 20 Area 25", resumen);
        }
        [TestCase]
        public void TestResumenListaConUnCuadradoEnFrances()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("FR");
            var figuras = new List<Figura> { new FiguraCuadrado(5) };
            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual("<h1>Rapport sur les formes</h1>1 Carré | Région 25 | Périmètre 20 <br/>TOTAL:<br/>1 formes Périmètre 20 Région 25", resumen);
        }
        #endregion

        #region LISTA CON MAS CUADRADOS - 3 IDIOMAS
        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var figuras = new List<Figura> { new FiguraCuadrado(5),
                                             new FiguraCuadrado(1),
                                             new FiguraCuadrado(3)};

            var resumen = Reporte.Imprimir(figuras);            
            Assert.AreEqual("<h1>Reporte de Formas</h1>3 Cuadrados | Area 35 | Perimetro 36 <br/>TOTAL:<br/>3 formas Perimetro 36 Area 35", resumen);
        }
        [TestCase]
        public void TestResumenListaConMasCuadradosEnIngles()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            var figuras = new List<Figura> { new FiguraCuadrado(5),
                                             new FiguraCuadrado(1),
                                             new FiguraCuadrado(3)};

            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }
        [TestCase]
        public void TestResumenListaConMasCuadradosEnFrances()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("FR");
            var figuras = new List<Figura> { new FiguraCuadrado(5),
                                             new FiguraCuadrado(1),
                                             new FiguraCuadrado(3)};

            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual("<h1>Rapport sur les formes</h1>3 Carrés | Région 35 | Périmètre 36 <br/>TOTAL:<br/>3 formes Périmètre 36 Région 35", resumen);
        }
        #endregion

        #region LISTA CON MAS TIPOS - 3 IDIOMAS
        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var figuras = new List<Figura> { new FiguraCuadrado(5),
                                             new FiguraCirculo(3),
                                             new FiguraTrianguloEquilatero(4),
                                             new FiguraCuadrado(2),
                                             new FiguraTrianguloEquilatero(9),
                                             new FiguraCirculo(2.75),
                                             new FiguraTrianguloEquilatero(4.2)};

            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Circulos | Area 13,01 | Perimetro 18,06 <br/>3 Triangulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
        [TestCase]
        public void TestResumenListaConMasTiposEnIngles()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            var figuras = new List<Figura> { new FiguraCuadrado(5),
                                             new FiguraCirculo(3),
                                             new FiguraTrianguloEquilatero(4),
                                             new FiguraCuadrado(2),
                                             new FiguraTrianguloEquilatero(9),
                                             new FiguraCirculo(2.75),
                                             new FiguraTrianguloEquilatero(4.2)};

            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }
        [TestCase]
        public void TestResumenListaConMasTiposEnFrances()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("FR");
            var figuras = new List<Figura> { new FiguraCuadrado(5),
                                             new FiguraCirculo(3),
                                             new FiguraTrianguloEquilatero(4),
                                             new FiguraCuadrado(2),
                                             new FiguraTrianguloEquilatero(9),
                                             new FiguraCirculo(2.75),
                                             new FiguraTrianguloEquilatero(4.2)};

            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual(
                "<h1>Rapport sur les formes</h1>2 Carrés | Région 29 | Périmètre 28 <br/>2 Cercles | Région 13,01 | Périmètre 18,06 <br/>3 Triangles | Région 49,64 | Périmètre 51,6 <br/>TOTAL:<br/>7 formes Périmètre 97,66 Région 91,65",
                resumen);
        }
        #endregion

        #region LISTA CON UN RECTANGULO - 3 IDIOMAS
        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            var figuras = new List<Figura> { new FiguraRectangulo(3,5) };
            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Rectangulo | Area 15 | Perimetro 16 <br/>TOTAL:<br/>1 formas Perimetro 16 Area 15", resumen);
        }
        [TestCase]
        public void TestResumenListaConUnRectanguloEnIngles()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            var figuras = new List<Figura> { new FiguraRectangulo(3, 5) };
            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual("<h1>Shapes report</h1>1 Rectangle | Area 15 | Perimeter 16 <br/>TOTAL:<br/>1 shapes Perimeter 16 Area 15", resumen);
        }
        [TestCase]
        public void TestResumenListaConUnRectanguloEnFrances()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("FR");
            var figuras = new List<Figura> { new FiguraRectangulo(3, 5) };
            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual("<h1>Rapport sur les formes</h1>1 Rectangle | Région 15 | Périmètre 16 <br/>TOTAL:<br/>1 formes Périmètre 16 Région 15", resumen);
        }
        #endregion

        #region LISTA CON UN TRAPECIO - 3 IDIOMAS
        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            var figuras = new List<Figura> { new FiguraTrapecio(10,6,4,5) };
            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 31,22 | Perimetro 25 <br/>TOTAL:<br/>1 formas Perimetro 25 Area 31,22", resumen);
        }
        [TestCase]
        public void TestResumenListaConUnTrapecioEnIngles()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            var figuras = new List<Figura> { new FiguraTrapecio(10, 6, 4, 5) };
            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual("<h1>Shapes report</h1>1 Trapeze | Area 31,22 | Perimeter 25 <br/>TOTAL:<br/>1 shapes Perimeter 25 Area 31,22", resumen);
        }
        [TestCase]
        public void TestResumenListaConUnTrapecioEnFrances()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("FR");
            var figuras = new List<Figura> { new FiguraTrapecio(10, 6, 4, 5) };
            var resumen = Reporte.Imprimir(figuras);
            Assert.AreEqual("<h1>Rapport sur les formes</h1>1 Trapèze | Région 31,22 | Périmètre 25 <br/>TOTAL:<br/>1 formes Périmètre 25 Région 31,22", resumen);
        }
        #endregion
    }
}

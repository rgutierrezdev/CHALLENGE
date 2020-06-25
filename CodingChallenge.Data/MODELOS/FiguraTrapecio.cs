using CodingChallenge.Data.RECURSOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.MODELOS
{
    public class FiguraTrapecio : FiguraCuatroLados
    {
        /// <summary>
        /// LadoA base inferior, LadoB base superior.
        /// </summary>
        /// <param name="LadoA"></param>
        /// <param name="LadoB"></param>
        /// <param name="LadoC"></param>
        /// <param name="LadoD"></param>
        public FiguraTrapecio(double LadoA, double LadoB, double LadoC, double LadoD)
        {
            this.LadoA = LadoA;
            this.LadoB = LadoB;
            this.LadoC = LadoC;
            this.LadoD = LadoD;            
        }
        public override double CalcularArea()
        {
            //FORMULA DE HERON
            var ladoM = (LadoA - LadoB);
            var semiperimetro = (ladoM + LadoC + LadoD) / 2;
            var areaTriangulo = Math.Sqrt(semiperimetro * (semiperimetro - ladoM) * (semiperimetro - LadoC) * (semiperimetro - LadoD));
            var altura = (2 * areaTriangulo) / ladoM;           
            return altura * ((LadoA + LadoB) / 2); 
        }

        public override double CalcularPerimetro()
        {
            return LadoA + LadoB + LadoC + LadoD;
        }

        public override void actualizarTipoFigura()
        {
            this.Tipo_Figura = Idioma.TRAPECIO;
        }
    }
}

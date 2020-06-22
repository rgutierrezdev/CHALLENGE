using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.MODELOS
{
    public class FiguraCuadrado : FiguraCuatroLados
    {
        /// <summary>
        /// Lado representa el valor de cada lado de un cuadrado.
        /// </summary>
        /// <param name="Lado"></param>
        public FiguraCuadrado(double Lado)
        {
            this.LadoA = Lado;
        }
  
        public override double CalcularArea()
        {
            return LadoA * LadoA;
        }

        public override double CalcularPerimetro()
        {
            return LadoA * 4;
        }
    }
}

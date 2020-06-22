using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.MODELOS
{

    public class FiguraRectangulo : FiguraCuatroLados
    {
        /// <summary>
        /// LadoA es la base, LadoB es la altura.
        /// </summary>
        /// <param name="LadoA"></param>
        /// <param name="LadoB"></param>
        public FiguraRectangulo(double LadoA, double LadoB)
        {
            this.LadoA = LadoA;
            this.LadoB = LadoB;
        }

        public override double CalcularArea()
        {
            return LadoA * LadoB;
        }

        public override double CalcularPerimetro()
        {
            return (2 * LadoA) + (2 * LadoB);
        }
    }
}

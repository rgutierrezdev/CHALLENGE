using CodingChallenge.Data.RECURSOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.MODELOS
{
    public class FiguraTrianguloEquilatero : FiguraTresLados 
    {
        /// <summary>
        /// Lado representa el valor de cada lado de un triangulo equilátero.
        /// </summary>
        /// <param name="Lado"></param>
        public FiguraTrianguloEquilatero(double Lado)
        {
            this.LadoA = Lado;            
        }

        public override double CalcularArea()
        {
            return (Math.Sqrt(3) / 4) *Math.Pow(LadoA, 2);
        }

        public override double CalcularPerimetro()
        {
            return 3 * LadoA;
        }

        public override void actualizarTipoFigura()
        {
            this.Tipo_Figura = Idioma.TRIANGULO;
        }
    }
}

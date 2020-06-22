using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.MODELOS
{
    public abstract class FiguraTresLados : Figura
    {
        private double _ladoA;
        private double _ladoB;
        private double _ladoC;

        public double LadoA { get => _ladoA; set => _ladoA = value; }
        public double LadoB { get => _ladoB; set => _ladoB = value; }
        public double LadoC { get => _ladoC; set => _ladoC = value; }
    }
}

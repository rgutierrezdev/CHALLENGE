using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.MODELOS
{
    public abstract class FiguraCuatroLados : FiguraTresLados
    {
        private double ladoD;

        public double LadoD { get => ladoD; set => ladoD = value; }
    }
}

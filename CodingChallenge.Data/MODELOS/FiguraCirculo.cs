using CodingChallenge.Data.RECURSOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.MODELOS
{
    public class FiguraCirculo : Figura
    {
        private double diametro;

        public double Radio { get => diametro; set => diametro = value; }

        public FiguraCirculo(double Radio)
        {
            diametro = Radio;            
        }

        public override double CalcularArea()
        {
            return Math.PI * (Math.Pow(diametro, 2)/4);
        }

        public override double CalcularPerimetro()
        {
            return Math.PI * diametro;
        }

        public override void actualizarTipoFigura()
        {
            this.Tipo_Figura = Idioma.CIRCULO;
        }
    }
}

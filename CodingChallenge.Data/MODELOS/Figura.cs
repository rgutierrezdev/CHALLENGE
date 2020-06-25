using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.MODELOS
{
    public class Figura
    {
        private string tipo_figura;
        public string Tipo_Figura { get => tipo_figura; set => tipo_figura = value; }

        public virtual double CalcularArea()
        {
            return 0;
        }     
        public virtual double CalcularPerimetro()
        {
            return 0;
        }

        public virtual void actualizarTipoFigura()
        {

        }

    }
}

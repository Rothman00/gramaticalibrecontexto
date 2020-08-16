using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_de_gramaticas_Compiladores
{
    class Nodo
    {
        private List<String> expresion;
        private Nodo izq, der, cen;
        private int num;

        public Nodo()
        {
            der = izq = cen = null;
            num = 0;
        }

        public List<string> Expresion { get => expresion; set => expresion = value; }
        public int Num { get => num; set => num = value; }
        internal Nodo Izq { get => izq; set => izq = value; }
        internal Nodo Der { get => der; set => der = value; }
        internal Nodo Cen { get => cen; set => cen = value; }
    }
}

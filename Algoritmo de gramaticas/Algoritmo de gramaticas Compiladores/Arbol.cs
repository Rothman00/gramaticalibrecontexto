using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_de_gramaticas_Compiladores
{
    class Arbol
    {
        private Nodo raiz;

        public Nodo Raiz()
        {
            return raiz;
        }

        public Arbol()
        {
            raiz = null;
        }

        public void insertar(List<String> info)
        {
            Nodo nuevo;
            nuevo = new Nodo();
            nuevo.Expresion = info;
            if (raiz == null)
                raiz = nuevo;
            else
            {
                Queue<Nodo> colaAuxiliar = new Queue<Nodo>();
                colaAuxiliar.Enqueue(raiz);
                while (colaAuxiliar.Count != 0)
                {
                    Nodo nodo = colaAuxiliar.Dequeue();
                    if (nodo != null)
                    {
                        if (nodo.Izq == null && (nodo.Num == 0 || nodo.Num == 1))
                        {
                            nodo.Izq = nuevo;
                            break;
                        }
                        else
                        {
                            if (nodo.Cen == null && (nodo.Num == 0 || nodo.Num == 2))
                            {
                                nodo.Cen = nuevo;
                                break;
                            }
                            else
                            {
                                if (nodo.Der == null && (nodo.Num == 0 || nodo.Num == 3))
                                {
                                    nodo.Der = nuevo;
                                    break;
                                }
                            }
                        }
                            if(!comprobacion(nodo.Izq))
                                colaAuxiliar.Enqueue(nodo.Izq);
                            if (!comprobacion(nodo.Cen))
                                colaAuxiliar.Enqueue(nodo.Cen);
                            if (!comprobacion(nodo.Der))
                                colaAuxiliar.Enqueue(nodo.Der);
                    }
                }
            }
        }

        private bool comprobacion(Nodo aux)
        {
            return aux == null || comprobar(aux);
        }

        public bool comprobar(Nodo aux)
        {
            int cont = 0;
            foreach (String item in aux.Expresion)
            {
                switch (item)
                {
                    case "b":
                    case "d":
                    case "a":
                    case "c": cont++; break;
                }
            }
            return cont == aux.Expresion.Count;
        }

        public bool buscar(String dato)
        {
            buscar(dato, raiz);
            return res;
        }

        private bool res = false;
        private void buscar(String dato, Nodo reco)
        {
            if (reco != null)
            {
                String valor = "";
                foreach (String item in reco.Expresion)
                {
                    valor += item;
                }
                if (valor.Equals(dato))
                {
                    res = true;
                    return;
                }
                if (reco.Izq!=null)
                    buscar(dato, reco.Izq);
                if (reco.Cen!=null)
                    buscar(dato, reco.Cen);
                if (reco.Der!=null)
                    buscar(dato, reco.Der);
            }
        }
    }
}

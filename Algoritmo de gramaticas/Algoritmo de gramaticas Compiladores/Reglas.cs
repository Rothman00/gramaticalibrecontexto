using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_de_gramaticas_Compiladores
{
    class Reglas
    {
        private Arbol arbol;
        private List<String> expresion;
        private String dato;

        public Reglas(String expresion)
        {
            this.arbol = new Arbol();
            convertir(expresion);
            this.dato = expresion;
        }

        private void convertir(String dato)
        {
            this.expresion = new List<string>();
            foreach (char item in dato)
            {
                this.expresion.Add(item + "");
            }
        }

        private List<String> colocar(String nuevo, int posicion, List<String> cadena, bool remp)
        {
            List<String> n = new List<string>();
            if (remp)
            {
                for (int i = 0; i < cadena.Count; i++)
                {
                    if (i == posicion)
                        n.Add(nuevo);
                    else
                        n.Add(cadena[i]);
                }
            }
            else
            {
                for (int i = 0; i < cadena.Count + 1; i++)
                {
                    if (i == posicion)
                        n.Add(nuevo);
                    if (i < cadena.Count)
                        n.Add(cadena[i]);
                }
            }
            return n;
        }

        private List<String> r1(List<String> cadena, int pos)
        {
            if (cadena == null)
            {
                cadena = colocar("A", pos, new List<string>(), false);
                cadena = colocar("S", pos + 1, cadena, false);
                cadena = colocar("B", pos + 2, cadena, false);
            }
            else
            {
                cadena = colocar("A", pos, cadena, true);
                cadena = colocar("S", pos + 1, cadena, false);
                cadena = colocar("B", pos + 2, cadena, false);
            }
            return cadena;
        }

        private List<String> r2(List<String> cadena, int pos)
        {
            return colocar("b", pos, cadena, true);
        }

        private List<String> r3(List<String> cadena, int pos)
        {
            int cont = 0;
            if (pos >= 2)
            {
                for (int i = 0; i < cadena.Count; i++)
                {
                    if (i <= pos)
                    {
                        if (cadena[i].Equals("a"))
                            cont++;
                        else
                        {
                            if (cont >= 2 && cadena[i].Equals("A"))
                            {
                                cadena = colocar("B", pos, cadena, true);
                                return colocar("B", pos + 1, cadena, false);
                            }
                            else
                                cont = 0;
                        }
                    }
                    else
                        break;
                }
            }
            return null;
        }

        private List<String> r4(List<String> cadena, int pos)
        {
            return colocar("d", pos, cadena, true);
        }

        private List<String> r5(List<String> cadena, int pos)
        {
            cadena = colocar("a", pos, cadena, true);
            return colocar("A", pos + 1, cadena, false);
        }

        private List<String> r6(List<String> cadena, int pos)
        {
            cadena = colocar("d", pos, cadena, true);
            cadena = colocar("c", pos + 1, cadena, false);
            return colocar("d", pos + 2, cadena, false);
        }

        private bool grande(List<String> aux)
        {
            if (aux != null)
                return aux.Count > dato.Length;
            else
                return false;
        }

        public bool gramatica()
        {
            List<String> resultado = r1(null, 0);
            arbol.insertar(resultado);
            int paro = 0;
            while (!arbol.buscar(dato))
            {
                bool hecho = false;
                Queue<Nodo> colaAux = new Queue<Nodo>();
                colaAux.Enqueue(arbol.Raiz());
                while (colaAux.Count != 0)
                {
                    Nodo nodo = colaAux.Dequeue();
                    if (nodo != null)
                    {
                        if (!arbol.comprobar(nodo))
                        {
                            switch (letra(nodo))
                            {
                                case "A":
                                    {
                                        if (nodo.Izq == null && (nodo.Num == 0 || nodo.Num == 1))
                                        {
                                            List<String> aux = nuevaLista(nodo, 1);
                                            if (grande(aux))
                                            {
                                                nodo.Num = -1;
                                            }
                                            else
                                            {
                                                arbol.insertar(aux);
                                            }
                                            hecho = true;
                                        }
                                        else
                                        {
                                            if (nodo.Cen == null && (nodo.Num == 0 || nodo.Num == 2))
                                            {
                                                List<String> aux = nuevaLista(nodo, 2);
                                                if (grande(aux))
                                                {
                                                    nodo.Num = -1;
                                                }
                                                else
                                                {
                                                    arbol.insertar(aux);
                                                }
                                                hecho = true;
                                            }
                                            else
                                            {
                                                if (nodo.Der == null && (nodo.Num == 0 || nodo.Num == 3))
                                                {
                                                    List<String> aux = nuevaLista(nodo, 3);
                                                    if (grande(aux))
                                                    {
                                                        nodo.Num = -1;
                                                    }
                                                    else
                                                    {
                                                        if (aux != null)
                                                        {
                                                            arbol.insertar(aux);
                                                            nodo.Num = 3;
                                                        }
                                                        else
                                                            nodo.Num = 2;
                                                    }
                                                    hecho = true;
                                                }
                                            }
                                        }
                                    }; break;
                                case "S":
                                    {
                                        if (nodo.Izq == null && (nodo.Num == 0 || nodo.Num == 1))
                                        {
                                            List<String> aux = nuevaLista(nodo, 1);
                                            if (grande(aux))
                                            {
                                                nodo.Num = -1;
                                            }
                                            else
                                            {
                                                arbol.insertar(aux);
                                            }
                                            hecho = true;
                                        }
                                        else
                                        {
                                            if (nodo.Cen == null && (nodo.Num == 0 || nodo.Num == 2))
                                            {
                                                List<String> aux = nuevaLista(nodo, 2);
                                                if (grande(aux))
                                                {
                                                    nodo.Num = -1;
                                                }
                                                else
                                                {
                                                    arbol.insertar(aux);
                                                    nodo.Num = 2;
                                                }
                                                hecho = true;
                                            }
                                        }
                                    }; break;
                                case "B":
                                    {
                                        if (nodo.Izq == null && (nodo.Num == 0 || nodo.Num == 1))
                                        {
                                            List<String> aux = nuevaLista(nodo, 1);
                                            if (grande(aux))
                                            {
                                                nodo.Num = -1;
                                            }
                                            else
                                            {
                                                arbol.insertar(aux);
                                                nodo.Num = 1;
                                            }
                                            hecho = true;
                                        }
                                    }; break;
                            }
                            if (hecho)
                                break;
                            colaAux.Enqueue(nodo.Izq);
                            colaAux.Enqueue(nodo.Cen);
                            colaAux.Enqueue(nodo.Der);
                        }
                    }
                }
            }
            return true;
        }

        private String letra(Nodo aux)
        {
            foreach (String item in aux.Expresion)
            {
                if (!contContinuar(item))
                    return item;
            }
            return "";
        }

        private List<String> nuevaLista(Nodo aux, int indice)
        {
            for (int i = 0; i < aux.Expresion.Count; i++)
            {
                if (!contContinuar(aux.Expresion[i]))
                {
                    switch (aux.Expresion[i])
                    {
                        case "A":
                            {
                                switch (indice)
                                {
                                    case 1:
                                        {
                                            return r2(aux.Expresion, i);
                                        };
                                    case 2:
                                        {
                                            return r5(aux.Expresion, i);
                                        }
                                    case 3:
                                        {
                                            return r3(aux.Expresion, i);
                                        }
                                }
                            }; break;
                        case "S":
                            {
                                switch (indice)
                                {
                                    case 1:
                                        {
                                            return r1(aux.Expresion, i);
                                        };
                                    case 2:
                                        {
                                            return r4(aux.Expresion, i);
                                        }
                                }
                            }; break;
                        case "B":
                            {
                                return r6(aux.Expresion, i);
                            }
                    }
                }
            }
            return null;
        }

        private bool contContinuar(String e)
        {
            switch (e)
            {
                case "b":
                case "d":
                case "a":
                case "c": return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;

class Program
{
    // Clase Nodo del Árbol Binario
    class Nodo
    {
        public int Valor;
        public Nodo Izquierdo, Derecho;

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = Derecho = null;
        }
    }

    // Clase Árbol Binario de Búsqueda
    class ArbolBinarioBusqueda
    {
        private Nodo raiz;

        public ArbolBinarioBusqueda()
        {
            raiz = null;
        }

        // Insertar un nuevo nodo en el árbol
        public void Insertar(int valor)
        {
            raiz = InsertarRec(raiz, valor);
        }

        private Nodo InsertarRec(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                nodo = new Nodo(valor);
                return nodo;
            }

            if (valor < nodo.Valor)
                nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
            else if (valor > nodo.Valor)
                nodo.Derecho = InsertarRec(nodo.Derecho, valor);

            return nodo;
        }

        // Recorrido Preorden
        public void Preorden()
        {
            Console.Write("Preorden: ");
            PreordenRec(raiz);
            Console.WriteLine();
        }

        private void PreordenRec(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.Valor + " ");
                PreordenRec(nodo.Izquierdo);
                PreordenRec(nodo.Derecho);
            }
        }

        // Recorrido Inorden
        public void Inorden()
        {
            Console.Write("Inorden: ");
            InordenRec(raiz);
            Console.WriteLine();
        }

        private void InordenRec(Nodo nodo)
        {
            if (nodo != null)
            {
                InordenRec(nodo.Izquierdo);
                Console.Write(nodo.Valor + " ");
                InordenRec(nodo.Derecho);
            }
        }

        // Recorrido Postorden
        public void Postorden()
        {
            Console.Write("Postorden: ");
            PostordenRec(raiz);
            Console.WriteLine();
        }

        private void PostordenRec(Nodo nodo)
        {
            if (nodo != null)
            {
                PostordenRec(nodo.Izquierdo);
                PostordenRec(nodo.Derecho);
                Console.Write(nodo.Valor + " ");
            }
        }

        // Buscar un valor en el árbol
        public bool Buscar(int valor)
        {
            List<int> ruta = new List<int>();
            bool encontrado = BuscarRec(raiz, valor, ruta);
            if (encontrado)
            {
                Console.Write($"Ruta de búsqueda para {valor}: ");
                foreach (var v in ruta) Console.Write(v + " ");
                Console.WriteLine();
            }
            return encontrado;
        }

        private bool BuscarRec(Nodo nodo, int valor, List<int> ruta)
        {
            if (nodo == null) return false;

            ruta.Add(nodo.Valor);

            if (nodo.Valor == valor) return true;

            if (valor < nodo.Valor)
                return BuscarRec(nodo.Izquierdo, valor, ruta);
            else
                return BuscarRec(nodo.Derecho, valor, ruta);
        }

        // Encontrar el valor mínimo
        public int Minimo()
        {
            return MinimoRec(raiz);
        }

        private int MinimoRec(Nodo nodo)
        {
            while (nodo.Izquierdo != null)
                nodo = nodo.Izquierdo;
            return nodo.Valor;
        }

        // Encontrar el valor máximo
        public int Maximo()
        {
            return MaximoRec(raiz);
        }

        private int MaximoRec(Nodo nodo)
        {
            while (nodo.Derecho != null)
                nodo = nodo.Derecho;
            return nodo.Valor;
        }

        // Calcular la altura del árbol
        public int Altura()
        {
            return AlturaRec(raiz);
        }

        private int AlturaRec(Nodo nodo)
        {
            if (nodo == null) return 0;
            return 1 + Math.Max(AlturaRec(nodo.Izquierdo), AlturaRec(nodo.Derecho));
        }

        // Contar el número total de nodos
        public int ContarNodos()
        {
            return ContarNodosRec(raiz);
        }

        private int ContarNodosRec(Nodo nodo)
        {
            if (nodo == null) return 0;
            return 1 + ContarNodosRec(nodo.Izquierdo) + ContarNodosRec(nodo.Derecho);
        }

        // Contar el número de nodos hoja
        public int ContarHojas()
        {
            return ContarHojasRec(raiz);
        }

        private int ContarHojasRec(Nodo nodo)
        {
            if (nodo == null) return 0;
            if (nodo.Izquierdo == null && nodo.Derecho == null) return 1;
            return ContarHojasRec(nodo.Izquierdo) + ContarHojasRec(nodo.Derecho);
        }

        // Invertir el árbol
        public void Invertir()
        {
            raiz = InvertirRec(raiz);
        }

        private Nodo InvertirRec(Nodo nodo)
        {
            if (nodo == null) return null;

            Nodo temp = nodo.Izquierdo;
            nodo.Izquierdo = InvertirRec(nodo.Derecho);
            nodo.Derecho = InvertirRec(temp);

            return nodo;
        }

        // Verificar si el árbol es un BST
        public bool EsBST()
        {
            return EsBSTRec(raiz, int.MinValue, int.MaxValue);
        }

        private bool EsBSTRec(Nodo nodo, int min, int max)
        {
            if (nodo == null) return true;

            if (nodo.Valor <= min || nodo.Valor >= max) return false;

            return EsBSTRec(nodo.Izquierdo, min, nodo.Valor) && EsBSTRec(nodo.Derecho, nodo.Valor, max);
        }

        // Balancear el árbol (AVL)
        public void Balancear()
        {
            List<int> valores = new List<int>();
            ObtenerValoresInorden(raiz, valores);
            raiz = ConstruirAVL(valores, 0, valores.Count - 1);
        }

        private void ObtenerValoresInorden(Nodo nodo, List<int> valores)
        {
            if (nodo == null) return;

            ObtenerValoresInorden(nodo.Izquierdo, valores);
            valores.Add(nodo.Valor);
            ObtenerValoresInorden(nodo.Derecho, valores);
        }

        private Nodo ConstruirAVL(List<int> valores, int inicio, int fin)
        {
            if (inicio > fin) return null;

            int medio = (inicio + fin) / 2;
            Nodo nodo = new Nodo(valores[medio]);

            nodo.Izquierdo = ConstruirAVL(valores, inicio, medio - 1);
            nodo.Derecho = ConstruirAVL(valores, medio + 1, fin);

            return nodo;
        }

        // Nivel más profundo con hojas
        public int NivelMasProfundoConHojas()
        {
            return NivelMasProfundoConHojasRec(raiz, 0);
        }

        private int NivelMasProfundoConHojasRec(Nodo nodo, int nivel)
        {
            if (nodo == null) return -1;
            if (nodo.Izquierdo == null && nodo.Derecho == null) return nivel;

            int izq = NivelMasProfundoConHojasRec(nodo.Izquierdo, nivel + 1);
            int der = NivelMasProfundoConHojasRec(nodo.Derecho, nivel + 1);

            return Math.Max(izq, der);
        }
    }

    // Menú principal
    static void Main(string[] args)
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
        int opcion;
        do
        {
            Console.WriteLine("\n--- MENÚ ÁRBOL BINARIO DE BÚSQUEDA ---");
            Console.WriteLine("1. Insertar un valor");
            Console.WriteLine("2. Recorrido Preorden");
            Console.WriteLine("3. Recorrido Inorden");
            Console.WriteLine("4. Recorrido Postorden");
            Console.WriteLine("5. Buscar un valor");
            Console.WriteLine("6. Encontrar Mínimo y Máximo");
            Console.WriteLine("7. Altura del Árbol");
            Console.WriteLine("8. Contar Nodos y Hojas");
            Console.WriteLine("9. Invertir Árbol");
            Console.WriteLine("10. Verificar si es BST");
            Console.WriteLine("11. Balancear Árbol");
            Console.WriteLine("12. Nivel más profundo con hojas");
            Console.WriteLine("13. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el valor entero a insertar: ");
                    int valorInsertar = Convert.ToInt32(Console.ReadLine());
                    arbol.Insertar(valorInsertar);
                    Console.WriteLine($"Valor {valorInsertar} insertado.");
                    break;

                case 2:
                    arbol.Preorden();
                    break;

                case 3:
                    arbol.Inorden();
                    break;

                case 4:
                    arbol.Postorden();
                    break;

                case 5:
                    Console.Write("Ingrese el valor entero a buscar: ");
                    int valorBuscar = Convert.ToInt32(Console.ReadLine());
                    if (arbol.Buscar(valorBuscar))
                        Console.WriteLine($"El valor {valorBuscar} existe en el árbol.");
                    else
                        Console.WriteLine($"El valor {valorBuscar} no existe en el árbol.");
                    break;

                case 6:
                    Console.WriteLine($"Mínimo: {arbol.Minimo()}, Máximo: {arbol.Maximo()}");
                    break;

                case 7:
                    Console.WriteLine($"Altura del árbol: {arbol.Altura()}");
                    break;

                case 8:
                    Console.WriteLine($"Número de nodos: {arbol.ContarNodos()}, Número de hojas: {arbol.ContarHojas()}");
                    break;

                case 9:
                    arbol.Invertir();
                    Console.WriteLine("Árbol invertido.");
                    break;

                case 10:
                    Console.WriteLine($"Es BST: {arbol.EsBST()}");
                    break;

                case 11:
                    arbol.Balancear();
                    Console.WriteLine("Árbol balanceado.");
                    break;

                case 12:
                    Console.WriteLine($"Nivel más profundo con hojas: {arbol.NivelMasProfundoConHojas()}");
                    break;

                case 13:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        } while (opcion != 13);
    }
}
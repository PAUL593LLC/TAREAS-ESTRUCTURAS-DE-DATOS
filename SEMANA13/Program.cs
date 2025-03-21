using System;

namespace CatalogoRevistas
{
    // Clase Nodo para representar cada nodo del árbol binario
    public class Nodo
    {
        public string Titulo { get; set; }
        public Nodo Izquierda { get; set; }
        public Nodo Derecha { get; set; }

        public Nodo(string titulo)
        {
            Titulo = titulo;
            Izquierda = null;
            Derecha = null;
        }
    }

    // Clase Arbol Binario para manejar las operaciones del árbol
    public class ArbolBinario
    {
        public Nodo Raiz { get; private set; }

        public ArbolBinario()
        {
            Raiz = null;
        }

        // Método para insertar un nuevo título en el árbol
        public void Insertar(string titulo)
        {
            Raiz = InsertarRecursivo(Raiz, titulo);
        }

        private Nodo InsertarRecursivo(Nodo nodo, string titulo)
        {
            if (nodo == null)
            {
                return new Nodo(titulo);
            }

            int comparacion = string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase);

            if (comparacion < 0)
            {
                nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, titulo);
            }
            else if (comparacion > 0)
            {
                nodo.Derecha = InsertarRecursivo(nodo.Derecha, titulo);
            }

            return nodo;
        }

        // Método para buscar un título en el árbol (búsqueda recursiva)
        public string Buscar(string titulo)
        {
            return BuscarRecursivo(Raiz, titulo) ? "ENCONTRADO" : "NO ENCONTRADO";
        }

        private bool BuscarRecursivo(Nodo nodo, string titulo)
        {
            if (nodo == null)
            {
                return false;
            }

            int comparacion = string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase);

            if (comparacion == 0)
            {
                return true;
            }

            return comparacion < 0
                ? BuscarRecursivo(nodo.Izquierda, titulo)
                : BuscarRecursivo(nodo.Derecha, titulo);
        }
    }

     class Program
    {
        // Constantes para las opciones del menú
        private const string OPCION_BUSCAR = "1";
        private const string OPCION_SALIR = "2";

        static void Main(string[] args)
        {
            // Crear el árbol binario
            ArbolBinario catalogo = new ArbolBinario();

            // Ingresar 10 títulos al catálogo
            string[] titulos = {
                "Revista de Agronomía",
                "Revista de Tecnología",
                "Revista de Historia",
                "Revista de Arte",
                "Revista de Salud",
                "Revista de Deportes",
                "Revista de Mecánica",
                "Revista de Educación",
                "Revista de Vuelos",
                "Revista de Cultura"
            };

            foreach (string titulo in titulos)
            {
                catalogo.Insertar(titulo);
            }

            Console.WriteLine("¡==================================!");
            Console.WriteLine("¡Bienvenido al catálogo de revistas!");

            // Mostrar menú
            while (true)
            {
                Console.WriteLine("\n--- MENÚ ---");
                Console.WriteLine($"{OPCION_BUSCAR}. BUSCAR EL TITULO DE SU REVISTA");
                Console.WriteLine($"{OPCION_SALIR}. SALIR");
                Console.Write("SELECCIONE UNA OPCIÓN: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case OPCION_BUSCAR:
                        Console.Write("INGRESE QUE TITULO BUSCA: ");
                        string tituloBuscar = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(tituloBuscar))
                        {
                            Console.WriteLine("Error: El título no puede estar vacío.");
                        }
                        else
                        {
                            string resultado = catalogo.Buscar(tituloBuscar);
                            Console.WriteLine(resultado);
                        }
                        break;

                    case OPCION_SALIR:
                        Console.WriteLine("SALIENDO DEL PROGRAMA...");
                        return;

                    default:
                        Console.WriteLine("OPCIÓN NO VÁLIDA. INTENTE NUEVAMENTE.");
                        break;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> catalogo = new List<string>
        {
            "Revista de Agronimia",
            "Revista de Tecnología",
            "Revista de Historia",
            "Revista de Arte",
            "Revista de Salud",
            "Revista de Deportes",
            "Revista de Mecanica",
            "Revista de Educación",
            "Revista de Vuelos",
            "Revista de Cultura"
        };

        Console.WriteLine("BIENVENIDOS A LA BUSQUEDA DE REVISTAS.");
        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. BUSCAR UN TITULO (INTERACTIVO)");
            Console.WriteLine("2. BUSCAR UN TITULO (RECURSIVO)");
            Console.WriteLine("3. SALIR");
            Console.Write("SELECCIONE UNA OPCIÓN: ");
            string opcion = Console.ReadLine() ?? string.Empty; // Manejo de null

            switch (opcion)
            {
                case "1":
                    BusquedaIterativa(catalogo);
                    break;
                case "2":
                    BusquedaRecursiva(catalogo);
                    break;
                case "3":
                    Console.WriteLine("GRACIAS POR USAR NUESTRO SISTEMA. ¡HASTA LUEGO!");
                    return;
                default:
                    Console.WriteLine("OPCIÓN NO VÁLIDA. INTENTE DE NUEVO.");
                    break;
            }
        }
    }

    static void BusquedaIterativa(List<string> catalogo)
    {
        Console.Write("INGRESE EL TITULO QUE DESEA BUSCAR: ");
        string titulo = Console.ReadLine() ?? string.Empty; // Manejo de null

        bool encontrado = false;
        foreach (string revista in catalogo)
        {
            if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                encontrado = true;
                break;
            }
        }

        Console.WriteLine(encontrado ? "ENCONTRADO" : "NO ENCONTRADO");
    }

    static void BusquedaRecursiva(List<string> catalogo)
    {
        Console.Write("INGRESE EL TITULO QUE DESEA BUSCAR: ");
        string titulo = Console.ReadLine() ?? string.Empty; // Manejo de null

        bool encontrado = BuscarRecursivo(catalogo, titulo, 0);
        Console.WriteLine(encontrado ? "ENCONTRADO" : "NO ENCONTRADO");
    }

    static bool BuscarRecursivo(List<string> catalogo, string? titulo, int indice) // Permitir null
    {
        if (indice >= catalogo.Count || titulo == null) // Verificar null
        {
            return false;
        }

        if (catalogo[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        return BuscarRecursivo(catalogo, titulo, indice + 1);
    }
}
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Creamos un conjunto ficticio de 500 ciudadanos
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"CIUDADANO NUMERO: {i}");
        }

        // Creamos un conjunto ficticio de 75 ciudadanos vacunados con Pfizer
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        for (int i = 1; i <= 75; i++)
        {
            vacunadosPfizer.Add($"CIUDADANO NUMERO: {i}");
        }

        // Creamos un conjunto ficticio de 75 ciudadanos vacunados con Astrazeneca
        HashSet<string> vacunadosAstrazeneca = new HashSet<string>();
        for (int i = 51; i <= 125; i++) // Solapamiento parcial con Pfizer
        {
            vacunadosAstrazeneca.Add($"CIUDADANO NUMERO: {i}");
        }

        // Creamos un conjunto de ciudadanos que han recibido ambas vacunas
        HashSet<string> vacunadosAmbas = new HashSet<string>(vacunadosPfizer);
        vacunadosAmbas.IntersectWith(vacunadosAstrazeneca);

        // Calculamos los listados requeridos usando operaciones de conjuntos

        // Listado de ciudadanos que no estan vacunados
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstrazeneca);

        // Listado de ciudadanos que han recibido las dos vacunas
        HashSet<string> dosVacunas = new HashSet<string>(vacunadosAmbas);

        // Listado de ciudadanos que solamente han recibido la vacuna de Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstrazeneca);

        // Listado de ciudadanos que solamente han recibido la vacuna de Astrazeneca
        HashSet<string> soloAstrazeneca = new HashSet<string>(vacunadosAstrazeneca);
        soloAstrazeneca.ExceptWith(vacunadosPfizer);

        // Mostramos los resultados
        Console.WriteLine("LISTADO DE CIUDADANOS QUE NO ESTAN VACUNADOS:");
        foreach (var ciudadano in noVacunados)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine("\nLISTA DE CIUDADANOS QUE HAN RECIBIDO LAS DOS VACUNAS:");
        foreach (var ciudadano in dosVacunas)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine("\nLISTA DE CIUDADANOS QUE SOLO HAN RECIBIDO LA VACUNA DE PFIZER:");
        foreach (var ciudadano in soloPfizer)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine("\nLISTA DE CIUDADANOS QUE SOLO HAN RECIBIDO LA VACUNA DE ASTRAZENECA:");
        foreach (var ciudadano in soloAstrazeneca)
        {
            Console.WriteLine(ciudadano);
        }
    }
}
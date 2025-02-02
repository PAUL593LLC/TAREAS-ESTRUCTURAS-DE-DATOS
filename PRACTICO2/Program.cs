using System;
using System.Collections.Generic;

namespace AsignacionAsientos
{
    // Clase que representa a una persona en la cola
    public class Persona
    {
        public string Nombre { get; set; }
        public int NumeroAsiento { get; set; }

        public Persona(string nombre)
        {
            Nombre = nombre;
            NumeroAsiento = -1; // Al poner -1 indica que no tiene asiento asignado
        }
    }

    // Clase que gestiona la cola de personas y la asignación de asientos
    public class ColaAsientos
    {
        private Queue<Persona> cola;
        private int asientosDisponibles;
        private const int TotalAsientos = 30;

        public ColaAsientos()
        {
            cola = new Queue<Persona>();
            asientosDisponibles = TotalAsientos;
        }

        // Método para agregar una persona a la cola
        public void AgregarPersona(string nombre)
        {
            if (asientosDisponibles > 0)
            {
                Persona persona = new Persona(nombre);
                cola.Enqueue(persona);
                asientosDisponibles--;
                Console.WriteLine($"{nombre} ha sido agregado a la cola.");
            }
            else
            {
                Console.WriteLine("Todos los asientos han sido vendidos.");
            }
        }

        // Método para asignar asientos a las personas en la cola
        public void AsignarAsientos()
        {
            int numeroAsiento = 1;
            while (cola.Count > 0 && numeroAsiento <= TotalAsientos)
            {
                Persona persona = cola.Dequeue();
                persona.NumeroAsiento = numeroAsiento++;
                Console.WriteLine($"{persona.Nombre} ha sido asignado al asiento {persona.NumeroAsiento}.");
            }
        }

        // Método para mostrar la cola actual
        public void MostrarCola()
        {
            Console.WriteLine("Personas en la cola:");
            foreach (var persona in cola)
            {
                Console.WriteLine($"{persona.Nombre} (Asiento: {(persona.NumeroAsiento == -1 ? "No asignado" : persona.NumeroAsiento.ToString())})");
            }
        }
    }

    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            ColaAsientos colaAsientos = new ColaAsientos();

            // Agregar personas a la cola
            colaAsientos.AgregarPersona("Juan");
            colaAsientos.AgregarPersona("Maria");
            colaAsientos.AgregarPersona("Pedro");
            colaAsientos.AgregarPersona("Ana");
            colaAsientos.AgregarPersona("Luis");

            // Mostrar la cola antes de asignar asientos
            colaAsientos.MostrarCola();

            // Asignar asientos
            colaAsientos.AsignarAsientos();

            // Mostrar la cola después de asignar asientos
            colaAsientos.MostrarCola();
        }
    }
}
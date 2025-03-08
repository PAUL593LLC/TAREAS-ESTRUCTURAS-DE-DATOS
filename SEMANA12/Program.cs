using System;
using System.Collections.Generic;
using System.Linq;

namespace TorneoFutbol
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Equipo> equipos = new Dictionary<int, Equipo>();
            int opcion;

            do
            {
                Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
                Console.WriteLine("1. Registrar equipo");
                Console.WriteLine("2. Registrar jugador");
                Console.WriteLine("3. Listar equipos");
                Console.WriteLine("4. Listar jugadores de un equipo");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarEquipo(equipos);
                        break;
                    case 2:
                        RegistrarJugador(equipos);
                        break;
                    case 3:
                        ListarEquipos(equipos);
                        break;
                    case 4:
                        ListarJugadoresEquipo(equipos);
                        break;
                    case 5:
                        Console.WriteLine("¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            } while (opcion != 5);
        }

        static void RegistrarEquipo(Dictionary<int, Equipo> equipos)
        {
            Console.WriteLine("\n--- REGISTRAR EQUIPO ---");
            Console.Write("Nombre del equipo: ");
            string nombre = Console.ReadLine();
            Console.Write("Nombre del entrenador: ");
            string entrenador = Console.ReadLine();

            int id = equipos.Count == 0 ? 1 : equipos.Keys.Max() + 1;
            Equipo nuevoEquipo = new Equipo
            {
                Id = id,
                Nombre = nombre,
                Entrenador = entrenador
            };

            equipos.Add(nuevoEquipo.Id, nuevoEquipo);
            Console.WriteLine($"Equipo '{nombre}' registrado con éxito (ID: {nuevoEquipo.Id})");
        }

        static void RegistrarJugador(Dictionary<int, Equipo> equipos)
        {
            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados. Registre un equipo primero.");
                return;
            }

            Console.WriteLine("\n--- REGISTRAR JUGADOR ---");
            ListarEquipos(equipos);
            Console.Write("Ingrese el ID del equipo: ");
            int equipoId = Convert.ToInt32(Console.ReadLine());

            if (!equipos.TryGetValue(equipoId, out Equipo equipo))
            {
                Console.WriteLine("Equipo no encontrado");
                return;
            }

            if (equipo.Jugadores.Count >= 20)
            {
                Console.WriteLine("El equipo ya tiene el máximo de jugadores (20)");
                return;
            }

            Console.Write("Nombre del jugador: ");
            string nombre = Console.ReadLine();
            Console.Write("Posición (Portero, Defensa, Medio, Delantero): ");
            string posicion = Console.ReadLine();
            Console.Write("Edad: ");
            int edad = Convert.ToInt32(Console.ReadLine());

            Jugador nuevoJugador = new Jugador
            {
                Id = equipo.GetNextJugadorId(),
                Nombre = nombre,
                Posicion = posicion,
                Edad = edad
            };

            if (equipo.Jugadores.Add(nuevoJugador))
            {
                Console.WriteLine($"Jugador '{nombre}' registrado en el equipo '{equipo.Nombre}'");
            }
            else
            {
                Console.WriteLine("Error: Ya existe un jugador con el mismo ID en el equipo.");
            }
        }

        static void ListarEquipos(Dictionary<int, Equipo> equipos)
        {
            Console.WriteLine("\n--- LISTA DE EQUIPOS ---");
            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados");
                return;
            }

            foreach (var equipo in equipos.Values)
            {
                Console.WriteLine($"ID: {equipo.Id} | Nombre: {equipo.Nombre} | Entrenador: {equipo.Entrenador} | Jugadores: {equipo.Jugadores.Count}/20");
            }
        }

        static void ListarJugadoresEquipo(Dictionary<int, Equipo> equipos)
        {
            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados");
                return;
            }

            Console.WriteLine("\n--- LISTAR JUGADORES DE EQUIPO ---");
            ListarEquipos(equipos);
            Console.Write("Ingrese el ID del equipo: ");
            int equipoId = Convert.ToInt32(Console.ReadLine());

            if (!equipos.TryGetValue(equipoId, out Equipo equipo))
            {
                Console.WriteLine("Equipo no encontrado");
                return;
            }

            Console.WriteLine($"\n--- JUGADORES DEL EQUIPO {equipo.Nombre} ---");
            foreach (var jugador in equipo.Jugadores)
            {
                Console.WriteLine($"ID: {jugador.Id} | Nombre: {jugador.Nombre} | Posición: {jugador.Posicion} | Edad: {jugador.Edad}");
            }
        }
    }

    class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Entrenador { get; set; }
        public HashSet<Jugador> Jugadores { get; set; } = new HashSet<Jugador>();
        private int _nextJugadorId = 1;

        public int GetNextJugadorId()
        {
            return _nextJugadorId++;
        }
    }

    class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Posicion { get; set; }
        public int Edad { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Jugador other)
            {
                return this.Id == other.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

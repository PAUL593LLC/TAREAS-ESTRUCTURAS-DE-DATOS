using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    // Diccionario inicial con más palabras
    static Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "time", "tiempo" },
        { "person", "persona" },
        { "year", "año" },
        { "way", "camino/forma" },
        { "day", "día" },
        { "thing", "cosa" },
        { "man", "hombre" },
        { "world", "mundo" },
        { "life", "vida" },
        { "hand", "mano" },
        { "part", "parte" },
        { "child", "niño/a" },
        { "eye", "ojo" },
        { "woman", "mujer" },
        { "place", "lugar" },
        { "work", "trabajo" },
        { "week", "semana" },
        { "case", "caso" },
        { "point", "punto/tema" },
        { "government", "gobierno" },
        { "company", "empresa/compañía" },
        { "house", "casa" },
        { "car", "coche" },
        { "dog", "perro" },
        { "cat", "gato" },
        { "sun", "sol" },
        { "moon", "luna" },
        { "water", "agua" },
        { "fire", "fuego" },
        { "tree", "árbol" },
        { "flower", "flor" },
        { "book", "libro" },
        { "school", "escuela" },
        { "friend", "amigo" },
        { "family", "familia" },
        { "city", "ciudad" },
        { "country", "país" },
        { "food", "comida" },
        { "money", "dinero" },
        { "love", "amor" },
        { "heart", "corazón" },
        { "head", "cabeza" },
        { "foot", "pie" },
        { "arm", "brazo" },
        { "leg", "pierna" },
        { "sky", "cielo" },
        { "earth", "tierra" },
        { "sea", "mar" },
        { "river", "río" },
        { "mountain", "montaña" },
        { "road", "camino" },
        { "door", "puerta" },
        { "window", "ventana" },
        { "table", "mesa" },
        { "chair", "silla" },
        { "phone", "teléfono" },
        { "computer", "computadora" },
        { "music", "música" },
        { "film", "película" },
        { "game", "juego" },
        { "sport", "deporte" },
        { "team", "equipo" },
        { "player", "jugador" },
        { "teacher", "profesor" },
        { "student", "estudiante" },
        { "doctor", "médico" },
        { "nurse", "enfermera" },
        { "lawyer", "abogado" },
        { "police", "policía" },
        { "soldier", "soldado" },
        { "king", "rey" },
        { "queen", "reina" },
        { "prince", "príncipe" },
        { "princess", "princesa" }
    };

    static void Main(string[] args)
    {
        Console.WriteLine("Cargando diccionario completo desde archivo...");
        LoadDictionaryFromFile("dictionary.txt");

        int option;
        do
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1. TRADUCIR UNA FRASE: ");
            Console.WriteLine("2. INGRESAR MAS PALABRAS AL DICCIONARIO: ");
            Console.WriteLine("0. SALIR: ");
            Console.Write("SELECCIONE UNA OPCION: ");

            // Manejo seguro de la entrada del usuario
            while (!int.TryParse(Console.ReadLine(), out option) || option < 0 || option > 2)
            {
                Console.WriteLine("OPCIÓN NO VALIDA. INTENTE DE NUEVO.");
            }

            switch (option)
            {
                case 1:
                    TranslatePhrase();
                    break;
                case 2:
                    AddWordsToDictionary();
                    break;
                case 0:
                    Console.WriteLine("SALIENDO DEL PROGRAMA...");
                    break;
            }
            Console.WriteLine();
        } while (option != 0);

        // Guardar el diccionario actualizado al salir
        SaveDictionaryToFile("dictionary.txt");
    }

    static void TranslatePhrase()
    {
        Console.Write("INGRESE LA FRASE A TRADUCIR: ");
        string phrase = Console.ReadLine();

        // Dividir la frase en palabras
        string[] words = phrase.Split(' ');
        List<string> translatedWords = new List<string>();

        foreach (string word in words)
        {
            // Verificar si la palabra existe en el diccionario
            if (dictionary.ContainsKey(word))
            {
                translatedWords.Add(dictionary[word]);
            }
            else if (dictionary.ContainsValue(word))
            {
                // Buscar la clave correspondiente al valor
                var entry = dictionary.FirstOrDefault(x => x.Value.Equals(word, StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrEmpty(entry.Key))
                {
                    translatedWords.Add(entry.Key);
                }
                else
                {
                    translatedWords.Add(word); // Mantener la palabra original
                }
            }
            else
            {
                // Si no se encuentra, mantener la palabra original
                translatedWords.Add(word);
            }
        }

        // Unir las palabras traducidas en una frase
        string translatedPhrase = string.Join(" ", translatedWords);
        Console.WriteLine($"SU FRASE TRADUCIDA ES: {translatedPhrase}");
    }

    static void AddWordsToDictionary()
    {
        Console.Write("INGRESE LA PALABRA EN INGLES: ");
        string englishWord = Console.ReadLine().Trim();
        Console.Write("INGRESE LA TRADUCIÓN EN ESPAÑOL: ");
        string spanishWord = Console.ReadLine().Trim();

        // Agregar la palabra al diccionario
        dictionary[englishWord] = spanishWord;
        Console.WriteLine("PALABRA AGREGADA CORRECTAMENTE AL DICCIONARIO.");
    }

    static void LoadDictionaryFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string englishWord = parts[0].Trim();
                        string spanishWord = parts[1].Trim();
                        dictionary[englishWord] = spanishWord;
                    }
                }
                Console.WriteLine($"Diccionario cargado exitosamente. Total de palabras: {dictionary.Count}");
            }
            else
            {
                Console.WriteLine("El archivo de diccionario no existe. Usando diccionario inicial.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar el diccionario: {ex.Message}");
        }
    }

    static void SaveDictionaryToFile(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var entry in dictionary)
                {
                    writer.WriteLine($"{entry.Key}:{entry.Value}");
                }
            }
            Console.WriteLine("Diccionario guardado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar el diccionario: {ex.Message}");
        }
    }
}
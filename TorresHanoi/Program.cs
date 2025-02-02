using System;

class TowersOfHanoi
{
    static void Main(string[] args)
    {
        int n = 3; // Número de discos
        Console.WriteLine("Movimientos para resolver las Torres de Hanoi:");
        SolveHanoi(n, 'A', 'C', 'B'); // A: origen, C: destino, B: auxiliar
    }
// funcion que implementa el numero de discos que hay que mover
    static void SolveHanoi(int n, char source, char target, char auxiliary) 
    {
        if (n == 1)
        {
            Console.WriteLine($"Mover disco 1 de {source} a {target}");
            return;
        }
        // tres pasos principales para mover n discos de la torre de origen a la torre de destino 
        SolveHanoi(n - 1, source, auxiliary, target);
        Console.WriteLine($"Mover disco {n} de {source} a {target}");
        SolveHanoi(n - 1, auxiliary, target, source);
    }
}

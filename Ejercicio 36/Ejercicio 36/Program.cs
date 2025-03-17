using System;
using System.Collections.Generic;


public class Ejercicio36
{
    public static void Main()
    {
        Console.Write("Ingrese ubicación de los frutos: ");
        string fru = Console.ReadLine();

        Console.Write("Ingrese posición inicial del caballo: ");
        string cab = Console.ReadLine();

        Console.Write("Ingrese los movimientos del caballo: ");
        string mov = Console.ReadLine();

        // PROCESO
        // Ubicar los frutos en el tablero
        char[,] tab = new char[8, 8];
        for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                tab[i, j] = ' ';

        string[] frutos = fru.Split(',');
        foreach (string fruta in frutos)
        {
            if (fruta.Length >= 3)
            {
                char col = fruta[0];
                char fil = fruta[1];
                char ele = fruta[2];
                tab[Ef(fil), Ec(col)] = ele;
            }
        }

        // Ubicación del caballo
        char colCab = cab[0];
        char filCab = cab[1];
        int posFil = Ef(filCab);
        int posCol = Ec(colCab);
        string cosecha = "";

        if (tab[posFil, posCol] != ' ')
        {
            cosecha += tab[posFil, posCol];
            tab[posFil, posCol] = ' ';
        }

        // Recorrer los movimientos del caballo
        string[] movimientos = mov.Split(',');
        foreach (string movimiento in movimientos)
        {
            switch (movimiento)
            {
                case "UL": posFil -= 2; posCol -= 1; break;
                case "UR": posFil -= 2; posCol += 1; break;
                case "LU": posFil -= 1; posCol -= 2; break;
                case "LD": posFil += 1; posCol -= 2; break;
                case "RU": posFil -= 1; posCol += 2; break;
                case "RD": posFil += 1; posCol += 2; break;
                case "DL": posFil += 2; posCol -= 1; break;
                case "DR": posFil += 2; posCol += 1; break;
            }

            if (posFil >= 0 && posFil < 8 && posCol >= 0 && posCol < 8 && tab[posFil, posCol] != ' ')
            {
                cosecha += tab[posFil, posCol];
                tab[posFil, posCol] = ' ';
            }
        }

        Console.WriteLine("Los frutos recogidos son: " + cosecha);
    }

    public static int Ef(char f)
    {
        return f switch
        {
            '8' => 0,
            '7' => 1,
            '6' => 2,
            '5' => 3,
            '4' => 4,
            '3' => 5,
            '2' => 6,
            _ => 7,
        };
    }

    public static int Ec(char f)
    {
        return f switch
        {
            'A' => 0,
            'B' => 1,
            'C' => 2,
            'D' => 3,
            'E' => 4,
            'F' => 5,
            'G' => 6,
            'H' => 7,
            _ => -1,
        };
    }
}
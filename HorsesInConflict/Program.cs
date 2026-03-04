using System;
using System.Collections.Generic;

class Program
{
    static int ColANumero(char col)
    {
        return char.ToUpper(col) - 'A' + 1; // A=1, B=2, ..., H=8
    }

    static bool SonConflicto(string pos1, string pos2)
    {
        int col1 = ColANumero(pos1[0]);
        int fila1 = int.Parse(pos1[1].ToString());
        int col2 = ColANumero(pos2[0]);
        int fila2 = int.Parse(pos2[1].ToString());

        int dc = Math.Abs(col1 - col2);
        int df = Math.Abs(fila1 - fila2);

        return (dc == 1 && df == 2) || (dc == 2 && df == 1);
    }

    static void Main()
    {
        Console.Write("Ingrese ubicación de los caballos: ");
        string entrada = Console.ReadLine();

        // Separar por coma y limpiar espacios
        string[] caballos = entrada.Split(',');
        for (int i = 0; i < caballos.Length; i++)
            caballos[i] = caballos[i].Trim();

        // Analizar cada caballo
        for (int i = 0; i < caballos.Length; i++)
        {
            string caballo = caballos[i];

            // Formato de salida: número primero, luego letra (B7 -> 7B)
            string posOut = "" + caballo[1] + caballo[0];

            // Buscar conflictos con todos los demás
            List<string> conflictos = new List<string>();
            for (int j = 0; j < caballos.Length; j++)
            {
                if (i != j && SonConflicto(caballo, caballos[j]))
                {
                    string otro = caballos[j];
                    conflictos.Add("" + otro[1] + otro[0]);
                }
            }

            // Imprimir resultado
            Console.Write("Analizando Caballo en " + posOut + " =>");

            conflictos.Sort();
            conflictos.Reverse();

            for (int k = 0; k < conflictos.Count; k++)
            {
                Console.Write(" Conflicto con " + conflictos[k]);
            }

            Console.WriteLine();
        }
    }
}

using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese la viga: ");
        string viga = Console.ReadLine();

        if (string.IsNullOrEmpty(viga)) return;

        // 1. Capacidad de la base
        int capacidad = 0;
        char baseTipo = viga[0];

        if (baseTipo == '%') capacidad = 10;
        else if (baseTipo == '&') capacidad = 30;
        else if (baseTipo == '#') capacidad = 90;
        else
        {
            Console.WriteLine("La viga está mal construida!");
            return;
        }

        // 2. Variables de cálculo
        int pesoTotalConexiones = 0;   // acumula el peso de todas las conexiones
        int contadorLargueros = 0;     // posición dentro de la secuencia actual
        bool ultimaFueConexion = false;

        for (int i = 1; i < viga.Length; i++)
        {
            char c = viga[i];

            if (c == '=')
            {
                contadorLargueros++;          // el larguero en posición N pesa N unidades
                ultimaFueConexion = false;
            }
            else if (c == '*')
            {
                // Validación: no dos conexiones seguidas, ni conexión sin largueros previos
                if (ultimaFueConexion || contadorLargueros == 0)
                {
                    Console.WriteLine("La viga está mal construida!");
                    return;
                }

                // La conexión pesa el doble del último larguero de la secuencia anterior
                int pesoConexion = contadorLargueros * 2;
                pesoTotalConexiones += pesoConexion;

                // Reiniciamos la secuencia de largueros
                contadorLargueros = 0;
                ultimaFueConexion = true;
            }
            else
            {
                Console.WriteLine("La viga está mal construida!");
                return;
            }
        }

        // 3. Verificación de resistencia: la base soporta la suma de todas las conexiones
        if (pesoTotalConexiones <= capacidad)
            Console.WriteLine("La viga soporta el peso!");
        else
            Console.WriteLine("La viga NO soporta el peso!");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace ConsoleApp3
{
    class Program
    {
        int[,] grafo;
        public int n = 20;
        int[] distancias, camino;
        bool[] visitados;

        void dijkstra()
        {

            distancias = new int[n];
            Console.WriteLine("NODO INICIAL");
            int nodoInicial = Convert.ToInt16(Console.ReadLine());
            Queue cola = new Queue();
            cola.Enqueue(nodoInicial);
            int visitando = nodoInicial;
            while (cola.Count != 0)
            {
                visitados[visitando] = true;
                for (int i = 0; i <= n - 1; i++)
                {
                    if (grafo[visitando, i] != -1)
                    {
                        if (distancias[i] != -1 && distancias[i] > distancias[visitando] + grafo[visitando, i])
                        {
                            cola.Enqueue(i);
                            distancias[i] = distancias[visitando] + grafo[visitando, i];
                            camino[i] = visitando;
                        }
                    }
                }
            }


        }
        void inicializarTodo()
        {
            visitados = new bool[n];
            distancias = new int[n];
            camino = new int[n];

            for (int i = 0; i < distancias.Length; i++)
            {
                distancias[i] = -1;
                visitados[i] = false;
                camino[i] = 0;
            }
        }
        public void mostrarCamino()
        {
            for (int i = 0; i <= camino.Length - 1; i++)
            {
                Console.Write(camino[i] + "\t");
                Console.Write(distancias[i] + "\n");
            }
        }
        public void inicioGrafo()
        {
            grafo = new int[20, 20];
            int origen, destino, costo, N;
            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = 0; j <= n - 1; j++)
                {
                    grafo[i, j] = -1;
                    Console.WriteLine(j);
                }
            }
            Console.WriteLine("Cuantas conexiones tienes??");
            N = Convert.ToInt16(Console.ReadLine());


            for (int i = 0; i <= N; i++)
            {
                Console.WriteLine("Nodo Origen");
                origen = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Nodo Destino");
                destino = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Distancia o Costo");
                costo = Convert.ToInt16(Console.ReadLine());
                grafo[origen, destino] = costo;
            }
        }

        public void mostrar()
        {
            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = 0; j <= n - 1; j++)
                {
                    Console.Write(grafo[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Program G = new Program();
            G.inicioGrafo();
            G.mostrar();
            G.inicializarTodo();
            G.dijkstra();
            G.mostrarCamino();
            Console.ReadKey();

        }
    }
}
        

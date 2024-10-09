namespace AlgsPlayground;

class DijkstraAlgorithm
{
    static void Main()
    {
        // Буквенные ноды
        char[] nodes = { 'A', 'B', 'C', 'D', 'E', 'F' };

        // Матрица смежности для представления графа
        int[,] graph = new int[,]
        {
            { 0, 2, 0, 0, 0, 5 },
            { 0, 0, 4, 1, 0, 0 },
            { 0, 0, 0, 0, 3, 0 },
            { 0, 0, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0 }
        };

        // Найти кратчайшие пути от вершины 0 до всех остальных
        Dijkstra(graph, 0, nodes);
    }

    // Функция для нахождения вершины с минимальным расстоянием
    static int MinDistance(int[] dist, bool[] sptSet, int z)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < z; v++)
        {
            if (!sptSet[v] && dist[v] < min)
            {
                min      = dist[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    // Функция для вывода результатов с буквенными нодами
    static void PrintSolution(int[] dist, int v, char[] nodes)
    {
        Console.WriteLine("Нода \t Расстояние от источника \t Путь");

        for (int i = 0; i < v; i++)
        {
            Console.Write($"{nodes[i]} \t\t {dist[i]} \t\t\t ");
            PrintPath(0, i, nodes);
            Console.WriteLine();
        }
    }

    // Функция для вывода пути от источника до конечной ноды
    static void PrintPath(int src, int j, char[] nodes)
    {
        if (j == src)
        {
            Console.Write($"{nodes[src]} ");
            return;
        }

        PrintPath(src, j / 10, nodes);
        Console.Write($"{nodes[j % 10]} ");
    }

    // Реализация алгоритма Дейкстры
    static void Dijkstra(int[,] graph, int src, char[] nodes)
    {
        var    nodesLength = nodes.Length;
        int[]  dist        = new int[nodesLength];  // Расстояние от источника до i-й вершины
        bool[] sptSet      = new bool[nodesLength]; // Вершины, уже включенные в кратчайший путь

        // Инициализация расстояний и флага посещения вершин
        for (int i = 0; i < nodesLength; i++)
        {
            dist[i]   = int.MaxValue;
            sptSet[i] = false;
        }

        // Расстояние от источника до самого себя всегда равно 0
        dist[src] = 0;

        // Найти кратчайший путь для всех вершин
        for (int count = 0; count < nodesLength - 1; count++)
        {
            int u = MinDistance(dist, sptSet, nodesLength); // Выбрать вершину с минимальным расстоянием
            sptSet[u] = true;

            for (int v = 0; v < nodesLength; v++)
            {
                // Обновить расстояние, если текущий путь короче
                if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                {
                    dist[v] = dist[u] + graph[u, v];
                }
            }
        }

        // Вывести результаты
        PrintSolution(dist, nodesLength, nodes);
    }
}
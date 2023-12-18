var uncycleGraph = new Dictionary<long, IList<long>>
{
    { 1, new List<long> { 2, 3 } },
    { 2, new List<long> { 4 } },
    { 3, new List<long> { 5 } },
    { 4, new List<long> { 5, 6 } },
    { 5, new List<long> { 6 } },
    { 6, new List<long> { 7 } }
};

// Console.WriteLine(Graph.BreadthSearchOfUncycleGraph(uncycleGraph, 7, 1));

var heavyGraph = new Dictionary<long, IDictionary<long, long>>
{
    { 1, new Dictionary<long, long> { { 2, 2 }, { 3, 1 } } },
    { 2, new Dictionary<long, long> { { 6, 7 } } },
    { 3, new Dictionary<long, long> { { 4, 5 }, { 5, 2 } } },
    { 4, new Dictionary<long, long> { { 6, 2 } } },
    { 5, new Dictionary<long, long> { { 6, 1 } } },
    { 6, new Dictionary<long, long> { { 7, 1 } } },
    { 7, new Dictionary<long, long>() },
};

// var dijkstraResult = Graph.Dijkstra(heavyGraph, 1, 7);
//
// foreach (var row in dijkstraResult)
// {
//     Console.WriteLine($"{row.Key} : {row.Value}");
// }

static void Dijkstra(int[,] graph)
{
    var    V                = graph.GetLength(0);
    int[]  distance         = new int[V];  // Расстояние от источника до i-й вершины
    bool[] shortestIncluded = new bool[V]; // Вершины, уже включенные в кратчайший путь

    // Инициализация расстояний и флага посещения вершин
    for (int i = 0; i < V; i++)
    {
        distance[i]         = int.MaxValue;
        shortestIncluded[i] = false;
    }

    // Расстояние от источника до самого себя всегда равно 0
    distance[0] = 0;

    // Найти кратчайший путь для всех вершин
    for (int count = 0; count < V - 1; count++)
    {
        int u = MinDistance(distance, shortestIncluded, V); // Выбрать вершину с минимальным расстоянием
        shortestIncluded[u] = true;

        for (int v = 0; v < V; v++)
        {
            // Обновить расстояние, если текущий путь короче
            if (!shortestIncluded[v]
                && graph[u, v] != 0
                && distance[u] != int.MaxValue
                && distance[u] + graph[u, v] < distance[v])
            {
                distance[v] = distance[u] + graph[u, v];
            }
        }
    }

    // Вывести результаты
    PrintSolution(distance, V);
}

static void PrintSolution(int[] dist, int V)
{
    Console.WriteLine("Вершина \t Расстояние от источника");

    for (int i = 0; i < V; i++)
    {
        Console.WriteLine($"{i} \t\t {dist[i]}");
    }
}

static int MinDistance(int[] dist, bool[] sptSet, int V)
{
    int min = int.MaxValue, minIndex = -1;

    for (int v = 0; v < V; v++)
    {
        if (!sptSet[v] && dist[v] < min)
        {
            min      = dist[v];
            minIndex = v;
        }
    }

    return minIndex;
}

// Матрица смежности для представления графа
int[,] graph =
{
    { 0, 2, 0, 0, 0, 5 },
    { 0, 0, 4, 1, 0, 0 },
    { 0, 0, 0, 0, 3, 0 },
    { 0, 0, 0, 0, 0, 1 },
    { 0, 0, 0, 0, 0, 0 },
    { 0, 0, 0, 0, 0, 0 }
};

// Количество вершин в графе

// Найти кратчайшие пути от вершины 0 до всех остальных
Dijkstra(graph, 0);
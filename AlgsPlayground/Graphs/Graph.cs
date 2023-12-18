namespace AlgsPlayground.Graphs;

public class Graph
{
    public static bool BreadthSearchOfUncycleGraph(IDictionary<long, IList<long>> graph, long start, long end)
    {
        var queue = new Queue<long>();
        queue.Enqueue(start);
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (!graph.ContainsKey(current))
            {
                graph[current] = new List<long>();
            }

            if (graph[current].Contains(end))
            {
                return true;
            }

            foreach (var element in graph[current])
            {
                queue.Enqueue(element);
            }
        }

        return false;
    }
    
    public static IDictionary<long, long> Dijkstra(IDictionary<long, IDictionary<long, long>> graph, long start, long end)
    {
        var        costs      = new Dictionary<long, long>();
        var        processed  = new List<long>();

        foreach (var currentKey in graph.Keys)
        {
            if (currentKey != start)
            {
                long value;
                if (graph[start].TryGetValue(currentKey, out value))
                {
                    costs[currentKey] = value;
                }

                costs[currentKey] = graph[start].TryGetValue(currentKey, out value) ? value : 99999999999;
            }
        }

        var node = FindLowestCostNode(costs, processed);
        
        while (node is not null)
        {
            var        cost       = costs[node.Value];
            var neighbours = graph[node.Value].Keys.ToList();

            foreach (var neighbour in neighbours)
            {
                var newCost = cost + neighbours[(int)neighbour];
                if (newCost < costs[neighbour])
                {
                    costs[neighbour] = newCost;
                }
            }
            processed.Add(node.Value);
            node = FindLowestCostNode(costs, processed);
        }

        return costs;
    }

    private static long? FindLowestCostNode(IDictionary<long, long> costs, IList<long> proceed)
    {
        var lowestCost = 99999999999;

        long? lowestNode = null;

        foreach (var node in costs)
        {
            if (node.Value < lowestCost && !proceed.Contains(node.Key))
            {
                lowestCost = node.Value;
                lowestNode = node.Key;
            }
        }

        return lowestNode;
    }
}
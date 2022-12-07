using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GraphLibrary
{
    public static class GraphHelper
    {
        public static int CalculateInclinationDegree(GraphAdjacentList<int> adjacentList, int name)
        {
            int degree = 0;
            foreach (var kvp in adjacentList._adjList)
            {
                foreach (var node in kvp.Value)
                {
                    if (node.Key == name)
                    {
                        degree++;
                    }
                }
            }

            return degree;
        }

        public static int CalculateOutcomeDegree(GraphAdjacentList<int> adjacentList, int name)
        {
            return adjacentList._adjList[name].Count;
        }

        public static List<int> FindIsolatedNodes(GraphAdjacentList<int> adjacentList)
        {
            var isolatedNodes = new List<int>();
            foreach (var node in adjacentList._adjList)
            {
                if (CalculateInclinationDegree(adjacentList, node.Key) == 0
                    && CalculateOutcomeDegree(adjacentList, node.Key) == 0)
                {
                    isolatedNodes.Add(node.Key);
                }
            }

            return isolatedNodes;
        }

        public static void UnionDirectedGraphs(GraphAdjacentList<int> adj1,
            GraphAdjacentList<int> adj2, int weight)
        {
            var maxKey1 = adj1._adjList.Keys.Max();
            var minKey2 = adj2._adjList.Keys.Min();

            adj1._adjList[maxKey1].Add(minKey2, weight);
            adj2._adjList[minKey2].Add(maxKey1, weight);

            foreach (var kvp in adj2._adjList)
            {
                Dictionary<int, int> related = new Dictionary<int, int>();
                foreach (var val in kvp.Value)
                {
                    related.Add(val.Key, val.Value);
                }
                //graphNodes.Add(new GraphNode<int>
                //{
                //    Name = kvp.Key,
                //    Related = related
                //});
                adj1._adjList.Add(kvp.Key, related);
            }
        }

        //private static void DFSHelper(int nodeName, List<int> visited, GraphAdjacentList<int> adjList, List<int> vNodes)
        //{
        //    if (visited.Contains(nodeName))
        //    {
        //        return;
        //    }

        //    visited.Add(nodeName);
        //    var nList = adjList._adjList[nodeName];
        //    foreach (var node in nList)
        //    {
        //        vNodes.Add(node.Key);
        //        DFSHelper(node.Key, visited, adjList, vNodes);
        //    }
        //}

        //public static List<int> DFS(GraphAdjacentList<int> adjList, int nodeName)
        //{
        //    var visitedNodes = new List<int>();
        //    var vNodes = new List<int>();
        //    DFSHelper(nodeName, visitedNodes, adjList, vNodes);

        //    return vNodes;
        //}

        public static bool IsCyclicGraph(int nodeName, GraphAdjacentList<int> adjList, List<int> color)
        {
            color[nodeName - 1] = 1;
            foreach (var node in adjList._adjList[nodeName])
            {
                int start = node.Key;
                if (color[start - 1] == 0)
                {
                    if (IsCyclicGraph(start, adjList, color))
                    {
                        return true;
                    }
                }
                else if (color[start - 1] == 1)
                {
                    return true;
                }
            }

            color[nodeName - 1] = 2;
            return false;
        }

        private static void DFSHelper(int nodeName, List<bool> marked, List<int> order, GraphAdjacentList<int> adj)
        {
            marked[nodeName - 1] = true;
            foreach (var node in adj._adjList[nodeName])
            {
                if (!marked[node.Key - 1])
                {
                    DFSHelper(node.Key, marked, order, adj);
                }
            }
            order.Add(nodeName);
        }

        private static void DFSTransponseHelper(int nodeName, List<bool> marked, List<int> components, GraphAdjacentList<int> adj)
        {
            marked[nodeName - 1] = true;
            components.Add(nodeName);
            foreach (var node in adj._adjList[nodeName])
            {
                if (!marked[node.Key - 1])
                {
                    DFSHelper(node.Key, marked, components, adj);
                }
            }
        }

        public static Graph<int> TransposeGraph(GraphAdjacentList<int> adjList)
        {
            var transposeGraph = new Graph<int>(true, true);
            for (int i = 0; i < adjList._adjList.Count; i++)
            {
                transposeGraph.AddNode(new GraphNode<int>
                {
                    Name = i + 1,
                    Related = new Dictionary<int, int>()
                });
            }
            foreach (var kvp in adjList._adjList)
            {
                foreach (var node in kvp.Value)
                {
                    transposeGraph.AddEdge(node.Key, kvp.Key, node.Value);
                }
            }

            return transposeGraph;
        }

        public static List<List<int>> GetStronglyConnectedComponents(GraphAdjacentList<int> adjList)
        {
            List<int> components = new List<int>();
            var compCopy = new List<List<int>>();
            var transposeGraph = TransposeGraph(adjList);

            var order = new List<int>();
            var marked = new List<bool>(Enumerable.Repeat(false, adjList._adjList.Count));
            for (int i = 0; i < adjList._adjList.Count; i++)
            {
                if (!marked[i])
                {
                    DFSHelper(i + 1, marked, order, adjList);
                }
            }

            marked.Clear();
            marked.AddRange(Enumerable.Repeat(false, adjList._adjList.Count));
            for (int i = 0; i < adjList._adjList.Count; i++)
            {
                int v = order[marked.Count - 1 - i];
                if (!marked[v - 1])
                {
                    DFSTransponseHelper(v + 1, marked, components, transposeGraph.AdjacentList);
                    if (components.Count > 1)
                    {
                        compCopy.Add(new List<int>());
                        foreach (var node in components)
                        {
                            compCopy[compCopy.Count - 1].Add(node);
                        }
                    }
                    components.Clear();
                }
            }

            return compCopy;
        }

        private static int FindSet(int v, List<int> parent)
        {
            if (v == parent[v - 1])
            {
                return v;
            }
            return parent[v - 1] = FindSet(parent[v - 1], parent);
        }

        private static void UnionSets(int a, int b, List<int> parent, List<int> rank)
        {
            a = FindSet(a, parent);
            b = FindSet(b, parent);

            if (a != b)
            {
                if (rank[a - 1] < rank[b - 1])
                {
                    (a, b) = (b, a);
                }
                parent[b - 1] = a;
                if (rank[a - 1] == rank[b - 1])
                {
                    rank[a - 1]++;
                }
            }
        }

        public static Dictionary<string, GraphEdge<int>> Kruskal(Graph<int> graph)
        {
            var parent = new List<int>(Enumerable.Range(1, graph.AdjacentList._adjList.Count));
            var rank = new List<int>(Enumerable.Repeat(0, graph.AdjacentList._adjList.Count));
            var result = new Dictionary<string, GraphEdge<int>>();

            graph.CreateEdgeList();
            var sortedEdges = graph.EdgeList.OrderBy(e => e.Value.Weight);

            foreach (var edge in sortedEdges)
            {
                if (FindSet(edge.Value.Node1, parent) != FindSet(edge.Value.Node2, parent))
                {
                    result.Add(edge.Key, edge.Value);
                    UnionSets(edge.Value.Node1, edge.Value.Node2, parent, rank);
                }
            }

            return result;
        }

        public static List<int> Dijkstra(GraphAdjacentList<int> adjList, int start)
        {
            var len = adjList._adjList.Count;
            var distances = new List<int>(Enumerable.Repeat(int.MaxValue, len));
            distances[start - 1] = 0;
            var t = new List<bool>(Enumerable.Repeat(false, len));
            var p = new List<int>(Enumerable.Repeat(int.MaxValue, len));

            for (int i = 0; i < len; i++)
            {
                var min = int.MaxValue;
                var cur = 0;
                for (int j = 0; j < len; j++)
                {
                    if (distances[j] < min && !t[j])
                    {
                        min = distances[j];
                        cur = j;
                    }
                }
                t[cur] = true;

                foreach (var kvp in adjList._adjList[cur + 1])
                {
                    var nodeIndex = kvp.Key - 1;
                    if (distances[cur] + kvp.Value < distances[nodeIndex])
                    {
                        distances[nodeIndex] = distances[cur] + kvp.Value;
                        p[nodeIndex] = cur;
                    }
                }
            }

            return distances;
        }

        public static List<List<int>> Floyd(GraphAdjacentList<int> adjList)
        {
            var len = adjList._adjList.Count;
            var distances = new List<List<int>>();
            for (int i = 0; i < len; i++)
            {
                distances.Add(new List<int>(Enumerable.Repeat(int.MaxValue, len)));
            }

            var index = 0;
            foreach (var kvp in adjList._adjList)
            {
                distances[index][index] = 0;
                foreach (var node in kvp.Value)
                {
                    var nodeIndex = node.Key - 1;
                    distances[index][nodeIndex] = node.Value;
                }
                index++;
            }

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    for (int k = 0; k < len; k++)
                    {
                        if (distances[j][i] != int.MaxValue && distances[i][k] != int.MaxValue)
                        {
                            var min = new List<int> { distances[j][k], distances[j][i] + distances[i][k] }.Min();
                            distances[j][k] = min;
                        }
                    }
                }
            }

            return distances;
        }

        public static Dictionary<List<int>, bool> BellmanFord(GraphAdjacentList<int> adjList, int start)
        {
            var len = adjList._adjList.Count;
            List<int> distances = new List<int>(Enumerable.Repeat(int.MaxValue, len));
            distances[start - 1] = 0;

            for (int i = 0; i < len; i++)
            {
                foreach (var kvp in adjList._adjList)
                {
                    foreach (var node in kvp.Value)
                    {
                        var u = kvp.Key - 1;
                        var v = node.Key - 1;
                        var weight = node.Value;
                        if (distances[u] != int.MaxValue && distances[u] + weight < distances[v])
                        {
                            distances[v] = distances[u] + weight;
                        }
                    }
                }
            }

            var isNegCycle = false;
            foreach (var kvp in adjList._adjList)
            {
                foreach (var node in kvp.Value)
                {
                    var u = kvp.Key - 1;
                    var v = node.Key - 1;
                    var weight = node.Value;
                    if (distances[u] + weight < distances[v] && distances[u] != int.MaxValue)
                    {
                        isNegCycle = true;
                    }
                }
            }

            return new Dictionary<List<int>, bool>()
            {
                { distances,
                isNegCycle }
            };
        }

        private static int FordFulkersonHelper(List<bool> visited, int curIndex, int endIndex,
            int maxFlow, GraphAdjacentList<int> adjList)
        {
            if (curIndex == endIndex)
            {
                return maxFlow;
            }
            visited[curIndex - 1] = true;
            foreach (var node in adjList._adjList[curIndex])
            {
                int nodeIndex = node.Key - 1;
                if (!visited[nodeIndex] && node.Value > 0)
                {
                    var minFlow = new List<int> { maxFlow, node.Value }.Min();
                    var dist = FordFulkersonHelper(visited, node.Key, endIndex, minFlow, adjList);
                    if (dist > 0)
                    {
                        var newWeight = node.Value - dist;
                        adjList._adjList[curIndex].Remove(node.Key);
                        adjList._adjList[curIndex].Add(node.Key, newWeight);
                        foreach (var kvp in adjList._adjList[curIndex])
                        {
                            if (kvp.Key == curIndex)
                            {
                                var updWeight = kvp.Value + dist;
                                adjList._adjList[curIndex].Remove(kvp.Key);
                                adjList._adjList[curIndex].Add(kvp.Key, updWeight);
                            }
                        }

                        return dist;
                    }
                }
            }

            return 0;
        }

        public static int FordFulkerson(int startIndex, int endIndex, GraphAdjacentList<int> adjList)
        {
            var flow = 0;
            while (true)
            {
                var visited = new List<bool>(Enumerable.Repeat(false, adjList._adjList.Count));
                var res = FordFulkersonHelper(visited, startIndex, endIndex, int.MaxValue, adjList);
                if (res == 0)
                {
                    return flow;
                }
                flow += res;
            }
        }
    }
}

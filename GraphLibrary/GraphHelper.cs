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
            var maxKey2 = adj2._adjList.Keys.Max();

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

            adj1._adjList[maxKey1].Add(maxKey2, weight);
            adj2._adjList[maxKey2].Add(maxKey1, weight);
        }
    }
}

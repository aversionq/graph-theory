using System;
using System.Collections.Generic;
using System.Text;

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
    }
}

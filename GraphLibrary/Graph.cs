using System;
using System.Collections.Generic;

namespace GraphLibrary
{
    public class Graph<T>
    {
        public GraphAdjacentList<T> AdjacentList { get; private set; }

        public Graph(bool isDirected, bool isWeighted)
        {
            if (isDirected)
            {
                // TODO
            }

            if (isWeighted)
            {
                // TODO
            }

            AdjacentList = new GraphAdjacentList<T>();
        }
        public Graph(Graph<T> graph)
        {
            this.AdjacentList = graph.AdjacentList;
        }
        public Graph(List<GraphNode<T>> graphNodes, bool isDirected, bool isWeighted) : this(isDirected, isWeighted)
        {
            AdjacentList = new GraphAdjacentList<T>(graphNodes);
        }

        public void AddNode(GraphNode<T> node)
        {
            AdjacentList.AddNode(node);
        }

        public void AddEdge(T name1, T name2)
        {
            AdjacentList.AddEdge(name1, name2);
        }

        public void RemoveNode(T name)
        {
            AdjacentList.RemoveNode(name);
        }

        public void RemoveEdge(T name1, T name2)
        {
            AdjacentList.RemoveEdge(name1, name2);
        }

        public void IsNodeExists(T name)
        {
            AdjacentList.IsNodeExists(name);
        }

        public override string ToString() => AdjacentList.Print();
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GraphLibrary
{
    public class Graph<T>
    {
        public GraphAdjacentList<T> AdjacentList { get; private set; }
        public bool IsDirected { get; private set; }
        public bool IsWeighted { get; private set; }

        public Graph(bool isDirected, bool isWeighted)
        {
            //if (isDirected)
            //{
            //    // TODO
            //}

            //if (isWeighted)
            //{
            //    // TODO
            //}
            IsDirected = isDirected;
            IsWeighted = isWeighted;

            AdjacentList = new GraphAdjacentList<T>();
        }
        public Graph(Graph<T> graph)
        {
            this.IsDirected = graph.IsDirected;
            this.IsWeighted = graph.IsWeighted;

            List<GraphNode<T>> graphNodes = new List<GraphNode<T>>();
            foreach (var kvp in graph.AdjacentList._adjList)
            {
                List<T> related = new List<T>();
                foreach (var val in kvp.Value)
                {
                    related.Add(val);
                }
                graphNodes.Add(new GraphNode<T>
                {
                    Name = kvp.Key,
                    Related = related
                });
            }
            AdjacentList = new GraphAdjacentList<T>(graphNodes);
        }
        public Graph(List<GraphNode<T>> graphNodes, bool isDirected, bool isWeighted) : this(isDirected, isWeighted)
        {
            AdjacentList = new GraphAdjacentList<T>(graphNodes);
        }
        public Graph(GraphAdjacentList<T> adjacentList)
        {
            AdjacentList = adjacentList;
        }
        public Graph(string filePath)
        {
            var graphTxt = File.ReadLines(filePath);
            var graphNodes = ParseFile(graphTxt);
            AdjacentList = new GraphAdjacentList<T>(graphNodes);
        }

        public void AddNode(GraphNode<T> node)
        {
            AdjacentList.AddNode(node, IsDirected);
        }

        public void AddEdge(T name1, T name2)
        {
            AdjacentList.AddEdge(name1, name2, IsDirected);
        }

        public void RemoveNode(T name)
        {
            AdjacentList.RemoveNode(name);
        }

        public void RemoveEdge(T name1, T name2)
        {
            AdjacentList.RemoveEdge(name1, name2, IsDirected);
        }

        public void WriteGraph(string fileName)
        {
            using(StreamWriter sw = new StreamWriter(fileName))
            {
                sw.Write(AdjacentList.GraphToTxt());
            }
        }

        public void IsNodeExists(T name)
        {
            AdjacentList.IsNodeExists(name);
        }

        public override string ToString() => AdjacentList.Print();

        private List<GraphNode<T>> ParseFile(IEnumerable<string> graphTxt)
        {
            List<GraphNode<T>> graphNodes = new List<GraphNode<T>>();

            var graphOptions = graphTxt.FirstOrDefault().Split(" ");
            IsDirected = graphOptions[0] == "1";
            IsWeighted = graphOptions[1] == "1";

            foreach (var item in graphTxt.Skip(1))
            {
                var nodeName = item.Split(':')[0];
                var nodeRelated = item.Split(':')[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                List<T> nodeRelatedT = new List<T>();
                foreach (var node in nodeRelated)
                {
                    nodeRelatedT.Add((T)Convert.ChangeType(node, typeof(T)));
                }
                graphNodes.Add(new GraphNode<T>((T)Convert.ChangeType(nodeName, typeof(T))
                                               , nodeRelatedT));
            }

            return graphNodes;
        }
    }
}

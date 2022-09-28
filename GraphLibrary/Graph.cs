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
        public Dictionary<string, GraphEdge<T>> EdgeList { get; private set; }
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

        public Graph(string filePath, bool isAdj)
        {
            var graphTxt = File.ReadLines(filePath);

            if (isAdj)
            {
                var graphNodes = ParseFileAdj(graphTxt);
                AdjacentList = new GraphAdjacentList<T>(graphNodes);
            }
            else
            {
                EdgeList = ParseFileEdge(graphTxt);
                PrintEdgeList();
            }
        }

        public void AddNode(GraphNode<T> node)
        {
            AdjacentList.AddNode(node, IsDirected);
        }

        //public void AddEdge(T name1, T name2)
        //{
        //    AdjacentList.AddEdge(name1, name2, IsDirected);
        //}

        public void AddEdge(string name, GraphEdge<T> edge)
        {
            EdgeList.Add(name, edge);
            AdjacentList.AddEdge(edge.Node1, edge.Node2, IsDirected);
        }

        public void RemoveNode(T name)
        {
            AdjacentList.RemoveNode(name);
        }

        //public void RemoveEdge(T name1, T name2)
        //{
        //    EdgeList.Remove(edgeName);
        //    AdjacentList.RemoveEdge(name1, name2, IsDirected);
        //}

        public void RemoveEdge(string edgeName)
        {
            AdjacentList.RemoveEdge(EdgeList[edgeName].Node1, EdgeList[edgeName].Node2, IsDirected);
            EdgeList.Remove(edgeName);
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

        public void PrintEdgeList()
        {
            foreach (var edge in EdgeList)
            {
                Console.WriteLine($"{edge.Key}:" +
                    $"{edge.Value.Node1} - {edge.Value.Node2} | Weight = {edge.Value.Weight}");
            }
        }

        private List<GraphNode<T>> ParseFileAdj(IEnumerable<string> graphTxt)
        {
            List<GraphNode<T>> graphNodes = new List<GraphNode<T>>();

            var graphOptions = graphTxt.FirstOrDefault().Split(" ");
            IsDirected = graphOptions[0] == "1";
            IsWeighted = graphOptions[1] == "1";

            foreach (var item in graphTxt.Skip(1))
            {
                var nodeName = item.Split(':')[0];
                var nodeRelated = item.Split(':')[1].Split(" ",
                    StringSplitOptions.RemoveEmptyEntries).ToList();

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

        private Dictionary<string, GraphEdge<T>> ParseFileEdge(IEnumerable<string> graphTxt)
        {
            Dictionary<string, GraphEdge<T>> edgeList = new Dictionary<string, GraphEdge<T>>();

            var graphOptions = graphTxt.FirstOrDefault().Split(" ");
            IsDirected = graphOptions[0] == "1";
            IsWeighted = graphOptions[1] == "1";

            foreach (var edge in graphTxt.Skip(1))
            {
                var edgeName = edge.Split(":")[0];
                var edgeInfo = edge.Split(':')[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                edgeList.Add(edgeName, new GraphEdge<T>
                {
                    Node1 = (T)Convert.ChangeType(edgeInfo[0], typeof(T)),
                    Node2 = (T)Convert.ChangeType(edgeInfo[1], typeof(T)),
                    Weight = IsWeighted ? int.Parse(edgeInfo[2].ToString()) : 0
                });
            }

            return edgeList;
        }
    }
}

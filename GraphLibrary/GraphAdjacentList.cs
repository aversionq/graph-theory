using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public class GraphAdjacentList<T>
    {
        internal Dictionary<T, Dictionary<T, int>> _adjList;

        public GraphAdjacentList()
        {
            _adjList = new Dictionary<T, Dictionary<T, int>>();
        }

        public GraphAdjacentList(List<GraphNode<T>> graphNodes) : this()
        {
            foreach (var node in graphNodes)
            {
                _adjList.Add(node.Name, node.Related);
            }
        }

        //internal GraphAdjacentList(Dictionary<T, List<T>> adj) : this()
        //{
        //    foreach (var kvp in adj)
        //    {
        //        _adjList.Add(kvp.Key, kvp.Value);
        //    }
        //}

        internal void AddNode(GraphNode<T> node, bool isDirected)
        {
            _adjList.Add(node.Name, node.Related);
            if (!isDirected)
            {
                foreach (var kvp in node.Related)
                {
                    if (kvp.Key.ToString() != node.Name.ToString())
                    {
                        _adjList[kvp.Key].Add(node.Name, node.Related[kvp.Key]);
                    }
                }
            }
        }

        internal void AddEdge(T name1, T name2, bool isDirected, int weight)
        {
            //_adjList[name1].Add(new Dictionary<T, int>
            //{
            //    {name2, weight},
            //});
            //if (!isDirected)
            //{
            //    _adjList[name2].Add(new Dictionary<T, int>
            //    {
            //        {name1, weight},
            //    });
            //}
            _adjList[name1].Add(name2, weight);
            if (!isDirected)
            {
                _adjList[name2].Add(name1, weight);
            }
        }

        internal void RemoveNode(T name)
        {
            //foreach (var value in _adjList.Values)
            //{
            //    foreach (var dict in value)
            //    {
            //        if (dict.ContainsKey(name))
            //        {
            //            dict.Remove(name);
            //        }
            //    }
            //}
            //_adjList.Remove(name);
            foreach (var kvp in _adjList)
            {
                _adjList[kvp.Key].Remove(name);
            }
            _adjList.Remove(name);
        }

        internal void RemoveEdge(T name1, T name2, bool isDirected)
        {
            _adjList[name1].Remove(name2);
            if (!isDirected)
            {
                _adjList[name2].Remove(name1);
            }
        }

        internal string GraphToTxt(bool isDirected, bool isWeighted)
        {
            StringBuilder adj = new StringBuilder();

            if (isDirected)
            {
                adj.Append("1 ");
            }
            else
            {
                adj.Append("0 ");
            }

            if (isWeighted)
            {
                adj.Append("1" + Environment.NewLine);
            }
            else
            {
                adj.Append("0" + Environment.NewLine);
            }

            foreach (var kvp in _adjList)
            {
                adj.Append($"{kvp.Key}: ");
                foreach (var node in kvp.Value)
                {
                    adj.Append($"{node.Key}|{node.Value} ");
                }
                adj.Append(Environment.NewLine);
            }

            return adj.ToString();
        }

        //internal Dictionary<T, List<T>> CopyAdjList()
        //{
        //    Dictionary<T, List<T>> adjListCopy = new Dictionary<T, List<T>>();

        //    foreach (var kvp in _adjList)
        //    {
        //        adjListCopy.Add(kvp.Key, kvp.Value);
        //    }

        //    return adjListCopy;
        //}

        internal bool IsNodeExists(T name) => _adjList.ContainsKey(name);

        internal string Print()
        {
            StringBuilder adjListPrint = new StringBuilder("Graph adjacent list:");
            foreach (var kvp in _adjList)
            {
                adjListPrint.Append(Environment.NewLine + $"{kvp.Key} :");
                foreach (var value in kvp.Value)
                {
                    adjListPrint.Append($" Node: {value.Key}, Weight = {value.Value} ||");
                }
            }
            return adjListPrint.ToString();
        }

        internal Dictionary<string, GraphEdge<T>> AdjacentListToEdgeList()
        {
            Dictionary<string, GraphEdge<T>> edgeDict = new Dictionary<string, GraphEdge<T>>();

            char charInc = (char)65;
            foreach (var kvp in _adjList)
            {
                foreach (var related in kvp.Value)
                {
                    var edge = new GraphEdge<T>
                    {
                        Node1 = kvp.Key,
                        Node2 = related.Key,
                        Weight = related.Value
                    };
                    edgeDict.Add(charInc.ToString(), edge);
                    charInc++;
                }
            }

            return edgeDict;
        }
    }
}

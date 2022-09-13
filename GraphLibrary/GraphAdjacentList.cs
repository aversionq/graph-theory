using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public class GraphAdjacentList<T>
    {
        private Dictionary<T, List<T>> _adjList;

        public GraphAdjacentList()
        {
            _adjList = new Dictionary<T, List<T>>();
        }
        public GraphAdjacentList(List<GraphNode<T>> graphNodes) : this()
        {
            foreach (var node in graphNodes)
            {
                _adjList.Add(node.Name, node.Related);
            }
        }

        internal void AddNode(GraphNode<T> node)
        {
            foreach (var value in node.Related)
            {
                _adjList[value].Add(node.Name);
            }
            _adjList.Add(node.Name, node.Related);
        }

        internal void AddEdge(T name1, T name2)
        {
            _adjList[name1].Add(name2);
            _adjList[name2].Add(name1);
        }

        internal void RemoveNode(T name)
        {
            foreach (var value in _adjList.Values)
            {
                if (value.Contains(name))
                {
                    value.Remove(name);
                }
            }
            _adjList.Remove(name);
        }

        internal void RemoveEdge(T name1, T name2)
        {
            _adjList[name1].Remove(name2);
            _adjList[name2].Remove(name1);
        }

        internal bool IsNodeExists(T name) => _adjList.ContainsKey(name);

        internal string Print()
        {
            StringBuilder adjListPrint = new StringBuilder("Graph adjacent list:");
            foreach (var kvp in _adjList)
            {
                adjListPrint.Append(Environment.NewLine + $"{kvp.Key} : ");
                foreach (var value in kvp.Value)
                {
                    adjListPrint.Append($"{value} ");
                }
            }
            return adjListPrint.ToString();
        }
    }
}

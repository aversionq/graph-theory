using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public class GraphEdge<T>
    {
        public T Node1 { get; set; }
        public T Node2 { get; set; }
        public int? Weight { get; set; }
    }
}

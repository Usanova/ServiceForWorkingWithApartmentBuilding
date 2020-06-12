using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public sealed class Page<T>
    {
        public int Offset { get; set; }

        public int Count { get; set; }

        public IEnumerable<T> Values { get; set; }
    }
}

using System.Collections.Generic;

namespace CswFramework
{
    public class TextSpan
    {
        private readonly string raw;

        public readonly int Start;
        public readonly int End;
        
        public int Size => End - Start;
        public bool Empty => string.IsNullOrEmpty(raw) && Start == End;

        public TextSpan(IEnumerable<char> raw, int start, int end)
        {
            this.raw = string.Concat(raw);
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return raw;
        }
    }
}
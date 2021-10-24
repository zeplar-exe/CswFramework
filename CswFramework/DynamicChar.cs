using System.Windows.Media;

namespace CswFramework
{
    public class DynamicChar
    {
        public Brush Foreground;
        public Brush Background;

        public UnderlineType UnderlineType;
    }

    public enum UnderlineType
    {
        None = 0,
        
        Straight,
        Squiggly
    }
}
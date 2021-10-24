namespace CswFramework
{
    public abstract class DynamicMetric
    {
        public readonly int Index;
        public readonly MetricDrawType DrawType;

        public DynamicMetric(int index, MetricDrawType drawType)
        {
            Index = index;
            DrawType = drawType;
        }
    }

    public enum MetricDrawType
    {
        CreateLine,
    }
}
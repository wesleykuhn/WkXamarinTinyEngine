namespace WkXamarinTinyEngine.Models
{
    public class EngineUIMeshPointModel
    {
        public ulong X { get; }
        public ulong Y { get; }
        public double AbsoluteScreenWidth { get; }
        public double AbsoluteScreenHeight { get; }

        public EngineUIMeshPointModel(ulong x, ulong y, double absoluteScreenWidth, double absoluteScreenHeight)
        {
            X = x;
            Y = y;
            AbsoluteScreenWidth = absoluteScreenWidth;
            AbsoluteScreenHeight = absoluteScreenHeight;
        }

        public override string ToString()
        {
            return $"DEBUG: Point={X},{Y} / AbsScreenWidth={AbsoluteScreenWidth} / AbsScreenHeight={AbsoluteScreenHeight}";
        }
    }
}

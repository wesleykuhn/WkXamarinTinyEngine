using WkXamarinTinyEngine.Services;

namespace WkXamarinTinyEngine.Models.EngineUI
{
    public class EngineUIMesh
    {
        public EngineUIMeshPoint[,] UIMeshPoints { get; set; }

        public ulong LastX { get; }
        public ulong LastY { get; }

        public double SpaceLenghtBetweenXs { get; }
        public double SpaceLenghtBetweenYs { get; }

        public EngineUIMesh(ulong lastX, ulong lastY, double spaceLenghtBetweenXs, double spaceLenghtBetweenYs)
        {
            LastX = lastX;
            LastY = lastY;
            SpaceLenghtBetweenXs = spaceLenghtBetweenXs;
            SpaceLenghtBetweenYs = spaceLenghtBetweenYs;
        }

        public EngineUIMeshPoint GenerateEngineUIMeshPoint(ulong x, ulong y) =>
            new EngineUIMeshPoint(x, y, x * SpaceLenghtBetweenXs, y * SpaceLenghtBetweenYs);
    }
}

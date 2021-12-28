using WkXamarinTinyEngine.Services;

namespace WkXamarinTinyEngine.Models.EngineUI
{
    public class EngineUIMeshModel
    {
        public EngineUIMeshPointModel[,] UIMeshPoints { get; set; } = new EngineUIMeshPointModel[EngineUIMeshService.MaxYPoints, EngineUIMeshService.MaxXPoints];

        public ulong LastX { get; }
        public ulong LastY { get; }

        public double SpaceLenghtBetweenXs { get; }
        public double SpaceLenghtBetweenYs { get; }

        public EngineUIMeshModel(ulong lastX, ulong lastY, double spaceLenghtBetweenXs, double spaceLenghtBetweenYs)
        {
            LastX = lastX;
            LastY = lastY;
            SpaceLenghtBetweenXs = spaceLenghtBetweenXs;
            SpaceLenghtBetweenYs = spaceLenghtBetweenYs;
        }

        public EngineUIMeshPointModel GenerateEngineUIMeshPoint(ulong x, ulong y) =>
            new EngineUIMeshPointModel(x, y, x * SpaceLenghtBetweenXs, y * SpaceLenghtBetweenYs);
    }
}

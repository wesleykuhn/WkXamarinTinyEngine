using System.Collections.Generic;

namespace WkXamarinTinyEngine.Models
{
    public class EngineUIMeshModel
    {
        public Dictionary<ulong, EngineUIMeshPointModel> UIMeshPoints { get; set; }

        public ulong LastX { get; }
        public ulong LastY { get; }
        public double LastPoint { get; }

        public double SpaceLenghtBetweenXs { get; }
        public double SpaceLenghtBetweenYs { get; }

        public EngineUIMeshModel(ulong lastX, ulong lastY, ulong lastPoint, double spaceLenghtBetweenXs, double spaceLenghtBetweenYs)
        {
            UIMeshPoints = new Dictionary<ulong, EngineUIMeshPointModel>();
            LastX = lastX;
            LastY = lastY;
            LastPoint = lastPoint;
            SpaceLenghtBetweenXs = spaceLenghtBetweenXs;
            SpaceLenghtBetweenYs = spaceLenghtBetweenYs;
        }

        public void AddPoint(ulong x, ulong y) =>
            this.UIMeshPoints.Add(Converters.EngineUI.UIPointToMergedInt(x, y), new EngineUIMeshPointModel(x, y, x * SpaceLenghtBetweenXs, y * SpaceLenghtBetweenYs));
    }
}

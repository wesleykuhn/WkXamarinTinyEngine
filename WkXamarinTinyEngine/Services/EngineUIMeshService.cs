using WkXamarinTinyEngine.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(WkXamarinTinyEngine.Services.EngineUIMeshService))]
namespace WkXamarinTinyEngine.Services
{
    public class EngineUIMeshService : IEngineUIMeshService
    {
        private const double ReduceScreenSizeFix = 6.3;

        internal const ulong MaxXPoints = 17; //Always use even numbers
        internal const ulong MaxYPoints = 11; //Always use even numbers
        private ulong SpacesCountBeetweenXs => MaxXPoints - 1;
        private ulong SpacesCountBeetweenYs => MaxYPoints - 1;

        public EngineUIMeshModel EngineUIMesh { get; private set; }

        public double DeviceScreenWidth { get; }
        public double DeviceScreenHeight { get; }

        public EngineUIMeshService()
        {
            DisplayInfo mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            double width = mainDisplayInfo.Width / mainDisplayInfo.Density;
            double heigth = mainDisplayInfo.Height / mainDisplayInfo.Density;

            DeviceScreenWidth = width - (width * ReduceScreenSizeFix / 100);
            DeviceScreenHeight = heigth - (heigth * ReduceScreenSizeFix / 100);
        }

        public void SetupUIMeshPoints()
        {
            var spaceLenghtBetweenXs = DeviceScreenWidth / SpacesCountBeetweenXs;
            var spaceLenghtBetweenYs = DeviceScreenHeight / SpacesCountBeetweenYs;

            EngineUIMesh = new EngineUIMeshModel(
                MaxXPoints,
                MaxYPoints,
                Converters.EngineUI.UIPointToMergedInt(MaxXPoints, MaxYPoints),
                spaceLenghtBetweenXs,
                spaceLenghtBetweenYs);

            for (ulong y = 0; y < MaxYPoints; y++)
            {
                for (ulong x = 0; x < MaxXPoints; x++)
                {
                    EngineUIMesh.UIMeshPoints[y, x] = EngineUIMesh.GenerateEngineUIMeshPoint(x, y);
                    //EngineUIMesh.AddPoint(x, y);
                }
            }
        }
    }
}

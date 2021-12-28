using WkXamarinTinyEngine.Models.EngineUI;
using WkXamarinTinyEngine.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(WkXamarinTinyEngine.Services.EngineUIMeshService))]
namespace WkXamarinTinyEngine.Services
{
    public class EngineUIMeshService : IEngineUIMeshService
    {
        private const double ReduceScreenSizeFix = 6.3; //6.3

        internal const ulong MaxXPoints = 61; //Always use even numbers
        internal const ulong MaxYPoints = 21; //Always use even numbers
        private ulong SpacesCountBeetweenXs => MaxXPoints - 1;
        private ulong SpacesCountBeetweenYs => MaxYPoints - 1;

        public EngineUIMeshModel EngineUIMesh { get; private set; }

        public double CurrentScreenWidth { get; private set; }
        public double CurrentScreenHeight { get; private set; }

        public EngineUIMeshService()
        {
            DisplayInfo mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            double width = mainDisplayInfo.Width / mainDisplayInfo.Density;
            double heigth = mainDisplayInfo.Height / mainDisplayInfo.Density;

            CurrentScreenWidth = width - (width * ReduceScreenSizeFix / 100);
            CurrentScreenHeight = heigth - (heigth * ReduceScreenSizeFix / 100);
        }

        private EngineViewModel engineViewModelUsedByGame;

        public void StartEngine(EngineViewModel engineViewModel)
        {
            engineViewModelUsedByGame = engineViewModel;

            CreateNewEngineUIMesh();

            var engineUIElementsService = DependencyService.Get<IEngineUIElementsService>();
            engineUIElementsService.Initialize(engineViewModelUsedByGame.AttachedGrid);
        }

        private void CreateNewEngineUIMesh()
        {
            var spaceLenghtBetweenXs = CurrentScreenWidth / SpacesCountBeetweenXs;
            var spaceLenghtBetweenYs = CurrentScreenHeight / SpacesCountBeetweenYs;

            EngineUIMesh = new EngineUIMeshModel(
                MaxXPoints,
                MaxYPoints,
                spaceLenghtBetweenXs,
                spaceLenghtBetweenYs);

            for (ulong y = 0; y < MaxYPoints; y++)
            {
                for (ulong x = 0; x < MaxXPoints; x++)
                {
                    EngineUIMesh.UIMeshPoints[y, x] = EngineUIMesh.GenerateEngineUIMeshPoint(x, y);
                }
            }
        }

        public void ChangeCurrentScreenSize(double newHeight, double newWidth)
        {
            CurrentScreenHeight = newHeight;
            CurrentScreenWidth = newWidth;

            CreateNewEngineUIMesh();

            engineViewModelUsedByGame.CurrentScreenHeight = newHeight;
            engineViewModelUsedByGame.CurrentScreenWidth = newWidth;
        }
    }
}

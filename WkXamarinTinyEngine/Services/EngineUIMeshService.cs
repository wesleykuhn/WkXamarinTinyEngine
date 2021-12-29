using WkXamarinTinyEngine.Models.EngineUI;
using WkXamarinTinyEngine.Models.Settings;
using WkXamarinTinyEngine.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(WkXamarinTinyEngine.Services.EngineUIMeshService))]
namespace WkXamarinTinyEngine.Services
{
    public class EngineUIMeshService : IEngineUIMeshService
    {
        public EngineUIMesh EngineUIMesh { get; private set; }

        public double CurrentScreenWidth { get; private set; }
        public double CurrentScreenHeight { get; private set; }

        private EngineViewModel engineViewModelUsedByGame;
        private EngineSettings engineSettings;

        public void Initialize(EngineViewModel engineViewModel, EngineSettings engineSettings)
        {
            engineViewModelUsedByGame = engineViewModel;

            this.engineSettings = engineSettings ?? EngineSettings.GetDefault();

            SetScreenSizes();

            CreateNewEngineUIMesh();

            var engineUIElementsService = DependencyService.Get<IEngineUIElementsService>();
            engineUIElementsService.Initialize(engineViewModelUsedByGame.AttachedGrid);
        }

        private void SetScreenSizes()
        {
            if (engineSettings.EngineCanUseFullScreen)
            {
                DisplayInfo mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
                double width = mainDisplayInfo.Width / mainDisplayInfo.Density;
                double heigth = mainDisplayInfo.Height / mainDisplayInfo.Density;

                CurrentScreenWidth = width - (width * engineSettings.ReduceScreenSizeFix / 100);
                CurrentScreenHeight = heigth - (heigth * engineSettings.ReduceScreenSizeFix / 100);
            }
            else
            {
                CurrentScreenHeight = engineViewModelUsedByGame.AttachedGrid.Height;
                CurrentScreenWidth = engineViewModelUsedByGame.AttachedGrid.Width;
            }
        }

        private void CreateNewEngineUIMesh()
        {
            var spaceLenghtBetweenXs = CurrentScreenWidth / engineSettings.SpacesCountBeetweenXs;
            var spaceLenghtBetweenYs = CurrentScreenHeight / engineSettings.SpacesCountBeetweenYs;

            EngineUIMesh = new EngineUIMesh(
                engineSettings.UIMeshXPointsLenght,
                engineSettings.UIMeshYPointsLenght,
                spaceLenghtBetweenXs,
                spaceLenghtBetweenYs);

            EngineUIMesh.UIMeshPoints = new EngineUIMeshPoint[engineSettings.UIMeshYPointsLenght, engineSettings.UIMeshXPointsLenght];

            for (ulong y = 0; y < engineSettings.UIMeshYPointsLenght; y++)
            {
                for (ulong x = 0; x < engineSettings.UIMeshXPointsLenght; x++)
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

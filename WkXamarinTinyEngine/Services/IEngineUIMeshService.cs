using WkXamarinTinyEngine.Models.EngineUI;
using WkXamarinTinyEngine.Models.Settings;
using WkXamarinTinyEngine.ViewModels;

namespace WkXamarinTinyEngine.Services
{
    public interface IEngineUIMeshService
    {
        EngineUIMesh EngineUIMesh { get; }
        double CurrentScreenWidth { get; }
        double CurrentScreenHeight { get; }

        void Initialize(EngineViewModel engineViewModel, EngineSettings engineSettings);
        void ChangeCurrentScreenSize(double newHeight, double newWidth);
    }
}
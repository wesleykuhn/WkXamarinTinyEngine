using WkXamarinTinyEngine.Models.EngineUI;
using WkXamarinTinyEngine.ViewModels;

namespace WkXamarinTinyEngine.Services
{
    public interface IEngineUIMeshService
    {
        EngineUIMeshModel EngineUIMesh { get; }
        double CurrentScreenWidth { get; }
        double CurrentScreenHeight { get; }

        void StartEngine(EngineViewModel engineViewModel);
        void ChangeCurrentScreenSize(double newHeight, double newWidth);
    }
}
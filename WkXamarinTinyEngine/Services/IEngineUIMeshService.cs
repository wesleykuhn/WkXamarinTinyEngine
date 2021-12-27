using WkXamarinTinyEngine.Models;

namespace WkXamarinTinyEngine.Services
{
    public interface IEngineUIMeshService
    {
        EngineUIMeshModel EngineUIMesh { get; }
        double DeviceScreenWidth { get; }
        double DeviceScreenHeight { get; }

        void SetupUIMeshPoints();
    }
}
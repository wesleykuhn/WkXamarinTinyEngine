using System.Threading.Tasks;
using WkXamarinTinyEngine.Services;
using Xamarin.Forms;

namespace WkXamarinTinyEngine.ViewModels
{
    internal class EngineViewModel : BaseViewModel
    {
        #region [ SERVICES ]

        internal IEngineUIMeshService EngineUIMeshService;

        private void InitializeServices()
        {
            EngineUIMeshService = DependencyService.Get<IEngineUIMeshService>();
            EngineUIMeshService.SetupUIMeshPoints();
        }

        #endregion

        #region [ SCREEN SIZE ]

        private double deviceScreenWidth;
        public double DeviceScreenWidth
        {
            get => deviceScreenWidth;
            set => SetProperty(ref deviceScreenWidth, value);
        }

        private double deviceScreenHeight;
        public double DeviceScreenHeight
        {
            get => deviceScreenHeight;
            set => SetProperty(ref deviceScreenHeight, value);
        }


        private void SetupScreenSize()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DeviceScreenHeight = EngineUIMeshService.DeviceScreenHeight;
                DeviceScreenWidth = EngineUIMeshService.DeviceScreenWidth;
            });
        }

        #endregion

        public override Task InitAsync(object args = null)
        {
            IsBusy = true;

            InitializeServices();

            SetupScreenSize();

            IsBusy = false;

            return Task.CompletedTask;
        }
    }
}

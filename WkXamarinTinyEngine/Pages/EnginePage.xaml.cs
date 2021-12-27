using System.Threading.Tasks;
using WkXamarinTinyEngine.ViewModels;
using Xamarin.Forms;

namespace WkXamarinTinyEngine.Pages
{
    /// <summary>
    /// This
    /// </summary>
    public partial class EnginePage : ContentPage
    {
        private EngineViewModel context;
        public EnginePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            context = BindingContext as EngineViewModel;

            _ = Task.Run(async () => await context.InitAsync(null));
        }

        //If you are going to add Zoom system in the future, those commands below need be used!
        //private void ZoomButton_Clicked(object sender, System.EventArgs e)
        //{
        //    engineScroll.ForceLayout();
        //    engineGrid.ForceLayout();
        //}
    }
}

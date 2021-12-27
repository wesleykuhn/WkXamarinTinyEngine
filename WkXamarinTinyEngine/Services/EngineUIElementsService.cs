using WkXamarinTinyEngine.Models;
using System.Collections.Generic;
using Xamarin.Forms;

[assembly: Dependency(typeof(WkXamarinTinyEngine.Services.EngineUIElementsService))]
namespace WkXamarinTinyEngine.Services
{
    /// <summary>
    /// This service/class will only setup the elements on UI! The image and fit image properties needs to be set by you!
    /// </summary>
    public class EngineUIElementsService : IEngineUIElementsService
    {
        public Dictionary<View, EngineUIElementInfoModel> UIElementsInformation { get; set; }

        private IEngineUIMeshService engineUIMeshService;
        public EngineUIElementsService()
        {
            if (UIElementsInformation is null)
                UIElementsInformation = new Dictionary<View, EngineUIElementInfoModel>();

            engineUIMeshService = DependencyService.Get<IEngineUIMeshService>();
        }

        public void RegisterElement(View element, double width, double height, ulong originalUIMeshPointX, ulong originalUIMeshPointY)
        {
            UIElementsInformation.Add(element, new EngineUIElementInfoModel
            {
                Width = width,
                Height = height,
                OriginalUIMeshPointX = originalUIMeshPointX,
                OriginalUIMeshPointY = originalUIMeshPointY,
                CurrentUIMeshPointX = originalUIMeshPointX,
                CurrentUIMeshPointY = originalUIMeshPointY,
            });
        }

        public void PlaceAllElementsAtMainGridOfEnginePage(Grid mainGrid)
        {
            foreach (var element in UIElementsInformation)
            {
                var elementPoint = engineUIMeshService.EngineUIMesh.UIMeshPoints[element.Value.OriginalUIMeshPointY, element.Value.OriginalUIMeshPointX];

                mainGrid.Children.Add(element.Key);
                element.Key.TranslationX = elementPoint.AbsoluteScreenWidth;
                element.Key.TranslationY = elementPoint.AbsoluteScreenHeight;
                element.Key.WidthRequest = element.Value.Width;
                element.Key.HeightRequest = element.Value.Height;
            }
        }
    }
}

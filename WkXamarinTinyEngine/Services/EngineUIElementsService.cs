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

        public void RegisterElement(View element, double width, double height, ulong originalUIMeshPointKey)
        {
            UIElementsInformation.Add(element, new EngineUIElementInfoModel
            {
                Width = width,
                Height = height,
                OriginalUIMeshPointKey = originalUIMeshPointKey,
                CurrentUIMeshPointKey = originalUIMeshPointKey
            });
        }

        public void PlaceAllElementsAtMainGridOfEnginePage(ref Grid mainGrid)
        {
            foreach (var element in UIElementsInformation)
            {
                var elementView = element.Key;

                var elementPoint = engineUIMeshService.EngineUIMesh.UIMeshPoints[element.Value.OriginalUIMeshPointKey];

                mainGrid.Children.Add(elementView);

                elementView.TranslationX = elementPoint.AbsoluteScreenWidth;
                elementView.TranslationY = elementPoint.AbsoluteScreenHeight;
            }
        }
    }
}

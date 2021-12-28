using System.Collections.Generic;
using WkXamarinTinyEngine.Models.EngineUIElements;
using Xamarin.Forms;

[assembly: Dependency(typeof(WkXamarinTinyEngine.Services.EngineUIElementsService))]
namespace WkXamarinTinyEngine.Services
{
    /// <summary>
    /// This service/class will only setup the elements on UI! The image and fit image properties needs to be set by you!
    /// </summary>
    public class EngineUIElementsService : IEngineUIElementsService
    {
        public List<ViewUIElementModel> CurrentUIElements { get; set; }
        public Grid MainGameGrid { get; private set; }

        private IEngineUIMeshService engineUIMeshService;
        public EngineUIElementsService()
        {
            if (CurrentUIElements is null)
                CurrentUIElements = new List<ViewUIElementModel>();

            engineUIMeshService = DependencyService.Get<IEngineUIMeshService>();
        }

        public void Initialize(Grid mainGameGrid)
        {
            MainGameGrid = mainGameGrid;
        }

        public void AddElementToCurrentScreen(ViewUIElementModel viewUIElement)
        {
            CurrentUIElements.Add(viewUIElement);
            PlaceElementAtMainGridOfEnginePage(viewUIElement);
        }

        public void AddElementsToCurrentScreen(IEnumerable<ViewUIElementModel> viewUIElements)
        {
            foreach (var element in viewUIElements)
            {
                AddElementToCurrentScreen(element);
            }
        }

        private void PlaceElementAtMainGridOfEnginePage(ViewUIElementModel viewUIElement)
        {
            var targetPoint = engineUIMeshService.EngineUIMesh.UIMeshPoints[viewUIElement.CurrentUIMeshYPoint, viewUIElement.CurrentUIMeshXPoint];

            MainGameGrid.Children.Add(viewUIElement.View);
            viewUIElement.View.TranslationX = targetPoint.AbsoluteScreenWidth;
            viewUIElement.View.TranslationY = targetPoint.AbsoluteScreenHeight;
            viewUIElement.View.WidthRequest = viewUIElement.CurrentWidth;
            viewUIElement.View.HeightRequest = viewUIElement.CurrentHeight;
        }
    }
}

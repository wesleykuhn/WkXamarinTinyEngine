using System.Collections.Generic;
using System.Threading.Tasks;
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
        //public List<ViewUIElement> CurrentUIElements { get; set; }
        public Grid MainGameGrid { get; private set; }

        private IEngineUIMeshService engineUIMeshService;
        public EngineUIElementsService()
        {
            //if (CurrentUIElements is null)
            //    CurrentUIElements = new List<ViewUIElement>();

            engineUIMeshService = DependencyService.Get<IEngineUIMeshService>();
        }

        public void Initialize(Grid mainGameGrid)
        {
            MainGameGrid = mainGameGrid;
        }

        public double XPointsToScreenWidth(ulong xPointsLenght) =>
            engineUIMeshService.EngineUIMesh.SpaceLenghtBetweenXs * xPointsLenght;

        public double YPointsToScreenHeight(ulong yPointsLenght) =>
            engineUIMeshService.EngineUIMesh.SpaceLenghtBetweenYs * yPointsLenght;

        #region [ CREATE ELEMENTS ]

        /// <summary>
        /// Spawn an element to the Main Grid and returns its new ID.
        /// </summary>
        /// <param name="viewUIElement">The new Element to be spawned.</param>
        /// <returns>The ID of the spawned element.</returns>
        public async Task<int> SpawnElementAsync(ViewUIElement viewUIElement) =>
            await PlaceElementAtMainGridOfEnginePageAsync(viewUIElement);

        public async Task<int> SpawnElementAsync(ViewUIElement viewUIElement, double absoluteScreenWidth, double absoluteScreenHeight) =>
            await PlaceElementAtMainGridOfEnginePageAsync(viewUIElement, absoluteScreenWidth: absoluteScreenWidth, absoluteScreenHeight: absoluteScreenHeight);

        public async Task SpawnElementsAsync(IEnumerable<ViewUIElement> viewUIElements)
        {
            foreach (var element in viewUIElements)
            {
                await SpawnElementAsync(element);
            }
        }

        private Task<int> PlaceElementAtMainGridOfEnginePageAsync(ViewUIElement viewUIElement, double absoluteScreenWidth = -1, double absoluteScreenHeight = -1)
        {
            var targetPoint = engineUIMeshService.EngineUIMesh.UIMeshPoints[viewUIElement.CurrentUIMeshYPoint, viewUIElement.CurrentUIMeshXPoint];

            MainGameGrid.Children.Add(viewUIElement.View);
            viewUIElement.View.VerticalOptions = LayoutOptions.Center;
            viewUIElement.View.HorizontalOptions = LayoutOptions.Center;
            viewUIElement.View.WidthRequest = viewUIElement.CurrentWidth;
            viewUIElement.View.HeightRequest = viewUIElement.CurrentHeight;

            if (absoluteScreenWidth > -1 && absoluteScreenHeight > -1)
            {
                viewUIElement.View.TranslationX = absoluteScreenWidth;
                viewUIElement.View.TranslationY = absoluteScreenHeight;
            }
            else
            {
                viewUIElement.View.TranslationX = targetPoint.AbsoluteScreenWidth;
                viewUIElement.View.TranslationY = targetPoint.AbsoluteScreenHeight;
            }

            return Task.FromResult(MainGameGrid.Children.IndexOf(viewUIElement.View));
        }

        #endregion

        #region [ UPDATE ELEMENTS ]

        public async Task MoveElementAsync(int elementId, ulong newUIMeshXPoint, ulong newUIMeshYPoint, uint animationDuration = 250)
        {
            var newPoint = engineUIMeshService.EngineUIMesh.UIMeshPoints[newUIMeshYPoint, newUIMeshXPoint];
            await MainGameGrid.Children[elementId].TranslateTo(newPoint.AbsoluteScreenWidth, newPoint.AbsoluteScreenHeight, animationDuration);
        }

        public async Task MoveElementAsync(int elementId, double newAbsoluteScreenWidth, double newAbsoluteScreenHeight, uint animationDuration = 250)
        {
            await MainGameGrid.Children[elementId].TranslateTo(newAbsoluteScreenWidth, newAbsoluteScreenHeight, animationDuration);
        }

        #endregion

        #region [ DELETE ELEMENTS ]

        public Task RemoveElementAsync(int elementId)
        {
            MainGameGrid.Children.RemoveAt(elementId);

            return Task.CompletedTask;
        }

        #endregion
    }
}

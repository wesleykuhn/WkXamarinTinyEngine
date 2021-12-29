using System.Collections.Generic;
using System.Threading.Tasks;
using WkXamarinTinyEngine.Models.EngineUIElements;
using Xamarin.Forms;

namespace WkXamarinTinyEngine.Services
{
    public interface IEngineUIElementsService
    {
        //List<ViewUIElement> CurrentUIElements { get; set; }
        Grid MainGameGrid { get; }

        void Initialize(Grid mainGameGrid);

        double XPointsToScreenWidth(ulong xPointsLenght);
        double YPointsToScreenHeight(ulong yPointsLenght);

        Task<int> SpawnElementAsync(ViewUIElement viewUIElement);
        Task<int> SpawnElementAsync(ViewUIElement viewUIElement, double absoluteScreenWidth, double absoluteScreenHeight);
        Task SpawnElementsAsync(IEnumerable<ViewUIElement> viewUIElements);

        Task MoveElementAsync(int elementId, ulong newUIMeshXPoint, ulong newUIMeshYPoint, uint animationDuration = 250);
        Task MoveElementAsync(int elementId, double newAbsoluteScreenWidth, double newAbsoluteScreenHeight, uint animationDuration = 250);

        Task RemoveElementAsync(int elementId);
    }
}
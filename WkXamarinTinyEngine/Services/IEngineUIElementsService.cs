using System.Collections.Generic;
using WkXamarinTinyEngine.Models.EngineUIElements;
using Xamarin.Forms;

namespace WkXamarinTinyEngine.Services
{
    public interface IEngineUIElementsService
    {
        List<ViewUIElementModel> CurrentUIElements { get; set; }
        Grid MainGameGrid { get; }

        void Initialize(Grid mainGameGrid);
        void AddElementToCurrentScreen(ViewUIElementModel viewUIElement);
        void AddElementsToCurrentScreen(IEnumerable<ViewUIElementModel> viewUIElements);
    }
}
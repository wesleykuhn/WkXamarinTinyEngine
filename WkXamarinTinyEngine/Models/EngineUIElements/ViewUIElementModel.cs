using Xamarin.Forms;

namespace WkXamarinTinyEngine.Models.EngineUIElements
{
    public class ViewUIElementModel : BaseEngineUIElementModel
    {
        public View View { get; set; }

        public ViewUIElementModel() { }

        public ViewUIElementModel(int id, View view, double currentHeight, double currentWidth, ulong originalUIMeshXPoint, ulong originalUIMeshYPoint)
        {
            Id = id;
            View = view;
            CurrentHeight = currentHeight;
            CurrentWidth = currentWidth;
            OriginalUIMeshXPoint = originalUIMeshXPoint;
            OriginalUIMeshYPoint = originalUIMeshYPoint;
            CurrentUIMeshXPoint = originalUIMeshXPoint;
            CurrentUIMeshYPoint = originalUIMeshYPoint;
        }

        public ViewUIElementModel(int id, View view, double currentHeight, double currentWidth, ulong originalUIMeshXPoint, ulong originalUIMeshYPoint, ulong currentUIMeshXPoint, ulong currentUIMeshYPoint)
        {
            Id = id;
            View = view;
            CurrentHeight = currentHeight;
            CurrentWidth = currentWidth;
            OriginalUIMeshXPoint = originalUIMeshXPoint;
            OriginalUIMeshYPoint = originalUIMeshYPoint;
            CurrentUIMeshXPoint = currentUIMeshXPoint;
            CurrentUIMeshYPoint = currentUIMeshYPoint;
        }
    }
}

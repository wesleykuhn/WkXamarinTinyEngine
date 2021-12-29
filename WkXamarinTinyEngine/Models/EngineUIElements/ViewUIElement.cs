using Xamarin.Forms;

namespace WkXamarinTinyEngine.Models.EngineUIElements
{
    public class ViewUIElement : BaseEngineUIElement
    {
        public View View { get; set; }

        public ViewUIElement() { }

        public ViewUIElement(View view, string name, double currentHeight, double currentWidth, ulong originalUIMeshXPoint, ulong originalUIMeshYPoint)
        {
            Name = name;
            View = view;
            CurrentHeight = currentHeight;
            CurrentWidth = currentWidth;
            OriginalUIMeshXPoint = originalUIMeshXPoint;
            OriginalUIMeshYPoint = originalUIMeshYPoint;
            CurrentUIMeshXPoint = originalUIMeshXPoint;
            CurrentUIMeshYPoint = originalUIMeshYPoint;
        }

        public ViewUIElement(View view, string name, double currentHeight, double currentWidth, ulong originalUIMeshXPoint, ulong originalUIMeshYPoint, ulong currentUIMeshXPoint, ulong currentUIMeshYPoint)
        {
            Name = name;
            View = view;
            CurrentHeight = currentHeight;
            CurrentWidth = currentWidth;
            OriginalUIMeshXPoint = originalUIMeshXPoint;
            OriginalUIMeshYPoint = originalUIMeshYPoint;
            CurrentUIMeshXPoint = currentUIMeshXPoint;
            CurrentUIMeshYPoint = currentUIMeshYPoint;
        }

        public ViewUIElement(int id, View view, string name, double currentHeight, double currentWidth, ulong originalUIMeshXPoint, ulong originalUIMeshYPoint, ulong currentUIMeshXPoint, ulong currentUIMeshYPoint)
        {
            Id = id;
            Name = name;
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

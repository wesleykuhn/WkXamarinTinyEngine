namespace WkXamarinTinyEngine.Models.EngineUIElements
{
    public class BaseEngineUIElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CurrentHeight { get; set; }
        public double CurrentWidth { get; set; }
        public ulong OriginalUIMeshXPoint { get; set; }
        public ulong OriginalUIMeshYPoint { get; set; }
        public ulong CurrentUIMeshXPoint { get; set; }
        public ulong CurrentUIMeshYPoint { get; set; }
    }
}

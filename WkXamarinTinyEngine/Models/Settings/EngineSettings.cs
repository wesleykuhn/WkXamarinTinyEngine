namespace WkXamarinTinyEngine.Models.Settings
{
    /// <summary>
    /// If you won't use the FullScreen mode you can put 0 on ReduceScreenSizeFix.
    /// </summary>
    public class EngineSettings
    {
        public ulong UIMeshXPointsLenght { get; }
        public ulong UIMeshYPointsLenght { get; }
        public double ReduceScreenSizeFix { get; }
        public bool EngineCanUseFullScreen { get; set; }
        public ulong SpacesCountBeetweenXs => UIMeshXPointsLenght - 1;
        public ulong SpacesCountBeetweenYs => UIMeshYPointsLenght - 1;

        public EngineSettings(ulong uIMeshXPointsLenght, ulong uIMeshYPointsLenght, double reduceScreenSizeFix, bool fullScreen)
        {
            UIMeshXPointsLenght = uIMeshXPointsLenght;
            UIMeshYPointsLenght = uIMeshYPointsLenght;
            ReduceScreenSizeFix = reduceScreenSizeFix;
            EngineCanUseFullScreen = fullScreen;
        }

        public static EngineSettings GetDefault() => new EngineSettings(61, 21, 6.3, false);
    }
}

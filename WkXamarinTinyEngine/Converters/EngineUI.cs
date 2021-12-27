namespace WkXamarinTinyEngine.Converters
{
    internal static class EngineUI
    {
        internal static ulong UIPointToMergedInt(ulong x, ulong y)
        {
            if (y < 10U) return 10UL * x + y;
            if (y < 100U) return 100UL * x + y;
            if (y < 1000U) return 1000UL * x + y;
            if (y < 10000U) return 10000UL * x + y;
            if (y < 100000U) return 100000UL * x + y;
            if (y < 1000000U) return 1000000UL * x + y;
            if (y < 10000000U) return 10000000UL * x + y;
            if (y < 100000000U) return 100000000UL * x + y;
            return 1000000000UL * x + y;
        }
    }
}

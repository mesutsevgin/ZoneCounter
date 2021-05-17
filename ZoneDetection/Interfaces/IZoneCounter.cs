namespace ZoneDetection.Interfaces
{
    public interface IZoneCounter
    {
        // Feeds map data into solution class, then get ready for Solve() method.
        void Init(IMap map);

        // Counts zones in map provided with Init() method, then return the result.
        int Solve();
    }
}
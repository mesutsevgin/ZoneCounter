using ZoneDetection.Interfaces;

namespace ZoneDetection.Classes
{
    public class ZoneCounter : IZoneCounter
    {
        IMap _mapInterface;
        public void Init(IMap map)
        {
            _mapInterface = map;
        }

        public int Solve()
        {
            if (_mapInterface == null)
                return 0;

            _mapInterface.GetSize(out var width, out var height);

            bool[] visited = new bool[width * height];

            int count = 0;

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    if (!_mapInterface.IsBorder(x, y) && !visited[y * width + x])
                    {
                        Search(x, y, width, height, visited);
                        count++;
                    }
                }
            }

            return count;
        }

        void Search(int x, int y, int width, int height, bool[] visited)
        {
            if (x >= 0 && y >= 0 && x < width && y < height && !_mapInterface.IsBorder(x, y) && !visited[y * width + x])
            {
                visited[y * width + x] = true;
                Search(x, y - 1, width, height, visited);
                Search(x, y + 1, width, height, visited);
                Search(x - 1, y, width, height, visited);
                Search(x + 1, y, width, height, visited);
            }
        }

    }
}
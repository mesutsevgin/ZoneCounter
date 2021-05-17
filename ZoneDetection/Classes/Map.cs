using System;
using ZoneDetection.Interfaces;

namespace ZoneDetection.Classes
{
    public class Map : IMap
    {
        bool[,] mapData;

        public void ClearBorder(int x, int y)
        {
            mapData[x, y] = false;
        }

        public void GetSize(out int width, out int height)
        {
            width = mapData.GetLength(0);
            height = mapData.GetLength(1);
        }

        public bool IsBorder(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < mapData.GetLength(0) && y < mapData.GetLength(1))
                return mapData[x, y];
            return true;
        }

        public void SetBorder(int x, int y)
        {
            mapData[x, y] = true;
        }

        public void SetSize(in int width, in int height)
        {
            mapData = new bool[width, height];
        }

        public void Show()
        {
            GetSize(out var width, out var height);
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    Console.ForegroundColor = mapData[j, i] ? ConsoleColor.Red : ConsoleColor.White;
                    Console.Write(mapData[j, i] ? '1' : '0');
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
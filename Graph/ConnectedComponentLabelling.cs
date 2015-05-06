using System;
using System.Linq;

namespace TryingOut.Graph
{
    public class ConnectedComponentLabelling
    {
        private const int ExpectedImageDimension = 2;
        private const int NonConnectedComponentValue = 0;
        private const int ConnectedComponentValue = 1;

        private static readonly int[] DirectionX = { -1, -1, -1, 0, 0, 1, 1, 1 };
        private static readonly int[] DirectionY = { -1, 0, 1, -1, 1, -1, 0, 1 };

        public int FindNumberOfShapes(Array image)
        {
            var numberOfDimension = image.Rank;
            if (numberOfDimension != ExpectedImageDimension)
            {
                throw new ArgumentException("Expecting two dimensional array");
            }

            var numberOfElements = image.Length;
            if (numberOfElements == 0)
            {
                return 0;
            }

            var startLabel = 10;
            var currentLabel = 10;
            for (var i = 0; i < image.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < image.GetUpperBound(1) + 1; j++)
                {
                    var currentCellValue = (int) image.GetValue(i, j);
                    if (currentCellValue == NonConnectedComponentValue || currentCellValue >= startLabel)
                    {
                        continue;
                    }

                    image.SetValue(currentLabel, i, j);
                    SetNeighbours(image, i, j, currentLabel);
                    currentLabel++;
                }
            }
            
            return currentLabel - startLabel;
        }

        private void SetNeighbours(Array image, int currentCellX, int currentCellY, int currentLabel)
        {
            if (IsInValidRange(image, currentCellX, currentCellY) && (int)image.GetValue(currentCellX, currentCellY) == 0)
            {
                return;
            }

            for (var x = 0; x < DirectionX.Length; x++)
            {
                for (var y = 0; y < DirectionY.Length; y++)
                {
                    var neigbourX = currentCellX + (int) DirectionX.GetValue(x);
                    var neigbourY = currentCellY + (int) DirectionY.GetValue(y);

                    if (!IsInValidRange(image, neigbourX, neigbourY))
                    {
                        continue;
                    }

                    if ((int) image.GetValue(neigbourX, neigbourY) == ConnectedComponentValue)
                    {
                        image.SetValue(currentLabel, neigbourX, neigbourY);
                        SetNeighbours(image, neigbourX, neigbourY, currentLabel);
                    }
                }
            }
        }

        private static bool IsInValidRange(Array image, int neigbourX, int neigbourY)
        {
            if (neigbourX < 0 || neigbourX > image.GetUpperBound(0))
            {
                return false;
            }

            return neigbourY >= 0 && neigbourY <= image.GetUpperBound(1);
        }
    }
}

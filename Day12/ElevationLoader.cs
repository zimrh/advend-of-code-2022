using Common;
using System.Linq;

namespace Day12
{
    internal class ElevationLoader
    {
        public static async Task<ElevationMap> LoadAsync(string elevationFile)
        {
            var elevations = new ElevationMap();
            var rows = new List<string>();
            var start = new Position();
            var end = new Position();

            await foreach (var line in FileLoader.GetLinesAsync(elevationFile))
            {
                rows.Add(line);
            }

            elevations.Height = rows.Count;
            elevations.Width = rows[0].Length;

            for (int x = 0; x < rows[0].Length; x++)
            {    
                for (int y = rows.Count - 1; y >= 0; y--)
                {
                    var value = rows[rows.Count - 1 - y][x];
                    if (value == 'S')
                    {
                        start.X = x;
                        start.Y = y;
                        value = 'a';
                    }

                    if (value == 'E')
                    {
                        end.X = x;
                        end.Y = y;
                        value = 'z';
                    }

                    elevations.Map.Add(ElevationMap.MapIndex(x, y), new Position
                    {
                        X = x,
                        Y = y,
                        Value = value
                    });
                }
                
            }

            elevations.Start = start;
            elevations.End = end;

            return elevations;
        }
    }
}

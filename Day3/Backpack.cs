using System.Text;

namespace Day3
{
    internal class Backpack
    {
        public string Contents;
        public List<string> Compartments = new();
        public int CompartmentCount;

        public Backpack(string contents, int compartmentCount)
        {
            Contents = contents;
            CompartmentCount = compartmentCount;
            var compartmentSize = contents.Length / compartmentCount;
            for (int c = 0; c < compartmentCount; c++)
            {
                Compartments.Add(contents.Substring(compartmentSize * c, compartmentSize));
            }
        }

        public string FindOverlappingItemsInCompartments()
        {
            var commonChars = Compartments[0];
            for(var i = 1; i < Compartments.Count; i++)
            {
                commonChars = commonChars.FindOverlappingItems(Compartments[i]);
            }
            return commonChars;
        }

        public override string ToString()
        {
            return Contents;
        }
    }
}

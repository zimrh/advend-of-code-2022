using Common;
using Day6;

var signalsFilePath = "signals.txt";
await foreach(var line in FileLoader.GetLinesAsync(signalsFilePath))
{
    Console.WriteLine($"==Static Analyzers==");
    Console.WriteLine($"Start of Packet Marker: {StaticSignalAnalyzer.FindStartOfPacketMarker(line)}");
    Console.WriteLine($"Start of Message Marker: {StaticSignalAnalyzer.FindStartOfMessageMarker(line)}");
}

/* The above assumes we have read in the entire signal which (at least based on work I have done with DMX signals) is very rarely something you will have 
    Tweaking the code below to accept one character at a time and set a flag and record a position once the marker is reached.  Ideally I would create an
    event that would fire when the marker is reached but this will do for now.  If I get enough free time I will come back around to this
 */


var packetMarkerAnalyzer = new SignalAnalyzer(4);
var startOfMessageAnalyzer = new SignalAnalyzer(14);

await foreach (var line in FileLoader.GetLinesAsync(signalsFilePath))
{
    Console.WriteLine($"==Dynamic Analyzers==");
    foreach (var c in line)
    {
        if (!packetMarkerAnalyzer.MarkerFound)
        {
            packetMarkerAnalyzer.AddInput(c);
            // Might comeback around and turn these into events rather than a simple if statement but for now this will do
            if (packetMarkerAnalyzer.MarkerFound)
            {
                Console.WriteLine($"Start of Packet Marker: {packetMarkerAnalyzer.MarkerPosition}");
            }
        }

        if (!startOfMessageAnalyzer.MarkerFound)
        {
            startOfMessageAnalyzer.AddInput(c);
            
            if (startOfMessageAnalyzer.MarkerFound)
            {
                Console.WriteLine($"Start of Message Marker: {startOfMessageAnalyzer.MarkerPosition}");
            }
        }
    }
}

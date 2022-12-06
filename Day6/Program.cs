using Common;
using Day6;

var signalsFilePath = "signals.txt";
await foreach(var line in FileLoader.GetLinesAsync(signalsFilePath))
{
    Console.WriteLine($"Signal: {line}");
    Console.WriteLine($"Start of Packet Marker: {SignalAnalyzer.FindStartOfPacketMarker(line)}");
    Console.WriteLine($"Start of Message Marker: {SignalAnalyzer.FindStartOfMessageMarker(line)}");
}
using Common;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Day13
{
    internal class PacketAnalyzer
    {
        public static async Task<int> BubbleSortPacketsAsync(string packetsPath)
        {
            var packets = await ReadPacketsAsync(packetsPath);

            const string dividerPacket2 = "[[2]]";
            const string dividerPacket6 = "[[6]]";

            packets.Add(dividerPacket2);
            packets.Add(dividerPacket6);

            var packetArray = packets.ToArray();
            var tempString = string.Empty;
            var HasSwapOccured = false;

            do
            {
                HasSwapOccured = false;
                for (int p = 0; p < packetArray.Length - 1; p++)
                {
                    var outcome = CheckValues(packetArray[p], packetArray[p + 1]);
                    if (outcome != Analysis.LeftSmaller)
                    {
                        HasSwapOccured = true;
                        tempString = packetArray[p];
                        packetArray[p] = packetArray[p + 1];
                        packetArray[p + 1] = tempString;
                    }
                }
            } while (HasSwapOccured);

            var dividerPacket2Index = 0;
            var dividerPacket6Index = 0;

            for (int p = 0; p < packetArray.Length; p++)
            {
                if (string.Equals(packetArray[p], dividerPacket2))
                {
                    dividerPacket2Index = p + 1;
                }

                if (string.Equals(packetArray[p], dividerPacket6))
                {
                    dividerPacket6Index = p + 1;
                }
            }
            return dividerPacket2Index * dividerPacket6Index;
        }

        public static async Task<int> AnalyzePacketsAsync(string packetsPath)
        {
            var packets = await ReadPacketsAsync(packetsPath);

            var validPacketsCount = 0;
            var index = 1;

            for (int i = 0; i < packets.Count; i += 2)
            {
                var outCome = CheckValues(packets[i], packets[i + 1]);
                if (outCome == Analysis.LeftSmaller)
                {
                    validPacketsCount += index;
                }
                index++;
            }

            return validPacketsCount;

        }

        private static async Task<List<string>> ReadPacketsAsync(string packetsPath)
        {
            var packets = new List<string>();

            await foreach (var line in FileLoader.GetLinesAsync(packetsPath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                packets.Add(line);
            }

            return packets;
        }

        private static Analysis CheckValues(string leftInput, string rightInput)
        {
            var left = JsonDocument.Parse(leftInput);
            var right = JsonDocument.Parse(rightInput);
            return CheckValues(left.RootElement, right.RootElement);
        }

        private static Analysis CheckValues(JsonElement left, JsonElement right)
        {
            var leftType = left.ValueKind;
            var rightType = right.ValueKind;

            if (leftType != rightType)
            {
                if (leftType == JsonValueKind.Number && rightType == JsonValueKind.Array)
                {
                    var leftValue = left.GetInt32();
                    var convertToArray = JsonDocument.Parse($"[{leftValue}]");
                    return CheckValues(convertToArray.RootElement, right);
                }

                if (rightType == JsonValueKind.Number && leftType == JsonValueKind.Array)
                {
                    var rightValue = right.GetInt32();
                    var convertToArray = JsonDocument.Parse($"[{rightValue}]");
                    return CheckValues(left, convertToArray.RootElement);
                }

                throw new NotImplementedException();
            }

            if (leftType == JsonValueKind.Number)
            {
                var leftValue = left.GetInt32();
                var rightValue = right.GetInt32();

                if (leftValue == rightValue)
                {
                    return Analysis.Continue;
                }

                return (leftValue <= rightValue) ?
                    Analysis.LeftSmaller:
                    Analysis.RightSmaller;
            }

            if (leftType == JsonValueKind.Array)
            {
                var elementIndex = 0;
                var leftCount = left.GetArrayLength();
                var rightCount = right.GetArrayLength();

                while (elementIndex < leftCount && elementIndex < rightCount)
                {
                    var analysis = CheckValues(left[elementIndex], right[elementIndex]);
                    if (analysis != Analysis.Continue)
                    {
                        return analysis;
                    }
                    elementIndex++;
                }

                if (leftCount == rightCount)
                {
                    return Analysis.Continue;
                }

                return leftCount < rightCount ? Analysis.LeftSmaller : Analysis.RightSmaller;
            }

            throw new NotImplementedException();
        }
    }
}

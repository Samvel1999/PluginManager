using BasePlugin;

using System;
using System.Collections.Generic;

namespace ResizePlugin
{
    public class ResizePlugin : IPlugin
    {
        public string Name => "Resize";

        public void ApplyEffect(byte[] imageData, Dictionary<string, object> parameters)
        {
            if (parameters.TryGetValue("width", out var widthObj) && widthObj is int width &&
                parameters.TryGetValue("height", out var heightObj) && heightObj is int height)
            {
                Console.WriteLine($"Resizing image to {width}x{height}");
            }
            else
            {
                Console.WriteLine("Resize effect requires 'width' and 'height' parameters.");
            }
        }
    }
}

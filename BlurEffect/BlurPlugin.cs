using BasePlugin;
using System;
using System.Collections.Generic;

namespace BlurPlugin
{
    public class BlurPlugin : IPlugin
    {
        public string Name => "Blur";

        public void ApplyEffect(byte[] imageData, Dictionary<string, object> parameters)
        {
            if (parameters.TryGetValue("radius", out var radiusObj) && radiusObj is int radius)
            {
                Console.WriteLine($"Applying Blur effect with radius {radius}");
                // Fake processing - real logic would go here
            }
            else
            {
                Console.WriteLine("Blur effect requires a 'radius' parameter.");
            }
        }
    }
}

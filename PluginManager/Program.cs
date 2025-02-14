using System;
using System.Collections.Generic;

namespace ImageProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PluginManager pluginManager = PluginManager.Instance;

            byte[] sampleImage = new byte[0];

            var blurEffect = pluginManager.GetEffect("Blur");
            blurEffect?.ApplyEffect(sampleImage, new Dictionary<string, object> { { "radius", 5 } });

            var resizeEffect = pluginManager.GetEffect("Resize");
            resizeEffect?.ApplyEffect(sampleImage, new Dictionary<string, object> { { "width", 100 }, { "height", 150 } });

            Console.Read();
        }
    }
}

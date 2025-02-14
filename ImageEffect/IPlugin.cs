using System.Collections.Generic;

namespace BasePlugin
{
    public interface IPlugin
    {
        string Name { get; }

        /// <summary>
        /// Applies the effect to an image using dynamic parameters.
        /// </summary>
        /// <param name="imageData">The image data to process.</param>
        /// <param name="parameters">A dictionary of effect-specific parameters.</param>
        void ApplyEffect(byte[] imageData, Dictionary<string, object> parameters);
    }
}

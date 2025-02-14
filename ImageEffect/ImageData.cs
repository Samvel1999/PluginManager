using System.Collections.Generic;

namespace BasePlugin
{
    public class ImageData
    {
        public string FileName { get; set; }

        public List<string> AppliedEffects { get; private set; } = new List<string>();

        public void AddEffect(string effect)
        {
            AppliedEffects.Add(effect);
        }
    }
}

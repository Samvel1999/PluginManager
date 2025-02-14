using BasePlugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace ImageProcessor
{
    public class PluginManager
    {
        private const string _configPath = "config.json";

        private static readonly object _lockObj = new object();
        private static PluginManager _manager;

        private readonly Dictionary<string, Type> _plugins = new Dictionary<string, Type>();

        public static PluginManager Instance
        {
            get
            {
                if (_manager == null)
                {
                    lock (_lockObj)
                    {
                        if (_manager == null)
                        {
                            _manager = new PluginManager();
                        }
                    }
                }

                return _manager;
            }
        }

        private PluginManager()
        {
            LoadPlugins();
        }

        private void LoadPlugins()
        {
            if (!File.Exists(_configPath))
            {
                return;
            }

            string json = File.ReadAllText(_configPath);
            var pluginConfig = JsonSerializer.Deserialize<PluginConfig>(json);

            if (pluginConfig == null)
            {
                return;
            }
            _plugins.Clear();

            foreach (var plugin in pluginConfig.Plugins)
            {
                if (File.Exists(plugin.Dll))
                {
                    Console.WriteLine($"Loading '{plugin.Name}' plugin.");

                    var assembly = Assembly.LoadFrom(plugin.Dll);
                    foreach (var type in assembly.GetTypes())
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface)
                        {
                            var effectInstance = (IPlugin)Activator.CreateInstance(type);
                            _plugins[effectInstance.Name] = type;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to find '{plugin.Name}' plugin.");
                }
            }

            Console.WriteLine("Plugins loaded successfully.");
        }

        public IPlugin GetEffect(string effectName)
        {
            return _plugins.ContainsKey(effectName) ? (IPlugin)Activator.CreateInstance(_plugins[effectName]) : null;
        }
    }
}

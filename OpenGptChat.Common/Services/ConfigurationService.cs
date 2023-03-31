﻿using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Options;
using OpenGptChat.Models;
using OpenGptChat.Utilities;

namespace OpenGptChat.Services
{
    public class ConfigurationService
    {
        public ConfigurationService(IOptions<AppConfig> configuration)
        {
            OptionalConfiguration = configuration;
        }

        private IOptions<AppConfig> OptionalConfiguration { get; }

        public AppConfig Configuration => OptionalConfiguration.Value;

        public void Save()
        {
            using FileStream fs = File.Create(GlobalValues.JsonConfigurationFilePath);
            JsonSerializer.Serialize(fs, OptionalConfiguration.Value, JsonHelper.ConfigurationOptions);
        }
    }
}

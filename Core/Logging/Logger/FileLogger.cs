﻿using Core.Logging.Serilog;
using Core.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Core.Logging.Logger
{
    public class FileLogger : LoggerServiceBase
    {
        private readonly IConfiguration _configuration;

        public FileLogger(IConfiguration configuration)
        {
            _configuration = configuration;

            FileLogConfiguration logConfig =
                configuration.GetSection("SeriLogConfigurations:FileLogConfiguration").Get<FileLogConfiguration>()
                ?? throw new Exception("FileLogConfiguration is missing in appsettings.json");

            string logFilePath = string.Format(format: "{0}{1}", arg0: Directory.GetCurrentDirectory() + logConfig.FolderPath, arg1: ".txt");

            Logger = new LoggerConfiguration().WriteTo
                .File(
                    logFilePath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: null,
                    fileSizeLimitBytes: 5000000,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
                )
                .CreateLogger();
        }
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    //配置文件
    //俩包: Microsoft.Extensions.Configuration   Microsoft.Extensions.Configuration.Json
    //json文件一定要选择始终复制
    public class ConfigurationManager
    {
        private static IConfigurationRoot _configuration;
        static ConfigurationManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json");
            _configuration = builder.Build();
        }

        public static string GetNode(string name)
        {
            return _configuration[name];
        }
    }
}

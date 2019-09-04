using System;
using static Yoga.Net.YogaGlobal;

namespace Yoga.Net
{
    public static class Logger
    {
        public static void Log(LogLevel level, string message)
        {
            Log(null, null, level, message);
        }

        public static void Log(YGNode node, LogLevel level, string message)
        {
            Log(node?.Config, node, level, message);
        }

        public static void Log(YogaConfig config, LogLevel level, string message)
        {
            Log(config, null, level, message);
        }

        static void Log(YogaConfig config, YGNode node, LogLevel level, string message)
        {
            YogaConfig logConfig = config ?? DefaultConfig;
            logConfig.Log(logConfig, node, level, message);

            if (level == LogLevel.Fatal)
                Environment.FailFast("Fatal exception");
        }
    };
}

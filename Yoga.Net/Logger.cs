using System;

using static Yoga.Net.YogaGlobal;

namespace Yoga.Net
{
    public static class Logger
    {
        public static void Log(YGLogLevel level, string message)
        {
            Log(null, null, level, message);
        }

        public static void Log(YGNode node, YGLogLevel level, string message) 
        {
            Log( node?.GetConfig(), node, level, message);
        }

        public static void Log(YogaConfig config, YGLogLevel level, string message)
        {
            Log(config, null, level, message);
        }

        static void Log(YogaConfig config, YGNode node, YGLogLevel level, string message) 
        {
            YogaConfig logConfig = config ?? DefaultConfig;
            logConfig.Log(logConfig, node, level, message);

            if (level == YGLogLevel.Fatal) 
                Environment.FailFast("Fatal exception");
        }

    };
}

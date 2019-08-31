using System;

using static Yoga.Net.YGGlobal;

namespace Yoga.Net
{
    public static class Logger
    {
        public static void Log(YGLogLevel level, object context, string message)
        {
            Log(null, null, level, context, message);
        }

        public static void Log(YGNode node, YGLogLevel level, object context, string message) 
        {
            Log( node?.getConfig(), node, level, context, message);
        }

        public static void Log(YGConfig config, YGLogLevel level, object context, string message)
        {
            Log(config, null, level, context, message);
        }

        static void Log(YGConfig config, YGNode node, YGLogLevel level, object context, string message) 
        {
            YGConfig logConfig = config ?? DefaultConfig;
            logConfig.Log(logConfig, node, level, context, message);

            if (level == YGLogLevel.Fatal) 
                Environment.FailFast("Fatal exception");
        }

    };
}

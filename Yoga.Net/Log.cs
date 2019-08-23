using System;

namespace Yoga.Net
{
    public static class Log 
    {
        public static void log(
            YGLogLevel level,
            object context,
            string format, 
            params object[] args)
        {
            vlog(
                null,
                null,
                level,
                context,
                format,
                args);

        }

        public static void log(
            YGNode node,
            YGLogLevel level,
            object context,
            string format, 
            params object[] args)
        {
            vlog(
                node?.getConfig(),
                node,
                level,
                context,
                format,
                args);

        }

        public static void log(
            YGConfig config,
            YGLogLevel level,
            object context,
            string format,
            params object[] args)
        {
            vlog(config, null, level, context, format, args);
        }

        static void vlog(
            YGConfig config,
            YGNode node,
            YGLogLevel level,
            object context,
            string format,
            params object[] args) 
        {
            YGConfig logConfig = config ?? YGGlobal.YGConfigGetDefault();
            logConfig.log(logConfig, node, level, context, format, args);

            if (level == YGLogLevel.Fatal) 
            {
                Environment.FailFast("Fatal exception");
            }
        }

    };
}

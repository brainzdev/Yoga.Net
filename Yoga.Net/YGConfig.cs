using static Yoga.Net.YGGlobal;

namespace Yoga.Net
{
    public class YGConfig
    {
        public YGCloneNodeFunc CloneNodeFunc { get; set; }
        public YGLoggerFunc LoggerFunc { get; set; }
        public bool PrintTree { get; set; }
        public float PointScaleFactor { get; set; } = 1.0f;

        public object Context { get; set; }

        public bool[] ExperimentalFeatures { get; } = {false};

        public YGConfig(YGLoggerFunc logger)
        {
            LoggerFunc = logger;
        }

        public YGConfig(YGConfig config)
        {
            CloneNodeFunc = config.CloneNodeFunc;
            LoggerFunc    = config.LoggerFunc;
        }

        public void Log(YGConfig config, YGNode node, YGLogLevel level, object context, string message)
        {
            LoggerFunc(config, node, level, context, message);
        }

        public void Log(YGConfig config, YGNode node, YGLogLevel level, string message)
        {
            LoggerFunc(config, node, level, Context, message);
        }

        public YGNode CloneNode(
            YGNode node,
            YGNode owner,
            int childIndex,
            object cloneContext)
        {
            YGNode clone = CloneNodeFunc?.Invoke(node, owner, childIndex, cloneContext);

            return clone ?? YGNodeClone(node);
        }

        public override string ToString()
        {
            return $"Config({PointScaleFactor:F2}; )";
        }
    }
}

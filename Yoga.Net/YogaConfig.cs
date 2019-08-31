using static Yoga.Net.YogaGlobal;

namespace Yoga.Net
{
    public class YogaConfig
    {
        public YogaCloneNodeFunc CloneNodeFunc { get; set; }
        public LoggerFunc LoggerFunc { get; set; }
        public bool PrintTree { get; set; }
        public float PointScaleFactor { get; set; } = 1.0f;

        public bool[] ExperimentalFeatures { get; } = {false};

        public YogaConfig(LoggerFunc logger)
        {
            LoggerFunc = logger;
        }

        public YogaConfig(YogaConfig config)
        {
            CloneNodeFunc = config.CloneNodeFunc;
            LoggerFunc    = config.LoggerFunc;
        }

        public void Log(YogaConfig config, YGNode node, LogLevel level, string message)
        {
            LoggerFunc(config, node, level, message);
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

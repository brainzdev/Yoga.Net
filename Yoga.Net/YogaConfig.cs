using static Yoga.Net.YogaGlobal;

namespace Yoga.Net
{
    public class YogaConfig
    {
        public static YogaConfig DefaultConfig { get; } = new YogaConfig();

        public YogaCloneNodeFunc CloneNodeFunc { get; set; }
        public bool PrintTree { get; set; }
        public float PointScaleFactor { get; set; } = 1.0f;
        public bool[] ExperimentalFeatures { get; } = {false};
        public LoggerFunc LoggerFunc
        {
            get => _loggerFunc ?? Logger.DefaultLogger;
            set => _loggerFunc = value;
        }


        LoggerFunc _loggerFunc;

        public YogaConfig(LoggerFunc logger = null)
        {
            LoggerFunc = logger;
        }

        public YogaConfig(YogaConfig config)
        {
            CloneNodeFunc = config.CloneNodeFunc;
            LoggerFunc    = config.LoggerFunc;
        }

        public void CopyFrom(YogaConfig config)
        {
            CloneNodeFunc = config.CloneNodeFunc;
            LoggerFunc    = config.LoggerFunc;
        }

        public void Log(LogLevel level, string message) => LoggerFunc?.Invoke(level, message);

        public YogaNode CloneNode(YogaNode node, YogaNode owner, int childIndex, object cloneContext)
        {
            YogaNode clone = CloneNodeFunc?.Invoke(node, owner, childIndex, cloneContext);
            return clone ?? YGNodeClone(node);
        }

        public override string ToString() => $"Config({PointScaleFactor:F2}; )";
    }
}

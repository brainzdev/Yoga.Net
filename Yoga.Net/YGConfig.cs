using static Yoga.Net.YGGlobal;

namespace Yoga.Net
{
    using YGConfigRef = YGConfig;
    using YGNodeRef = YGNode;

    public delegate int LogWithContextFn(
        YGConfigRef config,
        YGNodeRef node,
        YGLogLevel level,
        object context,
        string format,
        params object[] args);

    public class YGConfig
    {
        YGCloneNodeFunc cloneFunc;

        LogWithContextFn logWithContext;
        YGLogger logNoContext;

        bool loggerUsesContext_;

        //public:
        public bool printTree = false;

        public float pointScaleFactor = 1.0f;

        public bool[] experimentalFeatures = {false};
        public object context = null;

        public YGConfig(YGLogger logger)
        {
            logNoContext = logger;
        }

        public YGConfig(YGConfig config)
        {
            cloneFunc = config.cloneFunc;
            loggerUsesContext_ = config.loggerUsesContext_;
        }

        public void log(YGConfig config, YGNode node, YGLogLevel level, object context, in string format, params object[] args)
        {
            if (loggerUsesContext_)
                logWithContext(config, node, level, context, format, args);
            else
                logNoContext(config, node, level, format, args);
        }

        public void setLogger(YGLogger logger = (YGLogger)null)
        {
            logNoContext       = logger;
            logWithContext     = null;
            loggerUsesContext_ = false;
        }

        public void setLogger(LogWithContextFn logger)
        {
            logNoContext       = null;
            logWithContext     = logger;
            loggerUsesContext_ = true;
        }

        public YGNodeRef cloneNode(
            YGNodeRef node,
            YGNodeRef owner,
            int childIndex,
            object cloneContext)
        {
            YGNodeRef clone = cloneFunc?.Invoke(node, owner, childIndex, cloneContext);

            return clone ?? YGNodeClone(node);
        }

        public void setCloneNodeCallback(YGCloneNodeFunc cloneNode = null)
        {
            cloneFunc        = cloneNode;
        }

        public override string ToString()
        {
            return $"Config({pointScaleFactor:F2}; )";
        }
    }
}

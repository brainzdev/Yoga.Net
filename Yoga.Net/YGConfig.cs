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

    public delegate YGNodeRef CloneWithContextFn(
        YGNodeRef node,
        YGNodeRef owner,
        int childIndex,
        object cloneContext);


    public class YGConfig
    {
        CloneWithContextFn cloneWithContext;
        YGCloneNodeFunc cloneNoContext;

        LogWithContextFn logWithContext;
        YGLogger logNoContext;

        bool cloneNodeUsesContext_;
        bool loggerUsesContext_;

        //public:
        public bool useWebDefaults = false;
        public bool useLegacyStretchBehaviour = false;
        public bool shouldDiffLayoutWithoutLegacyStretchBehaviour = false;
        public bool printTree = false;

        public float pointScaleFactor = 1.0f;

        //public std::array<bool, facebook::yoga::enums::count<YGExperimentalFeature>()> experimentalFeatures = {};
        public object context = null;

        public YGConfig(YGLogger logger) { }

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
            YGNodeRef clone = cloneNodeUsesContext_
                ? cloneWithContext?.Invoke(node, owner, childIndex, cloneContext)
                : cloneNoContext?.Invoke(node, owner, childIndex);

            return clone ?? YGNodeClone(node);
        }

        void setCloneNodeCallback(YGCloneNodeFunc cloneNode = null)
        {
            cloneNoContext        = cloneNode;
            cloneWithContext      = null;
            cloneNodeUsesContext_ = false;
        }

        void setCloneNodeCallback(CloneWithContextFn cloneNode)
        {
            cloneWithContext      = cloneNode;
            cloneNoContext        = null;
            cloneNodeUsesContext_ = true;
        }
    }
}

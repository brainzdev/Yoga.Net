using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Yoga.Net
{
    public static partial class YogaGlobal
    {
        // This value was chosen based on empirical data:
        // 98% of analyzed layouts require less than 8 entries.
        public const int MaxCachedResultCount = 8;

        public const float DefaultFlexGrow = 0.0f;
        public const float DefaultFlexShrink = 0.0f;

        public static bool YogaIsUndefined(float value)
        {
            return float.IsNaN(value) || float.IsInfinity(value);
        }

        // This custom float equality function returns true if either absolute
        // difference between two floats is less than 0.0001f or both are undefined.
        public static bool FloatsEqual(in float a, in float b)
        {
            if (!YogaIsUndefined(a) && !YogaIsUndefined(b))
                return Math.Abs(a - b) < 0.0001f;

            return YogaIsUndefined(a) && YogaIsUndefined(b);
        }

        public static float FloatMax(in float a, in float b)
        {
            if (!YogaIsUndefined(a) && !YogaIsUndefined(b))
                return Math.Max(a, b);

            return YogaIsUndefined(a) ? b : a;
        }

        public static float FloatMod(float x, float y) => (float)Math.IEEERemainder(x, y);

        public static float FloatMin(float a, float b)
        {
            if (!YogaIsUndefined(a) && !YogaIsUndefined(b))
                return Math.Min(a, b);

            return YogaIsUndefined(a) ? b : a;
        }

        // This custom float comparison function compares the array of float with
        // FloatsEqual, as the default float comparison operator will not work(Look
        // at the comments of FloatsEqual function).
        public static bool FloatArrayEqual(float[] val1, float[] val2)
        {
            return val1.SequenceEqual(val2);
        }

        // This function returns 0 if YGFloatIsUndefined(val) is true and val otherwise
        public static float FloatSanitize(in float val)
        {
            return YogaIsUndefined(val) ? 0 : val;
        }

        public static readonly LoggerFunc DefaultLogger = (config, node, level, message) =>
        {
            Trace.Write(message);
            switch (level)
            {
            case YGLogLevel.Error:
            case YGLogLevel.Fatal:
                Console.Error.Write(message);
                break;

            case YGLogLevel.Warn:
            case YGLogLevel.Info:
            case YGLogLevel.Debug:
            case YGLogLevel.Verbose:
            default:
                Console.Write(message);
                break;
            }

            return 0;
        };

        public static YogaConfig DefaultConfig { get; } = new YogaConfig(DefaultLogger);
        public static YGNode DefaultYGNode { get; } = new YGNode();
    }
}

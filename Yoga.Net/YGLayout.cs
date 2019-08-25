using System;
using System.Collections.Generic;
using System.Text;

using size_t = System.Int32;
using uint8_t = System.Byte;
using uint32_t = System.UInt32;

using static Yoga.Net.YGGlobal;

namespace Yoga.Net
{
    public class YGLayout
    {
        public float[] position = {0f, 0f, 0f, 0f};
        public float[] dimensions = {YGValue.YGUndefined, YGValue.YGUndefined};

        public float[] margin = {0f, 0f, 0f, 0f};
        public float[] border = {0f, 0f, 0f, 0f};
        public float[] padding = {0f, 0f, 0f, 0f};

        //public:
        public int computedFlexBasisGeneration = 0;
        public YGFloatOptional computedFlexBasis = new YGFloatOptional();

        // Instead of recomputing the entire layout every single time, we cache some
        // information to break early when nothing changed
        public int generationCount = 0;
        public YGDirection lastOwnerDirection = YGDirection.Unknown;

        public int nextCachedMeasurementsIndex = 0;

        public YGCachedMeasurement[] cachedMeasurements = new YGCachedMeasurement[YGGlobal.YG_MAX_CACHED_RESULT_COUNT]; // TODO: Initialise array correctly
        public float[] measuredDimensions = {YGValue.YGUndefined, YGValue.YGUndefined};

        public YGCachedMeasurement cachedLayout = new YGCachedMeasurement();

        public YGDirection direction { get; internal set; }
        public bool didUseLegacyFlag { get; set; }
        public bool doesLegacyStretchFlagAffectsLayout { get; set; }
        public bool hadOverflow { get; internal set; }

        public YGLayout()
        {
            cachedMeasurements = new YGCachedMeasurement[YGGlobal.YG_MAX_CACHED_RESULT_COUNT];
            cachedMeasurements.Fill(new YGCachedMeasurement());
        }

        protected bool Equals(YGLayout other)
        {
            bool isEqual = YGFloatArrayEqual(position, other.position) &&
                YGFloatArrayEqual(dimensions, other.dimensions) &&
                YGFloatArrayEqual(margin, other.margin) &&
                YGFloatArrayEqual(border, other.border) &&
                YGFloatArrayEqual(padding, other.padding) &&
                direction == other.direction &&
                hadOverflow == other.hadOverflow &&
                lastOwnerDirection == other.lastOwnerDirection &&
                nextCachedMeasurementsIndex == other.nextCachedMeasurementsIndex &&
                cachedLayout == other.cachedLayout &&
                computedFlexBasis == other.computedFlexBasis;

            for (uint32_t i = 0; i < cachedMeasurements.Length && isEqual; ++i) 
                isEqual = isEqual && cachedMeasurements[i] == other.cachedMeasurements[i];

            if (!YogaIsUndefined(measuredDimensions[0]) || !YogaIsUndefined(other.measuredDimensions[0])) 
            {
                isEqual = isEqual && YGFloatsEqual(measuredDimensions[0],  other.measuredDimensions[0]);
            }

            if (!YogaIsUndefined(measuredDimensions[1]) || !YogaIsUndefined(other.measuredDimensions[1])) 
            {
                isEqual = isEqual && YGFloatsEqual(measuredDimensions[1], other.measuredDimensions[1]);
            }

            return isEqual;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YGLayout)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (position != null ? position.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (dimensions != null ? dimensions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (margin != null ? margin.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (border != null ? border.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (padding != null ? padding.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)computedFlexBasisGeneration;
                hashCode = (hashCode * 397) ^ computedFlexBasis.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)generationCount;
                hashCode = (hashCode * 397) ^ (int)lastOwnerDirection;
                hashCode = (hashCode * 397) ^ (int)nextCachedMeasurementsIndex;
                hashCode = (hashCode * 397) ^ (cachedMeasurements != null ? cachedMeasurements.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (measuredDimensions != null ? measuredDimensions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (cachedLayout != null ? cachedLayout.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)direction;
                hashCode = (hashCode * 397) ^ didUseLegacyFlag.GetHashCode();
                hashCode = (hashCode * 397) ^ doesLegacyStretchFlagAffectsLayout.GetHashCode();
                hashCode = (hashCode * 397) ^ hadOverflow.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(YGLayout left, YGLayout right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(YGLayout left, YGLayout right)
        {
            return !Equals(left, right);
        }
    }
}

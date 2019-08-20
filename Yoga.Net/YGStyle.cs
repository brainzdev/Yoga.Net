
namespace Yoga.Net
{
    public class Edges : detail.Values<YGEdge>
    {
        public Edges() { }
        public Edges(YGValue defaultValue) : base(defaultValue) { }
    }

    public class Dimensions : detail.Values<YGDimension>
    {
        public Dimensions() { }
        public Dimensions(YGValue defaultValue) : base(defaultValue) { }
    }

    public class YGStyle
    {
        public YGDirection direction { get; set; } = YGDirection.Inherit;
        public YGFlexDirection flexDirection { get; set; } = YGFlexDirection.Column;
        public YGJustify justifyContent { get; set; } = YGJustify.FlexStart;
        public YGAlign alignContent { get; set; } = YGAlign.FlexStart;
        public YGAlign alignItems { get; set; } = YGAlign.Stretch;
        public YGAlign alignSelf { get; set; } = YGAlign.Auto;
        public YGPositionType positionType { get; set; } = YGPositionType.Relative;
        public YGWrap flexWrap { get; set; } = YGWrap.NoWrap;
        public YGOverflow overflow { get; set; } = YGOverflow.Visible;
        public YGDisplay display { get; set; } = YGDisplay.Flex;

        public YGFloatOptional flex { get; set; } = new YGFloatOptional();
        public YGFloatOptional flexGrow { get; set; } = new YGFloatOptional();
        public YGFloatOptional flexShrink { get; set; } = new YGFloatOptional();
        public CompactValue flexBasis { get; set; } = CompactValue.Auto;
        public Edges margin { get; set; } = new Edges();
        public Edges position { get; set; } = new Edges();
        public Edges padding { get; set; } = new Edges();
        public Edges border { get; set; } = new Edges();
        public Dimensions dimensions { get; set; } = new Dimensions(YGValue.Auto);
        public Dimensions minDimensions { get; set; } = new Dimensions();
        public Dimensions maxDimensions { get; set; } = new Dimensions();

        // Yoga specific properties, not compatible with flexbox specification
        public YGFloatOptional aspectRatio { get; set; } = new YGFloatOptional();

        protected bool Equals(YGStyle other)
        {
            bool areNonFloatValuesEqual = direction == other.direction &&
                flexDirection == other.flexDirection &&
                justifyContent == other.justifyContent &&
                alignContent == other.alignContent &&
                alignItems == other.alignItems &&
                alignSelf == other.alignSelf &&
                positionType == other.positionType &&
                flexWrap == other.flexWrap && 
                overflow == other.overflow &&
                display == other.display &&
                YGGlobal.YGValueEqual(flexBasis, other.flexBasis) &&
                margin == other.margin && 
                position == other.position &&
                padding == other.padding && 
                border == other.border &&
                dimensions == other.dimensions &&
                minDimensions == other.minDimensions &&
                maxDimensions == other.maxDimensions;

            areNonFloatValuesEqual = areNonFloatValuesEqual && flex.isUndefined() == other.flex.isUndefined();
            if (areNonFloatValuesEqual && !flex.isUndefined() && !other.flex.isUndefined()) 
            {
                areNonFloatValuesEqual = areNonFloatValuesEqual && flex == other.flex;
            }

            areNonFloatValuesEqual = areNonFloatValuesEqual && flexGrow.isUndefined() == other.flexGrow.isUndefined();
            if (areNonFloatValuesEqual && !flexGrow.isUndefined()) 
            {
                areNonFloatValuesEqual = areNonFloatValuesEqual && flexGrow == other.flexGrow;
            }

            areNonFloatValuesEqual = areNonFloatValuesEqual && flexShrink.isUndefined() == other.flexShrink.isUndefined();
            if (areNonFloatValuesEqual && !other.flexShrink.isUndefined()) 
            {
                areNonFloatValuesEqual = areNonFloatValuesEqual && flexShrink == other.flexShrink;
            }

            if (!(aspectRatio.isUndefined() && other.aspectRatio.isUndefined())) 
            {
                areNonFloatValuesEqual = areNonFloatValuesEqual && aspectRatio == other.aspectRatio;
            }

            return areNonFloatValuesEqual;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YGStyle)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)direction;
                hashCode = (hashCode * 397) ^ (int)flexDirection;
                hashCode = (hashCode * 397) ^ (int)justifyContent;
                hashCode = (hashCode * 397) ^ (int)alignContent;
                hashCode = (hashCode * 397) ^ (int)alignItems;
                hashCode = (hashCode * 397) ^ (int)alignSelf;
                hashCode = (hashCode * 397) ^ (int)positionType;
                hashCode = (hashCode * 397) ^ (int)flexWrap;
                hashCode = (hashCode * 397) ^ (int)overflow;
                hashCode = (hashCode * 397) ^ (int)display;
                hashCode = (hashCode * 397) ^ flex.GetHashCode();
                hashCode = (hashCode * 397) ^ flexGrow.GetHashCode();
                hashCode = (hashCode * 397) ^ flexShrink.GetHashCode();
                hashCode = (hashCode * 397) ^ (flexBasis != null ? flexBasis.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (margin != null ? margin.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (position != null ? position.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (padding != null ? padding.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (border != null ? border.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (dimensions != null ? dimensions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (minDimensions != null ? minDimensions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (maxDimensions != null ? maxDimensions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ aspectRatio.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(YGStyle left, YGStyle right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(YGStyle left, YGStyle right)
        {
            return !Equals(left, right);
        }
    }
}

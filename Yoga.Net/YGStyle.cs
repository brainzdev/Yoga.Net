using System;

namespace Yoga.Net
{
    public class Edges : Values<YGEdge>
    {
        public Edges() { }
        public Edges(YGValue defaultValue) : base(defaultValue) { }
        public Edges(Edges other)
        {
            Array.Copy(other._values, _values, _values.Length);
        }
    }

    public class Dimensions : Values<YGDimension>
    {
        public Dimensions() { }
        public Dimensions(YGValue defaultValue) : base(defaultValue) { }
        public Dimensions(Dimensions other)
        {
            Array.Copy(other._values, _values, _values.Length);
        }
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

        public YGStyle() { }

        public YGStyle(YGStyle other)
        {
            direction = other.direction;
            flexDirection = other.flexDirection;
            justifyContent = other.justifyContent;
            alignContent = other.alignContent;
            alignItems = other.alignItems;
            alignSelf = other.alignSelf;
            positionType = other.positionType;
            flexWrap = other.flexWrap;
            overflow = other.overflow;
            display = other.display;

            flex = other.flex;
            flexGrow = other.flexGrow;
            flexShrink = other.flexShrink;
            flexBasis = other.flexBasis;
            margin = new Edges(other.margin);
            position = new Edges(other.position);
            padding = new Edges(other.padding);
            border = new Edges(other.border);
            dimensions = new Dimensions(other.dimensions);
            minDimensions = new Dimensions(other.minDimensions);
            maxDimensions = new Dimensions(other.maxDimensions);

            aspectRatio = other.aspectRatio;
        }

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

            areNonFloatValuesEqual = areNonFloatValuesEqual && flex.IsUndefined() == other.flex.IsUndefined();
            if (areNonFloatValuesEqual && !flex.IsUndefined() && !other.flex.IsUndefined()) 
            {
                areNonFloatValuesEqual = areNonFloatValuesEqual && flex == other.flex;
            }

            areNonFloatValuesEqual = areNonFloatValuesEqual && flexGrow.IsUndefined() == other.flexGrow.IsUndefined();
            if (areNonFloatValuesEqual && !flexGrow.IsUndefined()) 
            {
                areNonFloatValuesEqual = areNonFloatValuesEqual && flexGrow == other.flexGrow;
            }

            areNonFloatValuesEqual = areNonFloatValuesEqual && flexShrink.IsUndefined() == other.flexShrink.IsUndefined();
            if (areNonFloatValuesEqual && !other.flexShrink.IsUndefined()) 
            {
                areNonFloatValuesEqual = areNonFloatValuesEqual && flexShrink == other.flexShrink;
            }

            if (!(aspectRatio.IsUndefined() && other.aspectRatio.IsUndefined())) 
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

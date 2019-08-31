namespace Yoga.Net
{
    public class YogaStyle
    {
        public YGDirection Direction { get; set; } = YGDirection.Inherit;
        public YGFlexDirection FlexDirection { get; set; } = YGFlexDirection.Column;
        public YGJustify JustifyContent { get; set; } = YGJustify.FlexStart;
        public YGAlign AlignContent { get; set; } = YGAlign.FlexStart;
        public YGAlign AlignItems { get; set; } = YGAlign.Stretch;
        public YGAlign AlignSelf { get; set; } = YGAlign.Auto;
        public YGPositionType PositionType { get; set; } = YGPositionType.Relative;
        public YGWrap FlexWrap { get; set; } = YGWrap.NoWrap;
        public YGOverflow Overflow { get; set; } = YGOverflow.Visible;
        public YGDisplay Display { get; set; } = YGDisplay.Flex;

        public FloatOptional Flex { get; set; } = new FloatOptional();
        public FloatOptional FlexGrow { get; set; } = new FloatOptional();
        public FloatOptional FlexShrink { get; set; } = new FloatOptional();
        public CompactValue FlexBasis { get; set; } = CompactValue.Auto;
        public Edges Margin { get; set; } = new Edges();
        public Edges Position { get; set; } = new Edges();
        public Edges Padding { get; set; } = new Edges();
        public Edges Border { get; set; } = new Edges();
        public Dimensions Dimensions { get; set; } = new Dimensions(YogaValue.Auto);
        public Dimensions MinDimensions { get; set; } = new Dimensions();
        public Dimensions MaxDimensions { get; set; } = new Dimensions();

        // Yoga specific properties, not compatible with flexbox specification
        public FloatOptional AspectRatio { get; set; } = new FloatOptional();

        public YogaStyle() { }

        public YogaStyle(YogaStyle other)
        {
            Direction      = other.Direction;
            FlexDirection  = other.FlexDirection;
            JustifyContent = other.JustifyContent;
            AlignContent   = other.AlignContent;
            AlignItems     = other.AlignItems;
            AlignSelf      = other.AlignSelf;
            PositionType   = other.PositionType;
            FlexWrap       = other.FlexWrap;
            Overflow       = other.Overflow;
            Display        = other.Display;

            Flex          = other.Flex;
            FlexGrow      = other.FlexGrow;
            FlexShrink    = other.FlexShrink;
            FlexBasis     = other.FlexBasis;
            Margin        = new Edges(other.Margin);
            Position      = new Edges(other.Position);
            Padding       = new Edges(other.Padding);
            Border        = new Edges(other.Border);
            Dimensions    = new Dimensions(other.Dimensions);
            MinDimensions = new Dimensions(other.MinDimensions);
            MaxDimensions = new Dimensions(other.MaxDimensions);

            AspectRatio = other.AspectRatio;
        }

        protected bool Equals(YogaStyle other)
        {
            bool areNonFloatValuesEqual = Direction == other.Direction &&
                FlexDirection == other.FlexDirection &&
                JustifyContent == other.JustifyContent &&
                AlignContent == other.AlignContent &&
                AlignItems == other.AlignItems &&
                AlignSelf == other.AlignSelf &&
                PositionType == other.PositionType &&
                FlexWrap == other.FlexWrap &&
                Overflow == other.Overflow &&
                Display == other.Display &&
                FlexBasis == other.FlexBasis &&
                Margin == other.Margin &&
                Position == other.Position &&
                Padding == other.Padding &&
                Border == other.Border &&
                Dimensions == other.Dimensions &&
                MinDimensions == other.MinDimensions &&
                MaxDimensions == other.MaxDimensions;

            areNonFloatValuesEqual = areNonFloatValuesEqual && Flex.IsUndefined() == other.Flex.IsUndefined();
            if (areNonFloatValuesEqual && !Flex.IsUndefined() && !other.Flex.IsUndefined())
            {
                areNonFloatValuesEqual = Flex == other.Flex;
            }

            areNonFloatValuesEqual = areNonFloatValuesEqual && FlexGrow.IsUndefined() == other.FlexGrow.IsUndefined();
            if (areNonFloatValuesEqual && !FlexGrow.IsUndefined())
            {
                areNonFloatValuesEqual = FlexGrow == other.FlexGrow;
            }

            areNonFloatValuesEqual = areNonFloatValuesEqual && FlexShrink.IsUndefined() == other.FlexShrink.IsUndefined();
            if (areNonFloatValuesEqual && !other.FlexShrink.IsUndefined())
            {
                areNonFloatValuesEqual = FlexShrink == other.FlexShrink;
            }

            if (!(AspectRatio.IsUndefined() && other.AspectRatio.IsUndefined()))
            {
                areNonFloatValuesEqual = areNonFloatValuesEqual && AspectRatio == other.AspectRatio;
            }

            return areNonFloatValuesEqual;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YogaStyle)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)Direction;
                hashCode = (hashCode * 397) ^ (int)FlexDirection;
                hashCode = (hashCode * 397) ^ (int)JustifyContent;
                hashCode = (hashCode * 397) ^ (int)AlignContent;
                hashCode = (hashCode * 397) ^ (int)AlignItems;
                hashCode = (hashCode * 397) ^ (int)AlignSelf;
                hashCode = (hashCode * 397) ^ (int)PositionType;
                hashCode = (hashCode * 397) ^ (int)FlexWrap;
                hashCode = (hashCode * 397) ^ (int)Overflow;
                hashCode = (hashCode * 397) ^ (int)Display;
                hashCode = (hashCode * 397) ^ Flex.GetHashCode();
                hashCode = (hashCode * 397) ^ FlexGrow.GetHashCode();
                hashCode = (hashCode * 397) ^ FlexShrink.GetHashCode();
                hashCode = (hashCode * 397) ^ (FlexBasis != null ? FlexBasis.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Margin != null ? Margin.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Position != null ? Position.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Padding != null ? Padding.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Border != null ? Border.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Dimensions != null ? Dimensions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MinDimensions != null ? MinDimensions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MaxDimensions != null ? MaxDimensions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ AspectRatio.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(YogaStyle left, YogaStyle right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(YogaStyle left, YogaStyle right)
        {
            return !Equals(left, right);
        }
    }
}

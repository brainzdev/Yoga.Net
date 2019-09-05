namespace Yoga.Net
{
    public class YogaStyle
    {
        public Direction Direction { get; set; } = Direction.Inherit;
        public FlexDirection FlexDirection { get; set; } = FlexDirection.Column;
        public Justify JustifyContent { get; set; } = Justify.FlexStart;
        public YogaAlign AlignContent { get; set; } = YogaAlign.FlexStart;
        public YogaAlign AlignItems { get; set; } = YogaAlign.Stretch;
        public YogaAlign AlignSelf { get; set; } = YogaAlign.Auto;
        public PositionType PositionType { get; set; } = PositionType.Relative;
        public Wrap FlexWrap { get; set; } = Wrap.NoWrap;
        public Overflow Overflow { get; set; } = Overflow.Visible;
        public Display Display { get; set; } = Display.Flex;

        public float Flex { get; set; } = float.NaN;
        public float FlexGrow { get; set; } = float.NaN;
        public float FlexShrink { get; set; } = float.NaN;
        public YogaValue FlexBasis { get; set; } = YogaValue.Auto;
        public Edges Margin { get; set; } = new Edges(YogaValue.Undefined);
        public Edges Position { get; set; } = new Edges(YogaValue.Undefined);
        public Edges Padding { get; set; } = new Edges(YogaValue.Undefined);
        public Edges Border { get; set; } = new Edges(YogaValue.Undefined);
        public Dimensions Dimensions { get; set; } = new Dimensions(YogaValue.Auto);
        public Dimensions MinDimensions { get; set; } = new Dimensions(YogaValue.Undefined);
        public Dimensions MaxDimensions { get; set; } = new Dimensions(YogaValue.Undefined);

        // Yoga specific properties, not compatible with flexbox specification
        public float AspectRatio { get; set; } = float.NaN;

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
            if (areNonFloatValuesEqual && Flex.IsValid() && other.Flex.IsValid())
            {
                areNonFloatValuesEqual = Flex == other.Flex;
            }

            areNonFloatValuesEqual = areNonFloatValuesEqual && FlexGrow.IsUndefined() == other.FlexGrow.IsUndefined();
            if (areNonFloatValuesEqual && FlexGrow.IsValid())
            {
                areNonFloatValuesEqual = FlexGrow == other.FlexGrow;
            }

            areNonFloatValuesEqual = areNonFloatValuesEqual && FlexShrink.IsUndefined() == other.FlexShrink.IsUndefined();
            if (areNonFloatValuesEqual && other.FlexShrink.IsValid())
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

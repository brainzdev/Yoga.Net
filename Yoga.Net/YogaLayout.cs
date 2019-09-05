using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using static Yoga.Net.YogaGlobal;

namespace Yoga.Net
{
    public class YogaLayout
    {
        public readonly LTRBEdge Position = new LTRBEdge(0f);
        public float Width { get; set; } = float.NaN;
        public float Height { get; set; } = float.NaN;

        public readonly LTRBEdge Margin = new LTRBEdge(0f);
        public readonly LTRBEdge Border = new LTRBEdge(0f);
        public readonly LTRBEdge Padding = new LTRBEdge(0f);

        public int ComputedFlexBasisGeneration { get; set; }
        public float ComputedFlexBasis { get; set; } = float.NaN;

        // Instead of recomputing the entire layout every single time, we cache some
        // information to break early when nothing changed
        public int GenerationCount { get; set; }
        public Direction LastOwnerDirection { get; set; } = Net.Direction.Unknown;

        public int NextCachedMeasurementsIndex { get; set; }

        public readonly YogaCachedMeasurement[] CachedMeasurements = new YogaCachedMeasurement[MaxCachedResultCount];
        public readonly float[] MeasuredDimensions = {YogaValue.YGUndefined, YogaValue.YGUndefined};

        public YogaCachedMeasurement CachedLayout { get; } = new YogaCachedMeasurement();

        public Direction Direction { get; internal set; }
        public bool HadOverflow { get; internal set; }

        public YogaLayout()
        {
            CachedMeasurements.Fill(() => new YogaCachedMeasurement());
        }

        public YogaLayout(YogaLayout other)
        {
            Position = new LTRBEdge(other.Position);
            Width = other.Width;
            Height = other.Height;
            Margin = new LTRBEdge(other.Margin);
            Border = new LTRBEdge(other.Border);
            Padding = new LTRBEdge(other.Padding);

            ComputedFlexBasisGeneration = other.ComputedFlexBasisGeneration;
            ComputedFlexBasis           = other.ComputedFlexBasis;

            GenerationCount = other.GenerationCount;

            LastOwnerDirection = other.LastOwnerDirection;

            NextCachedMeasurementsIndex = other.NextCachedMeasurementsIndex;
            Array.Copy(other.CachedMeasurements, CachedMeasurements, CachedMeasurements.Length);
            Array.Copy(other.MeasuredDimensions, MeasuredDimensions, MeasuredDimensions.Length);

            CachedLayout = new YogaCachedMeasurement(other.CachedLayout);
            Direction    = other.Direction;
            HadOverflow  = other.HadOverflow;
        }

        protected bool Equals(YogaLayout other)
        {
            bool isEqual = Position == other.Position &&
                FloatsEqual(Width, other.Width) &&
                FloatsEqual(Height ,other.Height) &&
                Margin == other.Margin &&
                Border == other.Border &&
                Padding == other.Padding &&
                Direction == other.Direction &&
                HadOverflow == other.HadOverflow &&
                LastOwnerDirection == other.LastOwnerDirection &&
                NextCachedMeasurementsIndex == other.NextCachedMeasurementsIndex &&
                CachedLayout == other.CachedLayout &&
                ComputedFlexBasis == other.ComputedFlexBasis;

            for (var i = 0; i < CachedMeasurements.Length && isEqual; ++i)
                isEqual = CachedMeasurements[i] == other.CachedMeasurements[i];

            if (!YogaIsUndefined(MeasuredDimensions[0]) || !YogaIsUndefined(other.MeasuredDimensions[0]))
            {
                isEqual = isEqual && FloatsEqual(MeasuredDimensions[0], other.MeasuredDimensions[0]);
            }

            if (!YogaIsUndefined(MeasuredDimensions[1]) || !YogaIsUndefined(other.MeasuredDimensions[1]))
            {
                isEqual = isEqual && FloatsEqual(MeasuredDimensions[1], other.MeasuredDimensions[1]);
            }

            return isEqual;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YogaLayout)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Position != null ? Position.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Width.GetHashCode();
                hashCode = (hashCode * 397) ^ Height.GetHashCode();
                hashCode = (hashCode * 397) ^ (Margin != null ? Margin.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Border != null ? Border.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Padding != null ? Padding.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ComputedFlexBasisGeneration;
                hashCode = (hashCode * 397) ^ ComputedFlexBasis.GetHashCode();
                hashCode = (hashCode * 397) ^ GenerationCount;
                hashCode = (hashCode * 397) ^ (int)LastOwnerDirection;
                hashCode = (hashCode * 397) ^ NextCachedMeasurementsIndex;
                hashCode = (hashCode * 397) ^ (CachedMeasurements != null ? CachedMeasurements.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MeasuredDimensions != null ? MeasuredDimensions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CachedLayout != null ? CachedLayout.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Direction;
                hashCode = (hashCode * 397) ^ HadOverflow.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(YogaLayout left, YogaLayout right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(YogaLayout left, YogaLayout right)
        {
            return !Equals(left, right);
        }

        public float this[int p]
        {
            get => Position[p];
            set => Position[p] = value;
        }
    }
}

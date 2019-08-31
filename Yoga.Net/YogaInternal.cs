using System;
using System.Collections.Generic;
using System.Linq;


using size_t = System.Int32;
using static Yoga.Net.YGGlobal;

namespace Yoga.Net
{
    public class YGVector : List<YGNode>
    {
        public YGVector() { }
        public YGVector(IEnumerable<YGNode> collection) : base(collection) { }
    }


    public class YGCachedMeasurement
    {
        public float availableWidth;
        public float availableHeight;
        public YGMeasureMode widthMeasureMode;
        public YGMeasureMode heightMeasureMode;

        public float computedWidth;
        public float computedHeight;

        public YGCachedMeasurement()
        {
            availableWidth = 0;
            availableHeight = 0;
            widthMeasureMode = YGMeasureMode.Undefined;
            heightMeasureMode = YGMeasureMode.Undefined;
            computedWidth = -1;
            computedHeight = -1;
        }

        public YGCachedMeasurement(YGCachedMeasurement other)
        {
            availableWidth = other.availableWidth;
            availableHeight = other.availableHeight;
            widthMeasureMode = other.widthMeasureMode;
            heightMeasureMode = other.heightMeasureMode;
            computedWidth = other.computedWidth;
            computedHeight = other.computedHeight;
        }

        protected bool Equals(YGCachedMeasurement other)
        {
            bool isEqual = widthMeasureMode == other.widthMeasureMode &&
                heightMeasureMode == other.heightMeasureMode;

            if (!YogaIsUndefined(availableWidth) || !YogaIsUndefined(other.availableWidth))
            {
                isEqual = isEqual && FloatsEqual(availableWidth, other.availableWidth);
            }

            if (!YogaIsUndefined(availableHeight) || !YogaIsUndefined(other.availableHeight))
            {
                isEqual = isEqual && FloatsEqual(availableHeight, other.availableHeight);
            }

            if (!YogaIsUndefined(computedWidth) || !YogaIsUndefined(other.computedWidth))
            {
                isEqual = isEqual && FloatsEqual(computedWidth , other.computedWidth);
            }

            if (!YogaIsUndefined(computedHeight) || !YogaIsUndefined(other.computedHeight))
            {
                isEqual = isEqual && FloatsEqual(computedHeight , other.computedHeight);
            }

            return isEqual;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YGCachedMeasurement)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = availableWidth.GetHashCode();
                hashCode = (hashCode * 397) ^ availableHeight.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)widthMeasureMode;
                hashCode = (hashCode * 397) ^ (int)heightMeasureMode;
                hashCode = (hashCode * 397) ^ computedWidth.GetHashCode();
                hashCode = (hashCode * 397) ^ computedHeight.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(YGCachedMeasurement left, YGCachedMeasurement right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(YGCachedMeasurement left, YGCachedMeasurement right)
        {
            return !Equals(left, right);
        }
    }


    public class Values<T> where T : struct, IConvertible
    {
        readonly protected CompactValue[] _values;

        public Values()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enum");

            var size = Enum.GetValues(typeof(T)).Length;
            _values = new CompactValue[size];
            _values.Fill(CompactValue.Undefined);
        }

        public Values(YGValue defaultValue) : this()
        {
            var cv = new CompactValue(defaultValue);
            _values.Fill(cv);
        }

        public CompactValue this[int i]
        {
            get => _values[i];
            set => _values[i] = value;
        }

        public CompactValue this[T i]
        {
            get => _values[Convert.ToInt32(i)];
            set => _values[Convert.ToInt32(i)] = value;
        }

        protected bool Equals(Values<T> other)
        {
            return _values.SequenceEqual(other._values);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Values<T>)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return (_values != null ? _values.GetHashCode() : 0);
        }

        public static bool operator ==(Values<T> left, Values<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Values<T> left, Values<T> right)
        {
            return !Equals(left, right);
        }
    }

}

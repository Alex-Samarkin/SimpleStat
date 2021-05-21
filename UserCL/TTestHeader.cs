using System;
using System.ComponentModel;

namespace UserCL
{
    public class TTestHeader : IEquatable<TTestHeader>
    {
        [Category("Заголовок")]
        [DisplayName("Первая строка")]
        [Description("Первая строка")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public string Header1 { get; set; } = "Министерство высшего образования";

        [Category("Заголовок")]
        [DisplayName("Вторая строка")]
        [Description("Вторая строка")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public string Header2 { get; set; } = "Псковский государственный университет";

        public override string ToString()
        {
            return $"{nameof(Header1)}: {Header1}, {nameof(Header2)}: {Header2}";
        }

        #region Equality members

        public bool Equals(TTestHeader other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Header1 == other.Header1 && Header2 == other.Header2;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TTestHeader) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Header1 != null ? Header1.GetHashCode() : 0) * 397) ^ (Header2 != null ? Header2.GetHashCode() : 0);
            }
        }

        public static bool operator ==(TTestHeader left, TTestHeader right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TTestHeader left, TTestHeader right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
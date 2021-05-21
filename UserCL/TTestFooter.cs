using System;
using System.ComponentModel;

namespace UserCL
{
    public class TTestFooter : IEquatable<TTestFooter>
    {
        [Category("Сноски")]
        [DisplayName("Первая строка")]
        [Description("Обычно город Псков")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public string Footer1 { get; set; } = "г. Псков";

        [Category("Сноски")]
        [DisplayName("Вторая строка")]
        [Description("Обычно год - считается автоматически")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public string Footer2 { get; set; } = $"{DateTime.Today.Year} год";

        public override string ToString()
        {
            return $"{nameof(Footer1)}: {Footer1}, {nameof(Footer2)}: {Footer2}";
        }

        #region Equality members

        public bool Equals(TTestFooter other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Footer1 == other.Footer1 && Footer2 == other.Footer2;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TTestFooter) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Footer1 != null ? Footer1.GetHashCode() : 0) * 397) ^ (Footer2 != null ? Footer2.GetHashCode() : 0);
            }
        }

        public static bool operator ==(TTestFooter left, TTestFooter right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TTestFooter left, TTestFooter right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
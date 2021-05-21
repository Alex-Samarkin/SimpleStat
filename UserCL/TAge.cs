using System;
using System.ComponentModel;

namespace UserCL
{
    public class TAge : IEquatable<TAge>
    {
        [Category("Возраст")]
        [DisplayName("Дата рождения")]
        [NotifyParentProperty(true)]
        public DateTime BirthDateTime { get; set; } = DateTime.Today;

        [Category("Возраст")]
        [DisplayName("Возраст")]
        [NotifyParentProperty(true)]
        public int Age
        {
            get => (DateTime.Today.Year - BirthDateTime.Year);
            set => BirthDateTime = BirthDateTime.AddYears(-value);
        }

        public string GetAgeWithDate()
        {
            return $"{Age} / {BirthDateTime.Date}";
        }

        public override string ToString()
        {
            return $"{nameof(BirthDateTime)}: {BirthDateTime}, {nameof(Age)}: {Age}";
        }

        #region Equality members

        public bool Equals(TAge other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return BirthDateTime.Equals(other.BirthDateTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TAge) obj);
        }

        public override int GetHashCode()
        {
            return BirthDateTime.GetHashCode();
        }

        public static bool operator ==(TAge left, TAge right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TAge left, TAge right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
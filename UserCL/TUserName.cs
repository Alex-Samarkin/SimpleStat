using System;
using System.ComponentModel;

namespace UserCL
{
    public class TUserName : IEquatable<TUserName>
    {
        [Category("ФИО")]
        [DisplayName("Имя")]
        [NotifyParentProperty(true)]
        public string FirstName { get; set; } = "Имя";

        [Category("ФИО")]
        [DisplayName("Отчество")]
        [NotifyParentProperty(true)]
        public string SurName { get; set; } = "Отчество";

        [Category("ФИО")]
        [DisplayName("Фамилия")]
        [NotifyParentProperty(true)]
        public string LastName { get; set; } = "Фамилия";

        public string FullName() => LastName + " " + FirstName + " " + SurName;
        public string ShortName() => LastName + " " + FirstName[0] + "." + SurName[0]+".";

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}, {nameof(SurName)}: {SurName}, {nameof(LastName)}: {LastName}";
        }

        #region Equality members

        public bool Equals(TUserName other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return LastName == other.LastName && FirstName == other.FirstName && SurName == other.SurName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TUserName) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SurName != null ? SurName.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(TUserName left, TUserName right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TUserName left, TUserName right)
        {
            return !Equals(left, right);
        }

        #endregion
    }

}
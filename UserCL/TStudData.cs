using System;
using System.ComponentModel;
using System.Linq;

namespace UserCL
{
    public class TStudData : IEquatable<TStudData>
    {
        [Category("Курс и группа")]
        [DisplayName("Университет")]
        [NotifyParentProperty(true)]
        public string Univer { get; set; } = "Псковский государственный университет";

        [Category("Курс и группа")]
        [DisplayName("Институт")]
        [NotifyParentProperty(true)]
        public string Institut { get; set; } = "Технических наук";

        [Category("Курс и группа")]
        [DisplayName("Факультет")]
        [NotifyParentProperty(true)]
        public string Facultet { get; set; } = "ММФ";

        [Category("Курс и группа")]
        [DisplayName("Кафедра")]
        [NotifyParentProperty(true)]
        public string Kafedra { get; set; } = "Технологии машиностроения";

        [Category("Курс и группа")]
        [DisplayName("Курс")]
        [NotifyParentProperty(true)]
        public int Course { get; set; } = 4;

        [Category("Курс и группа")]
        [DisplayName("Группа")]
        [NotifyParentProperty(true)]
        public string Group { get; set; } = "004-002";

        public string GetShortGroup()
        {
            string[]s = Group.Split("-;,.=/".ToCharArray());
            return s.Last();
        }

        public override string ToString()
        {
            return $"{nameof(Univer)}: {Univer}, {nameof(Institut)}: {Institut}, {nameof(Facultet)}: {Facultet}, {nameof(Kafedra)}: {Kafedra}, {nameof(Course)}: {Course}, {nameof(Group)}: {Group}";
        }

        #region Overrides of Object

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Univer != null ? Univer.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Institut != null ? Institut.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Facultet != null ? Facultet.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Kafedra != null ? Kafedra.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Course;
                hashCode = (hashCode * 397) ^ (Group != null ? Group.GetHashCode() : 0);
                return hashCode;
            }
        }

        #region Equality members

        public bool Equals(TStudData other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Univer == other.Univer && Institut == other.Institut && Facultet == other.Facultet && Kafedra == other.Kafedra && Course == other.Course && Group == other.Group;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TStudData) obj);
        }

        public static bool operator ==(TStudData left, TStudData right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TStudData left, TStudData right)
        {
            return !Equals(left, right);
        }

        #endregion

        #endregion
    }
}
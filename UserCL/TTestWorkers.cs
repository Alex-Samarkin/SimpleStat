using System;
using System.ComponentModel;

namespace UserCL
{
    public class TTestWorkers : IEquatable<TTestWorkers>
    {
        [Category("Автор и преподаватель")]
        [DisplayName("Автор работы")]
        [Description("Автор работы")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public TUserName StudName { get; set; } = new TUserName()
            {FirstName = "Иван", SurName = "Иванович", LastName = "Иванов"};

        [Category("Автор и преподаватель")]
        [DisplayName("Преподаватель")]
        [Description("Преподаватель")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public TUserName TeacherName { get; set; } = new TUserName()
            { FirstName = "Алексей", SurName = "Никандрович", LastName = "Супрунов" };

        public override string ToString()
        {
            return $"{nameof(StudName)}: {StudName}, {nameof(TeacherName)}: {TeacherName}";
        }

        #region Equality members

        public bool Equals(TTestWorkers other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(StudName, other.StudName) && Equals(TeacherName, other.TeacherName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TTestWorkers) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((StudName != null ? StudName.GetHashCode() : 0) * 397) ^ (TeacherName != null ? TeacherName.GetHashCode() : 0);
            }
        }

        public static bool operator ==(TTestWorkers left, TTestWorkers right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TTestWorkers left, TTestWorkers right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
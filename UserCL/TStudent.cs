using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCL
{
    public class TStudent : IEquatable<TStudent>
    {
        protected TAge _age = new TAge();
        protected TUserName _userName = new TUserName();
        protected TStudData _studData = new TStudData();

        [Category("ФИО")]
        [DisplayName("Имя студента")]
        [Description("Фамилия, имя, отчество")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public TUserName UserName
        {
            get { return _userName; }
            //set { _userName = value; }
        }
        [Category("Возраст")]
        [DisplayName("Возраст")]
        [Description("Возраст и дата рождения")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public TAge Age
        {
            get { return _age; }
        }
        [Category("Курс")]
        [DisplayName("Курс, группа")]
        [Description("Сведения о месте обучения студента и текущей дисциплине")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public TStudData StudData
        {
            get { return _studData; }
        }

        public override string ToString()
        {
            return $"{nameof(UserName)}: {UserName}, {nameof(Age)}: {Age}, {nameof(StudData)}: {StudData}";
        }

        #region Equality members

        public bool Equals(TStudent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(_age, other._age) && Equals(_userName, other._userName) && Equals(_studData, other._studData);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TStudent) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_age != null ? _age.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_userName != null ? _userName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_studData != null ? _studData.GetHashCode() : 0);
                return hashCode;
            }
        }

        [Category("Система")]
        [DisplayName("Условный код")]
        [Description("Условный код студента, справочно, установите курсор в строку после изменений для обновления")]
        [ReadOnly(true)]
        [NotifyParentProperty(true)]
        public int HashCode
        {
            get => GetHashCode();
        }

        public static bool operator ==(TStudent left, TStudent right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TStudent left, TStudent right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}

using System;
using System.ComponentModel;

namespace UserCL
{
    public class TTestTitle : IEquatable<TTestTitle>
    {
        public enum KindOfWorks
        {
            [Description("Краткая проверка")]
            ShortCheck,
            [Description("Тест")]
            Test,
            [Description("Реферат")]
            Referat,
            [Description("Лабораторная, практическая работа")]
            Work,
            [Description("Тезисы, статья")]
            DayliWork,
            [Description("Курсовая работа")]
            CourseWork,
            [Description("Курсовой проект")]
            CourseProject,
            [Description("Дипломная работа")]
            Diplom,
            [Description("Диссертация (бакалавр)")]
            DissertationBachelor,
            [Description("Диссертация (магистр)")]
            DissertationMagister,
            [Description("Диссертация")]
            Dissertation
        }

        [Category("Название")]
        [DisplayName("Вид работы")]
        [Description("Вид работы")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public KindOfWorks KindOfWork { get; set; } = KindOfWorks.Work;

        [Category("Название")]
        [DisplayName("Дисциплина")]
        [Description("Дисциплина")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public string AcademicDiscipline { get; set; } = "Обработка экспериментальных данных";

        [Category("Название")]
        [DisplayName("Название")]
        [Description("Название")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public string Title { get; set; } = "Практическая работа №1";

        [Category("Название")]
        [DisplayName("Подзаголовок")]
        [Description("Подзаголовок, вторая строка названия")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public string SubTitle { get; set; } = "Отчет о работе";

        [Category("Название")]
        [DisplayName("Тема работы")]
        [Description("Содержательное название работы")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public string Theme { get; set; } = "Исследование инерционных систем второго порядка";


        public override string ToString()
        {
            return $"{nameof(KindOfWork)}: {KindOfWork}, {nameof(AcademicDiscipline)}: {AcademicDiscipline}, {nameof(Title)}: {Title}, {nameof(SubTitle)}: {SubTitle}, {nameof(Theme)}: {Theme}";
        }

        #region Equality members

        public bool Equals(TTestTitle other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return KindOfWork == other.KindOfWork && AcademicDiscipline == other.AcademicDiscipline && Title == other.Title && SubTitle == other.SubTitle && Theme == other.Theme;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TTestTitle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) KindOfWork;
                hashCode = (hashCode * 397) ^ (AcademicDiscipline != null ? AcademicDiscipline.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SubTitle != null ? SubTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Theme != null ? Theme.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(TTestTitle left, TTestTitle right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TTestTitle left, TTestTitle right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
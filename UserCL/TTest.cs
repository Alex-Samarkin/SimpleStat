using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCL
{
    public class TTest
    {
        private readonly TTestHeader _testHeader = new TTestHeader();
        private readonly TTestFooter _testFooter = new TTestFooter();
        private readonly TTestWorkers _testWorkers = new TTestWorkers();
        private readonly TTestTitle _testTitle = new TTestTitle();

        [Category("Первые две строки (шапка)")]
        [DisplayName("Шапка")]
        [Description("Шапка")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public TTestHeader Header { get => _testHeader; }

        [Category("Название работы")]
        [DisplayName("Название")]
        [Description("Вид, тип работы, тема")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public TTestTitle Title { get => _testTitle; }

        [Category("Автор")]
        [DisplayName("Автор и проверяющий преподаватель")]
        [Description("Автор работы и проверяющий ее прподаватель")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public TTestWorkers Author { get=>_testWorkers; }

        [Category("Последние две строки (подвал)")]
        [DisplayName("Нижние строки")]
        [Description("Подвал - две нижние строки")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public TTestFooter Footer { get => _testFooter; }

    }
}

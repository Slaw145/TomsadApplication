using LogicConnectionAplication;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsConnectionDesktopApp
{
    [TestFixture]
    class FillingOutRowsTable
    {
        ConvertingOnDiffrentNumericSystems convert;
        FillingFields fields;

        [SetUp]
        public void Init()
        {
            convert = new ConvertingOnDiffrentNumericSystems();

            fields = new FillingFields(convert);
        }

        [Test]
        public void test_to_filling_out_field_standard_ID_when_is_fill_and_set_on_HEX()
        {
            convert.ChangeTextOnButtonSystemConverting();

            string FieldStandardID = fields.FillingField("123", "Standard ID", 2047);

            Assert.AreEqual("7B", FieldStandardID);
        }

        [Test]
        public void test_to_filling_out_field_standard_ID_when_is_fill_and_set_on_DEC()
        {
            string FieldStandardID = fields.FillingField("7B", "Standard ID", 2047);

            Assert.AreEqual("123", FieldStandardID.ToString());
        }

        [Test]
        public void test_to_filling_out_field_IDE_when_is_empty()
        {
            string FieldIDE = fields.FillFieldIDE("IDE");

            Assert.AreEqual("0", FieldIDE.ToString());
        }

        [Test]
        public void test_to_filling_out_field_IDE_when_is_fill()
        {
            string FieldIDE = fields.FillFieldIDE("asdasd");

            Assert.AreEqual("1", FieldIDE.ToString());
        }

        [Test]
        public void test_to_filling_out_field_RTR_when_is_empty()
        {
            string FieldRTR = fields.FillFieldRTR("RTR");

            Assert.AreEqual("0", FieldRTR.ToString());
        }

        [Test]
        public void test_to_filling_out_field_RTR_when_is_fill()
        {
            string FieldRTR = fields.FillFieldRTR("asdasd");

            Assert.AreEqual("1", FieldRTR.ToString());
        }

        [Test]
        public void test_to_filling_out_field_Extended_ID_with_value_HEX()
        {
            string FieldStandardID = fields.FillingField("123", "Extended ID", 262143);

            Assert.AreEqual("291", FieldStandardID);
        }

        [Test]
        public void test_to_filling_out_field_Extended_ID_with_value_DEC()
        {
            string FieldStandardID = fields.FillingField("7B", "Extended ID", 262143);

            Assert.AreEqual("123", FieldStandardID);
        }

        [Test]
        public void test_to_filling_out_field_Extended_ID_when_is_empty()
        {
            string FieldStandardID = fields.FillingField("Extended ID", "Extended ID", 262143);

            Assert.AreEqual("1", FieldStandardID);
        }

    }
}

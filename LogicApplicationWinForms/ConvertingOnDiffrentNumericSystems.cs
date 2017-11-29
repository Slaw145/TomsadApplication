using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicConnectionAplication
{
    public interface IConvertingNumericSystems
    {
        string FormatType { get; set; }
        string ChangeTextOnButtonSystemConverting();
        string ChangeValueInInputOnHEXSystem(int MaxValue, string valueColumn);
        string ChangeValueInInputOnDECSystem(int MaxValue, string valueColumn);
        int ConvertingValueOnHEXSystem(string value);
        int ConvertingValueOnDECSystem(string value);
        string[] ConvertColumnsTableGridOnHEX(List<string> column);
        string[] ConvertColumnsTableGridOnDEC(List<string> column);
    }

    public class ConvertingOnDiffrentNumericSystems : IConvertingNumericSystems
    {
        private string _formatType = "Data format: DEC";
        public string FormatType { get => _formatType; set=> _formatType = value; }

        public string ChangeTextOnButtonSystemConverting()
        {
            switch (_formatType)
            {
                case "Data format: DEC":
                    FormatType= "Data format: HEX";
                    break;
                case "Data format: HEX":
                    FormatType = "Data format: DEC";
                    break;
            }

            return FormatType;
        }

        public string[] ConvertColumnsTableGridOnHEX(List<string> column)
        {
            string[]ValuesWithChangeingSystemHEX = new string[column.Count];

            for (int i = 0; i < column.Count; i++)
            {
                string HEXValue = ConvertingValueOnHEXSystem(column[i]).ToString("X");

                ValuesWithChangeingSystemHEX[i] = HEXValue;
            }

            return ValuesWithChangeingSystemHEX;
        }

        public string[] ConvertColumnsTableGridOnDEC(List<string> column)
        {
            string[] ValuesWithChangeingSystemDEC = new string[column.Count];

            for (int i = 0; i < column.Count; i++)
            {
                string DECValue = ConvertingValueOnDECSystem(column[i]).ToString();

                ValuesWithChangeingSystemDEC[i] = DECValue;
            }

            return ValuesWithChangeingSystemDEC;
        }

        public int ConvertingValueOnHEXSystem(string value)
        {
            return int.Parse(value);
        }

        public int ConvertingValueOnDECSystem(string value)
        {
            return Convert.ToInt32(value, 16);
        }

        public string ChangeValueInInputOnHEXSystem(int MaxValue, string valueColumn)
        {
            try
            {
                int decValue = ConvertingValueOnHEXSystem(valueColumn);

                decValue = CheckIfFieldHasToBigValue(MaxValue, decValue);

                return decValue.ToString("X");
            }
            catch(FormatException)
            {
                return "5";
            }
        }

        public string ChangeValueInInputOnDECSystem(int MaxValue, string valueColumn)
        {
            try
            {
                int decValue = ConvertingValueOnDECSystem(valueColumn);

                decValue = CheckIfFieldHasToBigValue(MaxValue, decValue);

                return decValue.ToString();
            }
            catch (FormatException)
            {
                return "3";
            }
        }

        private int CheckIfFieldHasToBigValue(int MaxValue, int decValue)
        {
            if (decValue > MaxValue)
            {
                return 2;
            }
            else
            {
                return decValue;
            }
        }
    }
}

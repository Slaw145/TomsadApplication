using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicConnectionAplication
{
    public class FillingFields
    {
        IConvertingNumericSystems convertingSystems;

        public FillingFields(IConvertingNumericSystems convertingSystems)
        {
            this.convertingSystems = convertingSystems;
        }

        public string FillingField(string valueColumn, string TypeColumn, int MaxValue)
        {
            if (valueColumn == TypeColumn)
            {
                return "1";
            }
            else if (valueColumn != TypeColumn && convertingSystems.FormatType == "Data format: DEC")
            {
                return convertingSystems.ChangeValueInInputOnDECSystem(MaxValue, valueColumn);
            }
            else
            {
                return convertingSystems.ChangeValueInInputOnHEXSystem(MaxValue, valueColumn);
            }
        }

        public string FillFieldIDE(string valueColumn)
        {
            if (valueColumn == "IDE")
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }

        public string FillFieldRTR(string valueColumn)
        {
            if (valueColumn == "RTR")
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }
    }
}

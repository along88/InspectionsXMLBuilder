using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ComponentModel;
using System.Windows.Forms;

namespace XML
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                InspectionForm inspectionForm = new InspectionForm();
            }
            catch (Exception ex)
            {
                ErrorExceptions.OnException(ex.Message);
            }
            Console.ReadKey();
        }
    }
}

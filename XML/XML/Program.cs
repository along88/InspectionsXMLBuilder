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
                FileManager.Instance.NewFile();
                InspectionForm inspectionForm = new InspectionForm(RequestForm());
            }
            catch (Exception ex)
            {
                ErrorExceptions.OnException(ex.Message);
            }
            Console.ReadKey();
        }
        static string RequestForm()
        {
            Console.WriteLine("Addendum Type:");
            Console.WriteLine("1. Inspection Format with Data Elemnts \n2. IM - Builders Risk - Data Elements \n3. GL Rec Letter \n4. BI Addendum \n5. Operations Addendum \n6. Property Rec Letter \n7. Rec Check Inspection Form \n8. Wind Addendum");
            string response = Console.ReadLine();
            string formType = "";
            switch (response)
            {
                case "1":
                    formType = "inspection format";
                    break;
                case "2":
                    formType = "im builders risk";
                    break;
                case "3":
                    formType = "GL Rec Letter";
                    break;
                case "4":
                    formType = "BI Addendum";
                    break;
                case "5":
                    formType = "Operations Addendum";
                    break;
                case "6":
                    formType = "Property Rec Letter";
                    break;
                case "7":
                    formType = "Rec Check Inspection Form";
                    break;
                case "8":
                    formType = "Wind Addendum";
                    break;
                default:
                    Console.WriteLine("Please pick a corresponding number");
                    break;
            }
            Console.Clear();
            return formType;

        }
    }
}

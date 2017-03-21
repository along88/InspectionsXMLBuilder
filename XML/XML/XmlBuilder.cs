using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML
{
    public class XmlBuilder
    {

        private XmlDocument xmlDoc;

        static public string ControlNumber { get; set; }
        static public string NameInsured { get; set; }
        static public string PolicyNumber { get; set; }
        static public string MailingAddress { get; set; }
        static public string Carrier { get; set; }
        static public string Underwriter { get; set; }
        static public string OrderBy { get; set; }
        static public string LocationAddress { get; set; }
        static public string LocationAddress2 { get; set; }
        static public string InspectionCoName { get; set; }
        static public string InspectionCoPhone { get; set; }
        static public string FieldRep { get; set; }
        static public string DateOfSurvey { get; set; }
        static public string OrderNumber { get; set; }
        static public string ContactName { get; set; }
        static public string Title { get; set; }
        static public string PhoneNumber { get; set; }
        static public string AgencyName { get; set; }
        static public string RiskContactName { get; set; }
        static public string RiskPhoneNumber { get; set; }
        static public string TypeOfSurvey { get; set; }
        static public string Overview { get; set; }
        static public string exteriorOnly { get; set; }
        static public string Revised { get; set; }
        static public string ExtensionRequired { get; set; }
        static public string Reason { get; set; }
        static public string RealPropertyLimit { get; set; }
        static public string SpecialInstructions { get; set; }
        static public string ReportNumber { get; set; }
        static public string LocationID { get; set; }


        public XmlBuilder(string file)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            GetInspectionData();
        }

        public void GetInspectionData()
        {
            foreach (XmlNode xmlNode in xmlDoc.ChildNodes[0].ChildNodes[0])
            {
                switch (xmlNode.Name)
                {
                    case "Num1":
                        NameInsured = xmlNode.InnerText;
                        Console.WriteLine("Name Insured: " + xmlNode.InnerText);
                        break;
                    case "Num2":
                        PolicyNumber = xmlNode.InnerText;
                        Console.WriteLine("Policy#: " + xmlNode.InnerText);
                        break;
                    case "Num3":
                        ControlNumber = xmlNode.InnerText;
                        Console.WriteLine("Control#: " + ControlNumber);
                        break;
                    case "Num4":
                        MailingAddress = xmlNode.InnerText;
                        Console.WriteLine("Mailing Address: " + xmlNode.InnerText);
                        break;
                    case "Num5":
                        Carrier = xmlNode.InnerText;
                        Console.WriteLine("Carrier: " + xmlNode.InnerText);
                        break;
                    case "Num6":
                        Underwriter = xmlNode.InnerText;
                        Console.WriteLine("Underwriter: " + xmlNode.InnerText);
                        break;
                    case "Num7":
                        OrderBy = xmlNode.InnerText;
                        Console.WriteLine("Ordered by: " + ControlNumber);
                        break;
                    case "Num8":
                        LocationAddress = xmlNode.InnerText;
                        Console.WriteLine("Location Address: " + xmlNode.InnerText);
                        break;
                    case "Num9":
                        LocationAddress2 = xmlNode.InnerText;
                        Console.WriteLine("Location Address2: " + xmlNode.InnerText);
                        break;
                    case "Num10":
                        InspectionCoName = xmlNode.InnerText;
                        Console.WriteLine("Inspection Co. Name: " + xmlNode.InnerText);
                        break;
                    case "Num11":
                        InspectionCoPhone = xmlNode.InnerText;
                        Console.WriteLine("Inspection Co. Phone#: " + xmlNode.InnerText);
                        break;
                    case "Num12":
                        FieldRep = xmlNode.InnerText;
                        Console.WriteLine("Field Rep Name: " + xmlNode.InnerText);
                        break;
                    case "Num13":
                        DateOfSurvey = xmlNode.InnerText;
                        Console.WriteLine("DateOfSurvey: " + ControlNumber);
                        break;
                    case "Num14":
                        OrderNumber = xmlNode.InnerText;
                        Console.WriteLine("OrderNumber: " + ControlNumber);
                        break;
                    case "ReportNumber":
                        ReportNumber = xmlNode.InnerText;
                        Console.WriteLine("Report#: " + xmlNode.InnerText);
                        break;
                    case "LocationID":
                        LocationID = xmlNode.InnerText;
                        Console.WriteLine("Location ID: " + xmlNode.InnerText);
                        break;
                    default:
                        break;
                }

            }
        }
    }
}

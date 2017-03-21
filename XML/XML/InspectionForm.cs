using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Xml;


namespace XML
{
    public class InspectionForm
    {
        //this class should allow us to create word documents
        private string nameInsured ="Name Insured: ";
        private string policyNumber = "Policy Number: ";
        private string controlNumber = "Control #: ";
        private string mailingAddress = "Mailing Address: ";
        private string carrier = "Carrier: ";
        private string underwriter = "Underwriter: ";
        private string orderBy = "Ordered by: ";
        private string locationAddress = "location Address: ";
        private string locationAddress2 = "location Address: ";
        private string inspectionCoName ="Inspection Co. Name: ";
        private string inspectionCoPhone = "Inspection Co. Phone #: ";
        private string fieldRep = "Field Rep Name: ";
        private string dateOfSurvey = "Date of Survey: ";
        private string orderNumber = "Order Number: ";
        private string riskContactName = "Contact Name: ";
        private string riskTitle = "Title: ";
        private string riskPhoneNumber = "Phone Number: ";
        private string agencyName = "Agency Name: ";
        private string brokerContactName = "Contact Name: ";
        private string brokerPhoneNumber = "Phone Number: ";
        private string typeOfSurvey = "Type of Survey: ";
        private string overview = "Overview:";
        private string exteriorOnly = "Exterior Only:";
        private string revised = "Revised: ";
        private string extensionRequired = "Extension required?/ Reason";
        private string realPropertyLimit = "Real Property Limit: ";
        private string specialInstructions = "Special Instructions/UnderWriter Concerns addressed: ";

        Application winword;
        Document winDoc;

        public InspectionForm()
        {
            CreateDocument();
        }

        private void CreateDocument()
        {
            winword = new Application();
            winword.Visible = true;
            object missing = System.Reflection.Missing.Value;

            winDoc = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

            foreach (Section section in winDoc.Sections)
            {
                Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                headerRange.Font.Size = 11;
                headerRange.Font.Name = "Times New Roman";
                headerRange.Font.ColorIndex = WdColorIndex.wdBlack;
                headerRange.Text = "WKFC UNDERWRITING MANAGERS INSPECTION FORM"; 
            }
            PopulateDocument();


        }

        public void PopulateDocument()
        {
            winDoc.Content.Font.Bold = 1;
            winDoc.Content.Font.Name = "Times New Roman";
            winDoc.Content.SetRange(0,0);

            winDoc.Content.Text = string.Format(
                "{0}" + XmlBuilder.NameInsured + Environment.NewLine +
                "{1}" + XmlBuilder.PolicyNumber + "                        " +
                "{2}" + XmlBuilder.ControlNumber + Environment.NewLine +
                "{3}" + XmlBuilder.MailingAddress + Environment.NewLine +
                "{4}" + XmlBuilder.Carrier + Environment.NewLine +
                "{5}" + XmlBuilder.Underwriter + "                        " +
                "{6}" + XmlBuilder.OrderBy + Environment.NewLine +
                "{7}" + XmlBuilder.LocationAddress + Environment.NewLine +
                "{8}" + XmlBuilder.LocationAddress2+ Environment.NewLine +
                "{9}" + XmlBuilder.InspectionCoName + "                        " +
                "{10}" + XmlBuilder.DateOfSurvey + Environment.NewLine +
                "{11}" + XmlBuilder.InspectionCoPhone + "                        " +
                "{12}" + XmlBuilder.OrderNumber + Environment.NewLine +
                "{13}" + XmlBuilder.FieldRep + Environment.NewLine
                , nameInsured,
                policyNumber,
                controlNumber,
                mailingAddress,
                carrier,
                underwriter,
                orderBy,
                locationAddress,
                locationAddress2,
                inspectionCoName,
                dateOfSurvey,
                inspectionCoPhone,
                orderNumber,
                fieldRep);
            //winDoc.Content.Text = controlNumber += XmlBuilder.ControlNumber + Environment.NewLine;

        }

        




    }
}

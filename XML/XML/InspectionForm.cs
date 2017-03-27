using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;


namespace XML
{
    public class InspectionForm
    {
        private object missing = System.Reflection.Missing.Value;
        private object fileName = @"C:\Users\along\Desktop\Inspections\WKFC  Inspection format with data elements.doc";
        private Application wordApp;
        private Document inspectionDoc;
        private int DebugTableCount = 14;

        public InspectionForm()
        {
            //CreateDocument();
            FileManager.Instance.NewFile();
            InitializeInspectionForm();
        }
        
        //private void CreateDocument()
        //{
        //    winword = new Application();
        //    winword.Visible = false;
        //    object missing = System.Reflection.Missing.Value;

        //    winDoc = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

        //    foreach (Section section in winDoc.Sections)
        //    {
        //        Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
        //        headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
        //        headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
        //        headerRange.Font.Size = 11;
        //        headerRange.Font.Name = "Times New Roman";
        //        headerRange.Font.ColorIndex = WdColorIndex.wdBlack;
        //        headerRange.Text = "WKFC UNDERWRITING MANAGERS INSPECTION FORM"; 
        //    }
        //    PopulateDocument();
        //    PopulateRiskInfo();


        //}

        //private void PopulateDocument()
        //{
        //    SetDocumentFont();

        //    winDoc.Content.Text = string.Format(
        //        "{0}" + XmlBuilder.NameInsured + Environment.NewLine +
        //        "{1}" + XmlBuilder.PolicyNumber + "                        " +
        //        "{2}" + XmlBuilder.ControlNumber + Environment.NewLine +
        //        "{3}" + XmlBuilder.MailingAddress + Environment.NewLine +
        //        "{4}" + XmlBuilder.Carrier + Environment.NewLine +
        //        "{5}" + XmlBuilder.Underwriter + "                        " +
        //        "{6}" + XmlBuilder.OrderBy + Environment.NewLine +
        //        "{7}" + XmlBuilder.LocationAddress + Environment.NewLine +
        //        "{8}" + XmlBuilder.LocationAddress2+ Environment.NewLine +
        //        "{9}" + XmlBuilder.InspectionCoName + "                        " +
        //        "{10}" + XmlBuilder.DateOfSurvey + Environment.NewLine +
        //        "{11}" + XmlBuilder.InspectionCoPhone + "                        " +
        //        "{12}" + XmlBuilder.OrderNumber + Environment.NewLine +
        //        "{13}" + XmlBuilder.FieldRep + Environment.NewLine
        //        , nameInsured,
        //        policyNumber,
        //        controlNumber,
        //        mailingAddress,
        //        carrier,
        //        underwriter,
        //        orderBy,
        //        locationAddress,
        //        locationAddress2,
        //        inspectionCoName,
        //        dateOfSurvey,
        //        inspectionCoPhone,
        //        orderNumber,
        //        fieldRep);


        //}
        /// <summary>
        /// Initializes a Inspect Form Word Document and populates it's fields with the xml data
        /// </summary>
        private void InitializeInspectionForm()
        {
            wordApp = new Application();
            wordApp.Visible = false;
            inspectionDoc = new Document();
            inspectionDoc = wordApp.Documents.Open(ref fileName, ReadOnly: false);
            Console.Write("Debugger: Populating Word Document."+ Environment.NewLine+"Please Wait.");
            FillInspectionForm();
            Console.WriteLine("Complete!");
            wordApp.Visible = true;
        }

        private void VerticallyAlignedTable(int tableID)
        {
            Table table = inspectionDoc.Tables[tableID];
            Range range = table.Range;
            for (int j = 1; j < range.Cells.Count; j++)
            {

                foreach (KeyValuePair<string, string> key in XmlBuilder.ElementNodes)
                {
                    if (range.Cells[j].Range.Text.Contains(string.Format("<{0}>", key.Key)))
                    {
                        range.Cells[j].Range.Text = key.Value;
                        Console.Write('.');
                        break;
                    }
                }
            }

        }
        private void NormalTable(int tableID)
        {
            foreach (Row item in inspectionDoc.Tables[tableID].Rows)
            {
                
                foreach (Cell cell in item.Cells)
                {
                    foreach (KeyValuePair<string, string> key in XmlBuilder.ElementNodes)
                    {
                        if (cell.Range.Text.Contains(string.Format("<{0}>", key.Key)))
                        {
                            cell.Range.Text = key.Value;
                            Console.Write('.');
                            break;
                        }

                    }
                }
            }
        }
        //private void FillMissingTableItems(int tableID)
        //{
        //    foreach (Row item in inspectionDoc.Tables[tableID].Rows)
        //    {

        //        foreach (Cell cell in item.Cells)
        //        {
        //            foreach (KeyValuePair<string, string> key in XmlBuilder.ElementNodes)
        //            {
        //                if (cell.Range.Text.Contains("<"))
        //                {
        //                    cell.Range.Text = "Not Found";
        //                    break;
        //                }

        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// Fills in the inspection form using the XmlBuilders dictionary
        /// </summary>
        /// <param name="inspectionDoc"></param>
        /// <param name="wordApp"></param>
        private void FillInspectionForm()
        {


            try
            {
                for (int i = 1; i < inspectionDoc.Tables.Count ; i++)
                {
                    if (i == 13 || i == 19)
                    {
                        VerticallyAlignedTable(i);
                        continue;
                    }
                    else
                    {
                        NormalTable(i);
                        continue;
                    }
                   
                }
                
                Console.WriteLine();
                inspectionDoc.Activate();
            }
            catch (Exception ex)
            {
                ErrorExceptions.OnException(ex.Message);
                inspectionDoc.Application.Quit(ref missing, ref missing, ref missing);
            }
        }
    }
}

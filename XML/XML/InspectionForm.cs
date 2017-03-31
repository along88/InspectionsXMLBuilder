using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;

namespace XML
{
    public class InspectionForm
    {
        private object missing = System.Reflection.Missing.Value; 
        private object fileName = ""; //filename of the given word document
        private Application wordApp; 
        private Document inspectionDoc;
        private Dictionary<string, string> foundElements; //reference to XmlBuilder's dictionary

        public InspectionForm(string form)
        {
            GetFileName(form); 
            InitializeInspectionForm();
        }
       
        /// <summary>
        /// Initializes Word Application and Fill it's content with the XML dictionary
        /// </summary>
        private void InitializeInspectionForm()
        {
            wordApp = new Application();
            wordApp.Visible = false;
            inspectionDoc = new Document();
            inspectionDoc = wordApp.Documents.Open(ref fileName, ReadOnly: false);
            foundElements = XmlBuilder.ElementNodes;
            Console.Write("Building Document"+ Environment.NewLine+"Please Wait.");
            FillInspectionForm();
            Console.WriteLine("Complete!");
            wordApp.Visible = true;
        }
        
        /// <summary>
        /// Fills in the inspection form using the XmlBuilders dictionary
        /// </summary>
        /// <param name="inspectionDoc"></param>
        /// <param name="wordApp"></param>
        private void FillInspectionForm()
        {
            int percentage;
            try
            {
                for (int i = 0; i < inspectionDoc.Tables.Count; i++)
                {
                    foreach (Cell cell in inspectionDoc.Tables[i+1].Range.Cells)
                    {
                        if (cell.Range.Text[0].Equals('<'))
                        {
                            foreach (var key in foundElements)
                            {
                                if (cell.Range.Text.Contains(String.Format("{0}", key.Key)))
                                {
                                    cell.Range.Text = key.Value;
                                    foundElements.Remove(key.Key);
                                    break;
                                }
                            }
                        }
                    }
                    Console.SetCursorPosition(0, 2);
                    percentage = (i * 100/inspectionDoc.Tables.Count);
                    Console.Write(percentage.ToString()+"%");
                }
                Console.SetCursorPosition(0, 2);
                Console.Write("100%");
                Console.WriteLine();
                inspectionDoc.Activate();
               
            }
            catch (Exception ex)
            {
                ErrorExceptions.OnException(ex.Message);
                inspectionDoc.Application.Quit(ref missing, ref missing, ref missing);
            }
        }

        /// <summary>
        /// Loads the specified Inspection Form Template
        /// </summary>
        /// <param name="form"></param>
        private void GetFileName(string form)
        {
            switch (form)
            {
                case "inspection format":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\WKFCInspectionformat.doc";
                    break;
                case "im builders risk":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\imbuildersriskdataelements.doc";
                    break;
                case "GL Rec Letter":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\GLRecLetter.doc";
                    break;
                case "BI Addendum":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\BIADDENDUM.doc";
                    break;
                case "Operations Addendum":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\OPERATIONSADDENDUM.doc";
                    break;
                case "Property Rec Letter":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\PropertyRecLetter.doc";
                    break;
                case "Rec Check Inspection Form":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\RECCHECKINSPECTIONFORM.docx";
                    break;
                case "Wind Addendum":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\WindAddendum.docx";
                    break;
                default:
                    break;
            }
        }
    }
}

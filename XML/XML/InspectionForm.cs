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
        private List<Dictionary<string, string>> foundElements; //reference to XmlBuilder's dictionary
        //private Dictionary<string, string> foundElements2;
        private List<string> DocumentList = new List<string>();
        public InspectionForm(string form)
        {
            GetFileName(form);
            Console.Write("Building Document" + Environment.NewLine + "Please Wait.");
            FillInspectionForm();
            Console.WriteLine("Complete!");
            wordApp.Visible = true;
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
                            for (int k = 0; k < foundElements.Count; k++)
                            {
                                if(foundElements[k] == null)
                                {
                                    continue;
                                }
                                foreach(var key in foundElements[k])
                                {
                                    if (cell.Range.Text.Contains(String.Format("<{0}>", key.Key)))
                                    {
                                        cell.Range.Text = key.Value;
                                        foundElements[k].Remove(key.Key);
                                        break;
                                    }
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
                ErrorExceptions.OnException(ex.StackTrace);
                inspectionDoc.Application.Quit(ref missing, ref missing, ref missing);
            }
        }

        /// <summary>
        /// Loads the specified Inspection Form Template
        /// </summary>
        /// <param name="form"></param>
        private void GetFileName(string form)
        {
            foundElements = new List<Dictionary<string, string>>();

            switch (form)
            {
                case "inspection format":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\WKFCInspectionformat.doc";
                    if (XmlBuilder.InspectionData != null)
                        foundElements.Add(XmlBuilder.InspectionData);
                    if (XmlBuilder.Survey != null)
                        foundElements.Add(XmlBuilder.Survey);
                    if (XmlBuilder.RecsOpinionLosses != null)
                        foundElements.Add(XmlBuilder.RecsOpinionLosses);
                    if (XmlBuilder.OperationsOccupancy != null)
                        foundElements.Add(XmlBuilder.OperationsOccupancy);
                    if (XmlBuilder.BldgInfo != null)
                        foundElements.Add(XmlBuilder.BldgInfo);
                    if (XmlBuilder.CommonHaz != null)
                        foundElements.Add(XmlBuilder.CommonHaz);
                    if (XmlBuilder.SpecialHazards != null)
                        foundElements.Add(XmlBuilder.SpecialHazards);
                    if (XmlBuilder.ProtectionSecurity != null)
                        foundElements.Add(XmlBuilder.ProtectionSecurity);
                    if (XmlBuilder.NeighboringExposures != null)
                        foundElements.Add(XmlBuilder.NeighboringExposures);
                    if (XmlBuilder.AddnandCATPerils != null)
                        foundElements.Add(XmlBuilder.AddnandCATPerils);
                    if (XmlBuilder.Misc != null)
                        foundElements.Add(XmlBuilder.Misc);
                    if (XmlBuilder.Cooking != null)
                    {
                        for (int i = 0; i < XmlBuilder.Cooking.Count; i++)
                        {
                            foundElements.Add(XmlBuilder.Cooking[i]);
                        }
                    }
                    if (XmlBuilder.Sprinkler != null)
                        foundElements.Add(XmlBuilder.Sprinkler);
                    if (XmlBuilder.GeneralLiability != null)
                        foundElements.Add(XmlBuilder.GeneralLiability);
                    InitializeInspectionForm();
                    break;
                case "im builders risk":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\imbuildersriskdataelements.doc";
                    break;
                case "GL Rec Letter":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\GLRecLetter.doc";
                    if (XmlBuilder.GLRecommendations != null)
                    {
                        for (int i = 0; i < XmlBuilder.GLRecommendations.Count; i++)
                        {
                            foundElements.Add(XmlBuilder.GLRecommendations[i]);
                        }
                    }
                    InitializeInspectionForm();
                    break;
                case "BI Addendum":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\BIADDENDUM.doc";
                    break;
                case "Operations Addendum":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\OPERATIONSADDENDUM.doc";
                    break;
                case "Property Rec Letter":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\PropertyRecLetter.doc";
                    if (XmlBuilder.PropertyRecommendations != null)
                    {
                        for (int i = 0; i < XmlBuilder.PropertyRecommendations.Count; i++)
                        {
                            foundElements.Add(XmlBuilder.PropertyRecommendations[i]);
                        }
                    }
                    InitializeInspectionForm();
                    break;
                case "Rec Check Inspection Form":
                    fileName = @"C:\Users\along\Documents\GitHub\InspectionsXMLBuilder\XML\XML\RECCHECKINSPECTIONFORM.docx";

                    if (XmlBuilder.PropertyRecommendations != null)
                    {
                        for (int i = 0; i < XmlBuilder.PropertyRecommendations.Count; i++)
                        {
                            foundElements.Add(XmlBuilder.PropertyRecommendations[i]);
                        }
                    }
                    if (XmlBuilder.GLRecommendations != null)
                    {
                            for (int i = 0; i < XmlBuilder.GLRecommendations.Count; i++)
                        {
                            foundElements.Add(XmlBuilder.GLRecommendations[i]);
                        }
                    }
                    InitializeInspectionForm();
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

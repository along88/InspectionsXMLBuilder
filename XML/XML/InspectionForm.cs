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
        private object fileName = @"C:\Users\along\Desktop\Inspections\WKFC  Inspection format with data elements.doc";
        private Application wordApp;
        private Document inspectionDoc;

        public InspectionForm()
        {
            //CreateDocument();
            FileManager.Instance.NewFile();
            InitializeInspectionForm();
        }
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
            double percentage = 0;
            int pos = 2;
            //Stopwatch sw = Stopwatch.StartNew();
           
            for (int j = 1; j < range.Cells.Count; j++)
            {
                if (range.Cells[j].Range.Text[0] == '<')
                {
                    foreach (KeyValuePair<string,string> key in XmlBuilder.ElementNodes)
                    {
                        if (range.Cells[j].Range.Text.Contains(String.Format("<{0}>", key.Key)))
                            range.Cells[j].Range.Text = key.Value;
                        
                    }
                    
                }


               // Console.WriteLine(sw.ElapsedMilliseconds.ToString());
            }
            //sw.Stop();
         }
        /// <summary>
        /// Fills in the inspection form using the XmlBuilders dictionary
        /// </summary>
        /// <param name="inspectionDoc"></param>
        /// <param name="wordApp"></param>
        private void FillInspectionForm()
        {
            try
            {
                for (int i = 0; i < inspectionDoc.Tables.Count; i++)
                {
                    VerticallyAlignedTable(i+1);
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

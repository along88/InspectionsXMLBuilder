using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace XML
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
            file.ShowDialog();
            try
            {
                
                XmlBuilder xmlBuilder = new XmlBuilder(file.FileName);
                InspectionForm inspectionForm = new InspectionForm();
                
            }
            catch(Exception ex)
            {
                if(!file.ToString().Substring(file.ToString().Length - 3, 3).Equals("xml"))
                    MessageBox.Show("This program currently only accepts .xml extensions");
                else
                    MessageBox.Show(ex.Message);
            }
            
            Console.ReadKey();
        }

        
    }
}

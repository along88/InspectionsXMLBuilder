using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XML
{
    public class FileManager
    {
        private static OpenFileDialog file;
        private static string FileName
        {
            get { return file.FileName; }

        }
        private static  FileManager instance;
        public static FileManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileManager();
                }
                return instance;
            }
        }
        
        public void NewFile()
        {
            file = new OpenFileDialog();
            file.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
            file.FileOk += OnFileOK;
            file.ShowDialog();

        }
        private void OnFileOK(object sender, EventArgs e)
        {
            try
            {
             XmlBuilder.Instance.GetInspectionData(FileName);
            }
            catch(Exception ex)
            {
                if (!file.ToString().Substring(file.ToString().Length - 3, 3).Equals("xml"))
                    ErrorExceptions.OnException("please select a file with .xml extension");
                else
                    ErrorExceptions.OnException(ex.Message);
            }

        }
    }
}

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
        private static XmlBuilder instance;
        private static XmlNodeList xmlNodes;
        public static  XmlBuilder Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new XmlBuilder();
                }
                return instance;
            }
        }
        static public Dictionary<string, string> ElementNodes { get; private set; }
        
        /// <summary>
        /// Populates ElementNodes with the selected XML's content where the element name matches a
        /// desired case value
        /// </summary>
        private void populate(XmlDocument xmlDoc)
        {
            xmlNodes = xmlDoc.ChildNodes[0].ChildNodes;
            for (int i = 0; i < xmlNodes.Count; i++)
            {
                foreach (XmlNode xmlNode in xmlNodes[i])
                {
                    if (xmlNode.InnerText.Equals(""))
                        ElementNodes.Add(xmlNode.Name, "EMPTY!");
                    else
                        ElementNodes.Add(xmlNode.Name, xmlNode.InnerText);
                }
            }
            
        }
        
        /// <summary>
        /// Iterates through a given IMS inspection XML file
        /// </summary>
        /// <param name="xmlfile"></param>
        public void GetInspectionData(string xmlfile)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlfile);
            ElementNodes = new Dictionary<string, string>();
            try
            {
                populate(xmlDoc); 
            }
            catch(Exception ex)
            {
                ErrorExceptions.OnException(ex.Message);

            }   
        }
    }
}

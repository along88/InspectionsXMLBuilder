using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace XML
{
    public class XmlBuilder
    {
        private static XmlBuilder instance;
        private static XmlNodeList xmlNodes;
        private static List<string> key;
        private static List<string> value;
       
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
        static public Dictionary<string, string> ElementNodes2 { get; private set; }

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
                   if (!(ElementNodes.Count >= 249))
                    {
                        if (string.IsNullOrEmpty(xmlNode.InnerText))
                            ElementNodes.Add(xmlNode.Name, "EMPTY!");
                        else
                            ElementNodes.Add(xmlNode.Name, xmlNode.InnerText);
                    }
                    else
                    {
                        ElementNodes2 = new Dictionary<string, string>();
                        if (string.IsNullOrEmpty(xmlNode.InnerText))
                            ElementNodes2.Add(xmlNode.Name, "EMPTY!");
                        else
                            ElementNodes2.Add(xmlNode.Name, xmlNode.InnerText);
                    }
                }
            }
            
        }

        /// <summary>
        /// Iterates through a given IMS inspection XML file
        /// </summary>
        /// <param name="xmlfile"></param>
        public void GetInspectionData(string xmlfile)
        {
            #region Archive
            //XmlDocument xmlDoc = new XmlDocument();

            //xmlDoc.Load(xmlfile);

            //ElementNodes = new Dictionary<string, string>();
            //try
            //{
            //    populate(xmlDoc); 
            //}
            //catch(XmlException ex)
            //{
            //    ErrorExceptions.OnException(ex.Message);
            //}   


            //XmlReader xmlReader = XmlReader.Create(xmlfile);
            //key = new List<string>();
            //value = new List<string>();
            //ElementNodes = new Dictionary<string, string>();
            //xmlReader.MoveToContent();
            //while (xmlReader.Read())
            //{
            //    switch (xmlReader.NodeType)
            //    {
            //        case XmlNodeType.Element:
            //            if (string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_SurveyInfo") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_RecsOpinionLosses") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_OperationsOccupancy") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_BldgInfo") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_CommonHaz") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_SpecialHazards") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_ProtectionSecurity") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_NeighboringExposures") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_AddnandCATPerils") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_Misc") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_GeneralLiability") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_Sprinkler") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_PropertyRecommendations") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_Cooking") ||
            //                string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_GLRecommendations"))
            //                continue;
            //            else
            //            {
            //                if (xmlReader.IsEmptyElement)
            //                {
            //                    key.Add(string.Format("<{0}>", xmlReader.Name));
            //                    value.Add("EMPTY");
            //                }
            //                else
            //                    key.Add(string.Format("<{0}>", xmlReader.Name));
            //            }
            //            break;
            //        case XmlNodeType.Text:
            //            if (!string.IsNullOrEmpty(xmlReader.Value))
            //            {
            //                string unxml = xmlReader.Value;
            //                //replace entities with literal values
            //                unxml = unxml.Replace("&amp;", "&");
            //                value.Add(string.Format("{0}", unxml));
            //            }
            //            else
            //            {

            //                value.Add("EMPTY!");
            //            }
            //            break;
            //    }
            //}
            //for (int i = 0; i < value.Count; i++)
            //    ElementNodes.Add(key[i], value[i]);
            #endregion
            ElementNodes = new Dictionary<string, string>();
            string line = "";
            string fullLine = null;
            using (StreamReader sr = new StreamReader(xmlfile))
            {
                while (true)
                {
                     line = sr.ReadLine();
                    if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
                        break;
                    
                    else if (line.Contains("&"))
                    {
                        line = line.Replace("&", "&amp;");
                        fullLine += "\n"+line;
                    }
                    else
                        fullLine += "\n"+line;
                    
                }
            }
            Console.WriteLine(fullLine);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(fullLine);
            populate(xmlDocument);
            
        }
    }
}

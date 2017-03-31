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
        
        private static bool IsValidXmlString(string text)
        {
            try
            {
                XmlConvert.VerifyXmlChars(text);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private static string RemoveInvalidXmlChars(string text)
        {
            var validXmlChars = text.Where(ch => XmlConvert.IsXmlChar(ch)).ToArray();
            return new string(validXmlChars);
        }


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


            //var xmlReaderSettings = new XmlReaderSettings { CheckCharacters = false };
            //xmlReaderSettings.DtdProcessing = DtdProcessing.Parse;
            //xmlReaderSettings.Async = true;
            XmlReader xmlReader = XmlReader.Create(xmlfile);
            key = new List<string>();
            value = new List<string>();
            ElementNodes = new Dictionary<string, string>();
            xmlReader.MoveToContent();
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_SurveyInfo") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_RecsOpinionLosses") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_OperationsOccupancy") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_BldgInfo") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_CommonHaz") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_SpecialHazards") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_ProtectionSecurity") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_NeighboringExposures") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_AddnandCATPerils") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_Misc") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_GeneralLiability") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_Sprinkler") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_PropertyRecommendations") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_Cooking") ||
                            string.Format("{0}", xmlReader.Name).Contains("WKFC_InspectionData_GLRecommendations"))
                            continue;
                        else
                        {
                            if (xmlReader.IsEmptyElement)
                            {
                                key.Add(string.Format("<{0}>", xmlReader.Name));
                                value.Add("EMPTY");
                            }
                            else
                                key.Add(string.Format("<{0}>", xmlReader.Name));
                        }
                        break;
                    case XmlNodeType.Text:
                        if (xmlReader.Value == "")
                            value.Add("EMPTY!");
                        else
                            value.Add(string.Format("{0}", xmlReader.Value));
                        break;
                }
            }
            for (int i = 0; i < value.Count; i++)
                ElementNodes.Add(key[i], value[i]);








            //var xmlDoc = new XmlDocument();
            //var xmlReaderSettings = new XmlReaderSettings { CheckCharacters = false };
            //using (var stringReader = new StringReader(xmlfile))
            //{
            //    using (var xmlReader = XmlReader.Create(stringReader, xmlReaderSettings))
            //    {
            //        xmlDoc.Load(xmlReader);

            //    }
            //}
            //populate(xmlDoc);














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
        }


        public static string CleanInvalidXmlChars(string text)
        {
            string re = @"[&\^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]";
            return Regex.Replace(text, re, "");
        }
    }
}

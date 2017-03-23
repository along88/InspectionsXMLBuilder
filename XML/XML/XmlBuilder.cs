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
        static private List<string> elementNames;
        static private List<string> excludedElementNames;
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
                    for (int j = 0; j < elementNames.Count; j++)
                    {
                        if (xmlNode.Name == elementNames[j])
                        {
                            if (xmlNode.InnerText.Equals(""))
                            {
                                ElementNodes.Add(xmlNode.Name, "N/A");
                                elementNames.RemoveAt(j);
                                break;
                            }
                            else
                            {
                                ElementNodes.Add(xmlNode.Name, xmlNode.InnerText);
                                elementNames.Remove(elementNames[j]);
                                break;
                            }
                        }
                    }
                }
            }
            excludedElementNames = elementNames;
            for (int k = 0; k < excludedElementNames.Count; k++)
                ElementNodes.Add(elementNames[k], "N/A");
            
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
            InitializeInspectionsElements();
            try
            {
                populate(xmlDoc); 
            }
            catch(Exception ex)
            {
                ErrorExceptions.OnException(ex.Message);

            }   
        }
        private void InitializeInspectionsElements()
        {
            elementNames = new List<string>();
            elementNames.Add("Num1");
            elementNames.Add("Num2");
            elementNames.Add("Num3");
            elementNames.Add("Num4");
            elementNames.Add("Num5");
            elementNames.Add("Num6");
            elementNames.Add("Num7");
            elementNames.Add("Num8");
            elementNames.Add("Num9");
            elementNames.Add("Num10");
            elementNames.Add("Num11");
            elementNames.Add("Num12");
            elementNames.Add("Num13");
            elementNames.Add("Num14");
            elementNames.Add("Num15");
            elementNames.Add("Num16");
            elementNames.Add("Num17");
            elementNames.Add("Num18");
            elementNames.Add("Num19");
            elementNames.Add("Num20");
            //Survey
            elementNames.Add("Survey1");
            elementNames.Add("Survey2");
            elementNames.Add("Survey3");
            elementNames.Add("Survey4");
            elementNames.Add("Survey5");
            elementNames.Add("Survey6");
            elementNames.Add("Survey7");
            elementNames.Add("Survey8");
            //Recs
            elementNames.Add("Recs1");
            elementNames.Add("Recs2");
            elementNames.Add("Recs3");
            //Opinions
            elementNames.Add("Opinion1");
            elementNames.Add("Opinion2");
            elementNames.Add("Opinion3");
            //Loss
            elementNames.Add("Loss1");
            elementNames.Add("Loss2");
            //Ops
            elementNames.Add("Ops1");
            elementNames.Add("Ops2");
            elementNames.Add("Ops3");
            elementNames.Add("Ops4");
            elementNames.Add("Ops5");
            elementNames.Add("Ops6");
            elementNames.Add("Ops7");
            elementNames.Add("Ops8");
            elementNames.Add("Ops9");
            elementNames.Add("Ops10");
            elementNames.Add("Ops11");
            elementNames.Add("Ops12");
            elementNames.Add("Ops13");
            elementNames.Add("Ops14");
            elementNames.Add("Ops15");
            elementNames.Add("Ops16");
            elementNames.Add("Ops17");
            elementNames.Add("Ops18");
            elementNames.Add("Ops19");
            elementNames.Add("Ops20");
            elementNames.Add("Ops21");
            elementNames.Add("Ops22");
            elementNames.Add("Ops23");
            elementNames.Add("Ops24");
            elementNames.Add("Ops25");
            elementNames.Add("Ops26");
            elementNames.Add("Ops27");
            elementNames.Add("Ops28");
            //Building Information
            elementNames.Add("Bld1");
            //Common Hazards
            //Special Hazards
            //Protection/Security
            //Neighboring Exposures
            //Perils
            //Cooking
            //Sprinkler
            //General Liability


        }

    }
}

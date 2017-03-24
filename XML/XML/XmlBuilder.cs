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
        /// Assigns the xmlNodes content to the ElementNodes dictionary and removes the found elements
        /// from the elementName list
        /// </summary>
        /// <param name="xmlNode"></param>
        private void GetElementContent(XmlNode xmlNode)
        {
            for (int j = 0; j < elementNames.Count; j++)
            {
                if (xmlNode.Name == elementNames[j])
                {
                    if (xmlNode.InnerText.Equals(""))
                    {
                        ElementNodes.Add(xmlNode.Name, string.Format("<{0}>",elementNames[j]));
                        //elementNames.RemoveAt(j);
                        elementNames.Remove(elementNames[j]);
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
                    GetElementContent(xmlNode);
                }
            }
            excludedElementNames = elementNames;
            for (int k = 0; k < excludedElementNames.Count; k++)
                ElementNodes.Add(elementNames[k], string.Format("<{0}>", elementNames[k]));
            
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
            BuildRegularInspectionForm();
            try
            {
                populate(xmlDoc); 
            }
            catch(Exception ex)
            {
                ErrorExceptions.OnException(ex.Message);

            }   
        }
        
        
        
        
        
        /// <summary>
        /// Initialize Inspections Elements
        /// </summary>
        private void InitializeInspectionsElements(int nums, int Survey, int Recs, 
            int Opinion, int Loss, int Ops, int Bld,int Ch,int Sh,int Prot,
            int Ne,int Peril,int Cook, int Sprink, int Gl)
        {
            elementNames = new List<string>();
            //Nums = 20
            for (int i = 0; i < nums; i++)
            {
                elementNames.Add(string.Format("Num{0}", i.ToString()));
            }   
            
            //Survey = 8
            for (int k = 1; k < Survey; k++)
            {
                elementNames.Add(string.Format("Survey{0}", k.ToString()));
            }
            //Recs = 3
            for (int l = 1; l < Recs; l++)
            {
                elementNames.Add(string.Format("Recs{0}", l.ToString()));
            }

            //Opinions = 3
            for (int m = 1; m < Opinion; m++)
            {
                elementNames.Add(string.Format("Opinion{0}", m.ToString()));
            }

            //Loss = 2
            for (int n = 1; n < Loss; n++)
            {
                elementNames.Add(string.Format("Loss{0}", n.ToString()));
            }
            //Ops = 28
            for (int o = 1; o < Ops; o++)
            {
                elementNames.Add(string.Format("Ops{0}", o.ToString()));
            }
            //Building Information = 45
            for (int i = 1; i < Bld; i++)
            {
                elementNames.Add(string.Format("Bld{0}", i.ToString()));
            }
            //Common Hazards
            for (int i = 1; i < Ch; i++)
            {
                elementNames.Add(string.Format("CH{0}", i.ToString()));
            }
            //Special Hazards
            for (int i = 1; i < Sh; i++)
            {
                elementNames.Add(string.Format("SH{0}", i.ToString()));
            }

            //Protection/Security
            for (int i = 1; i < Prot; i++)
            {
                elementNames.Add(string.Format("Prot{0}", i.ToString());
            }
            //Neighboring Exposures
            for(int i = 1; i < Ne; i++)
            {
                elementNames.Add(string.Format("NE{0}", i.ToString()));
            }
            //Perils
            for (int i = 1; i < Peril; i++)
            {
                elementNames.Add(string.Format("Peril{0}", i.ToString()));
            }
            //Cooking
            for (int i = 1; i < Cook; i++)
            {
                elementNames.Add(string.Format("Cook{0}", i.ToString()));
            }
            //Sprinkler
            for (int i = 1; i < Sprink; i++)
            {
                elementNames.Add(string.Format("Sprink{0}", i.ToString()));
            }
            //General Liability
            for (int i = 1; i < Gl; i++)
            {
                elementNames.Add(string.Format("GL{0}", i.ToString()));
            }



        }
        private void BuildRegularInspectionForm()
        {
            int nums = 20;
            int Survey = 8;
            int recs = 3;
            int opinion =3;
            int loss =2;
            int ops = 28;
            int bld = 45;
            int ch = 47;
            int sh = 13;
            int prot = 39;
            int ne = 27;
            int peril = 11;
            int cook = 52;
            int sprink = 31;
            int gl = 95;

            InitializeInspectionsElements(nums, Survey, recs, opinion, loss, ops, bld,ch, sh,prot,ne,peril,cook,sprink,gl);
        }

    }
}

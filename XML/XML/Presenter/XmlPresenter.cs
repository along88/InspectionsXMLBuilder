using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML.Models;
using XML.Views;

namespace XML.Presenter
{
    public class XmlPresenter
    {
        private readonly IView view;
        private readonly XmlModel xmlModel;

        public XmlPresenter(IView view)
        {
            this.view = view;
            xmlModel = new XmlModel();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        
    }
}

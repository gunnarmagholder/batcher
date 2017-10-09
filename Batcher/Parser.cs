using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Batcher
{

    public class Parser
    {
        private string XmlSequence = null;
        private XmlDocument _xml;
        public Parser(string xmlSequenceString)
        {
            if (gotValidSequenceString(xmlSequenceString))
            {
                XmlSequence = xmlSequenceString;
            }
            else
            {
                throw new Exception("Could not get valid XML");
            }
            
        }
        
        public bool gotValidSequenceString(string _xmlSequence)
        {
            if (_xmlSequence.Length > 0)
            {
                _xml = new XmlDocument();
                try
                {
                    _xml.LoadXml(_xmlSequence);
                }
                catch (XmlException e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetSequenceName()
        {
            XmlElement root = _xml.DocumentElement;
            return root.GetAttribute("name");
        }
    }
}

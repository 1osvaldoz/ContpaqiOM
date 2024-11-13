using ContpaqiOM.Tools;
using System.Xml.Serialization;

namespace ContpaqiOM.Models
{
    [XmlRoot("Comprobante")]
    public class Comprobante
    {
        [XmlElement("Emisor")]
        public Emisor Emisor { get; set; }

        [XmlElement("Receptor")]
        public Receptor Receptor { get; set; }

        [XmlArray("Conceptos")]
        [XmlArrayItem("Concepto")]
        public List<Concepto> Conceptos { get; set; }
        [XmlElement("Impuestos")]
        public Impuestos Impuestos { get; set; }
         public List<string> Errors { get; set; } = new List<string>();
        public void init(string xml)
        {
            List<string> lErrors=new List<string>();
            Comprobante comprobante = XmlHelper.DeserializeStringToXml<Comprobante>(xml,out lErrors);
            if (lErrors.Count > 0)
            {
                Errors = lErrors;
            }
            else
            {
                Emisor = comprobante.Emisor;
                Receptor = comprobante.Receptor;
                Conceptos = comprobante.Conceptos;
                Impuestos = comprobante.Impuestos;
            }
        }
    }
}

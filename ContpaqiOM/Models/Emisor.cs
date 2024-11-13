using System.Xml.Serialization;

namespace ContpaqiOM.Models
{
    public class Emisor
    {
        [XmlAttribute("Nombre")]
        public string Nombre { get; set; }
        [XmlAttribute("Rfc")]
        public string Rfc { get; set; }
    }
}

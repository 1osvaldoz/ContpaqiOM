using System.Xml.Serialization;

namespace ContpaqiOM.Models
{
    public class Impuestos
    {
        [XmlAttribute("TotalImpuestosRetenidos")]
        public decimal TotalImpuestosRetenidos { get; set; }
        [XmlAttribute("TotalImpuestosTrasladados")]
        public decimal TotalImpuestosTrasladados { get; set; }
    }
}

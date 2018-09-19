using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProverkiGov
{
    /// <summary>
    /// Элемент в реестре данных
    /// </summary>
    [XmlRoot(ElementName = "item")]
    public class ReestrItem
    {
        /// <summary>
        /// Id проверки
        /// </summary>
        [XmlAttribute(AttributeName = "identifier")]
        public int Identifier { get; set; }

        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
        /// <summary>
        /// Ссылка на документ содержащий информацию о проверки
        /// </summary>
        [XmlAttribute(AttributeName = "link")]
        public string Link { get; set; }

        /// <summary>
        /// Формат документа для скачивания
        /// </summary>
        [XmlAttribute(AttributeName = "format")]
        public string Format { get; set; }
    }

    [XmlRoot(ElementName = "standardversion")]
    public class Standardversion
    {
        [XmlElement(ElementName = "item")]
        public List<ReestrItem> Item { get; set; }
    }

    /// <summary>
    /// Объект для реестра данных
    /// </summary>
    [XmlRoot(ElementName = "list")]
    public class ProverkiList
    {
        [XmlElement(ElementName = "standardversion")]
        public Standardversion Standardversion { get; set; }
    }
}

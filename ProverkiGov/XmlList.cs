using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProverkiGov
{
    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlAttribute(AttributeName = "identifier")]
        public string Identifier { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
        [XmlAttribute(AttributeName = "link")]
        public string Link { get; set; }
        [XmlAttribute(AttributeName = "format")]
        public string Format { get; set; }
    }

    [XmlRoot(ElementName = "standardversion")]
    public class Standardversion
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "list")]
    public class ProverkiList
    {
        [XmlElement(ElementName = "standardversion")]
        public Standardversion Standardversion { get; set; }
    }
}

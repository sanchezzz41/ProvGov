using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProverkiGov.Models
{
    /// <summary>
    /// Проверка содержащая дату и ссылку на данные проверки
    /// </summary>
    [XmlRoot(ElementName = "structureversion")]
    public class Structureversion
    {
        [XmlElement(ElementName = "structureversion")]
        public string Structureversion1 { get; set; }
        [XmlElement(ElementName = "created")]
        public string Created { get; set; }
    }

    [XmlRoot(ElementName = "structure")]
    public class Structure
    {
        [XmlElement(ElementName = "structureversion")]
        public Structureversion Structureversion { get; set; }
    }

    [XmlRoot(ElementName = "publisher")]
    public class Publisher
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "mbox")]
        public string Mbox { get; set; }
    }

    [XmlRoot(ElementName = "dataversion")]
    public class Dataversion
    {
        [XmlElement(ElementName = "source")]
        public string Source { get; set; }
        [XmlElement(ElementName = "created")]
        public string Created { get; set; }
        [XmlElement(ElementName = "provenance")]
        public string Provenance { get; set; }
        [XmlElement(ElementName = "valid")]
        public string Valid { get; set; }
        [XmlElement(ElementName = "structure")]
        public string Structure { get; set; }
    }

    [XmlRoot(ElementName = "data")]
    public class Data
    {
        [XmlElement(ElementName = "dataversion")]
        public List<Dataversion> Dataversion { get; set; }
    }

    [XmlRoot(ElementName = "meta")]
    public class Meta
    {
        [XmlElement(ElementName = "standardversion")]
        public string Standardversion { get; set; }
        [XmlElement(ElementName = "identifier")]
        public string Identifier { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "creator")]
        public string Creator { get; set; }
        [XmlElement(ElementName = "created")]
        public string Created { get; set; }
        [XmlElement(ElementName = "modified")]
        public string Modified { get; set; }
        [XmlElement(ElementName = "subject")]
        public string Subject { get; set; }
        [XmlElement(ElementName = "format")]
        public string Format { get; set; }
        [XmlElement(ElementName = "structure")]
        public Structure Structure { get; set; }
        [XmlElement(ElementName = "publisher")]
        public Publisher Publisher { get; set; }
        [XmlElement(ElementName = "data")]
        public Data Data { get; set; }
    }
}

using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlParsing.Models
{
    [XmlRoot]
    public class ParsedProgrammer
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("Recommendations")]
        public ParsedRecommendations Recommendations { get; set; }
    }
    
    [XmlRoot]
    public class ParsedRecommendations
    {
        [XmlElement("Recommendation")]
        public List<string> Recommendations { get; set; }
    }
}

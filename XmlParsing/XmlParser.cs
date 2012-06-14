using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using DomainModels;
using XmlParsing.Models;

namespace XmlParsing
{
    public class XmlParser
    {
        private Network network;

        public XmlParser(string filename)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Network));
            network = serializer.Deserialize(new XmlTextReader(File.OpenRead(filename))) as Network;
        }

        public IEnumerable<Programmer> Parse()
        {
            var parsedProgrammers = network.Programmers;
            return parsedProgrammers.Select(CreateProgrammer);
        }

        private static Programmer CreateProgrammer(ParsedProgrammer parsedProgrammer)
        {
            var programmer = new Programmer(parsedProgrammer.Name);
            foreach (var parsedRecommendation in parsedProgrammer.Recommendations.Recommendations)
            {
                programmer.Recommendations.Add(new Programmer(parsedRecommendation));
            }
            return programmer;
        }
    }
}
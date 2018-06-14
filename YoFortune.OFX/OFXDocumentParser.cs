using OhMe.Mappers.XML;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace YoFortune.OFX
{
    public class OFXDocumentParser
    {
        public OFXDocument Load(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.Default))
            {
                return Parse(reader.ReadToEnd());
            }
        }

        public OFXDocument Load(string ofx) => Parse(Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(ofx))));

        private string ConvertSGMLTOXML(string sgml)
        {
            using (var reader = new StringReader(sgml))
            {
                string line;

                var stringBuilder = new StringBuilder();

                while ((line = reader.ReadLine()) != null)
                {
                    var tagEnd = line.IndexOf(">");

                    if (tagEnd != line.Length - 1)
                    {
                        var tagStart = line.IndexOf("<");

                        var tagName = line.Substring(tagStart + 1, (tagEnd - tagStart) - 1);

                        if (line.IndexOf(string.Format("</{0}>", tagName)) > -1)
                        {
                            stringBuilder.AppendLine(line);
                        }
                        else
                        {
                            stringBuilder.AppendLine(String.Concat(line, string.Format("</{0}>", tagName)));
                        }
                    }
                    else
                    {
                        stringBuilder.AppendLine(line);
                    }
                }

                return stringBuilder.ToString();
            }
        }

        private OFXDocument Parse(string data)
        {
            var ofxDocument = new OFXDocument();

            var xmlDocument = new XmlDocument();

            if (data.IndexOf("OFXHEADER") == -1)
            {
                throw new InvalidDataException();
            }

            var ofx = data.Remove(0, data.IndexOf("<"));

            var header = data;

            ofx = ConvertSGMLTOXML(ofx);

            xmlDocument.LoadXml(ofx);

            var mapper = new XmlMapper();

            mapper.SetValueResolver((propertyInfo, value) =>
            {
                if (propertyInfo.PropertyType == typeof(DateTime))
                {
                    if (value.Length < 8)
                    {
                        return "";
                    }

                    return string.Format("{0}-{1}-{2}", value.Substring(0, 4), value.Substring(4, 2), value.Substring(6, 2));
                }

                return value;
            });

            mapper.Map(xmlDocument, ofxDocument);

            return ofxDocument;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab12 {
    public static class Serializer {
        public static void WriteXML(string FileNameXML, Object obj) {
            StreamWriter serialWriter;
            serialWriter = new StreamWriter(FileNameXML);
            XmlSerializer xmlWriter = new XmlSerializer(obj.GetType());
            xmlWriter.Serialize(serialWriter, obj);
            serialWriter.Close();
        }
        public static DataSet ReadXML(string FileNameXML) {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataSet));
            FileStream readStream = new FileStream(FileNameXML, FileMode.Open);
            DataSet ds = (DataSet)xmlSerializer.Deserialize(readStream);
            readStream.Close();
            return ds;
        }

    }
}

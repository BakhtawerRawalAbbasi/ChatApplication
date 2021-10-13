using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CommunicationLayer
{
   public class Serialization
    {
        
        public static byte[] JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            byte[] jsonString = ms.ToArray();
            ms.Close();

            return jsonString;
        }
    }
}

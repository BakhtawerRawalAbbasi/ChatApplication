using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CommunicationLayer
{
    class Deserialization
    {

        //public static T JsonDeserialize<T>(byte[] jsonString)
        public static T JsonDeserialize<T>(byte[] jsonString)
        {

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream((jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
    }
}

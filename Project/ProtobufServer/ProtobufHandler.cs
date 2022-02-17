using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using Google.Protobuf;

namespace ProtobufServer
{
    public class ProtobufHandler
    {
        public Trip ConvertToProtobuf(string data)
        {
            return Trip.Parser.ParseFrom(Convert.FromBase64String(data));
        }
    }
}

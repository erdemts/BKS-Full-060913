using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BKSUSBDriver.Command
{
    internal class Response
    {
        public bool IsValid { get; set; }
        public byte ResponseType { get; set; }
        public byte[] Data { get; set; }
    }

    internal struct HidResponse
    {
        public ResponseCommands ResponseType { get; set; }
        public byte[] ResponseData { get; set; }
    }
}

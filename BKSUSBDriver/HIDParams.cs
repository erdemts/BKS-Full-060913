using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BKSUSBDriver
{
    public enum TAG_TYPE { UNKNOWN = 0,   USERS = 1, NODES = 2, EVENT = 3} //1: USERS / 2: NODES / 3: EVENT / 4: ALL

    internal static class HIDParams
    {
        public const int VID = 0x04D8;
        public const int PID = 0x003F;

        public static readonly byte STX = 0x0F;
        public static readonly byte ETX = 0x04;
        public static readonly byte DLE = 0x05;

        public static readonly int BufferSize = 65;

        public static readonly int CommandTimeOut = 10000;
    }
}

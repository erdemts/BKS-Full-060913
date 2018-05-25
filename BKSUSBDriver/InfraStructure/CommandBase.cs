
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BKSUSBDriver.Command
{
    internal abstract class CommandBase
    {
        public abstract byte OutputCommand { get; }
        public abstract byte[] InputCommands { get; }

        public int DataSize
        {
            get
            {
                if (this.OutputData == null)
                    return 0;
                else
                    return this.OutputData.Length;
            }
        }
        public abstract byte[] OutputData { get; }

        public byte[] GetCommandData()
        {
            byte[] buffer = new byte[2 + this.DataSize];
            buffer[0] = this.OutputCommand;
            buffer[1] = (byte)this.DataSize;

            if (this.OutputData != null)
            {
                Buffer.BlockCopy(this.OutputData,0,buffer, 2,  OutputData.Length);
            }

            return buffer;
        }
    }
}

using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using HIDCommunications;
using System.Collections.Generic;
using BKSUSBDriver.Command;
using System.Threading;
using System.Linq;
using System.Data;
using BKSUSBDriver;


namespace BKSUSBDriver
{
    public class HIDConnector 
    {
        public event EventHandler UsbChanged;
        private HIDCommControl device;

        private byte[] inputBuffer = new byte[HIDParams.BufferSize];
        private byte[] outputBuffer = new byte[HIDParams.BufferSize];

        public bool IsDeviceAttached
        {
            get
            {
                return device != null ? device.IsDeviceAttached : false;
            }
        }

        
        public HIDConnector()
        {
            device = new HIDCommControl(HIDParams.VID, HIDParams.PID, HIDParams.CommandTimeOut);
            device.usbEvent += device_usbEvent;
        }

        void device_usbEvent(object sender, EventArgs e)
        {
            if (UsbChanged != null)
                UsbChanged(sender, e);
        }


        public void Connect()
        {
            if (device!=null)
                device.findTargetDevice();
        }

        #region Command

        #region Sensor

        private bool Count_Sensor(ref int countLog)
        {
            var result = this.SendCommand(SendCommands.cmd_START_TRANSFER_SENSOR_LOG);

            switch (result.ResponseType)
            {
                case ResponseCommands.rsp_SENSOR_LOG_TRANSFER_READY:
                    countLog = BitConverter.ToInt16(new byte[] { result.ResponseData[1], result.ResponseData[0] }, 0);
                    return true;
                default: return false;
            }
        }

        public List<SensorLogItem> Read_Sensor_Log()
        {
            List<SensorLogItem> items = new List<SensorLogItem>();
            int countLog=0;
            bool isValidCount = this.Count_Sensor(ref countLog);

            if (!isValidCount)
                return items;

            while (true)
            {
                var result = this.SendCommand(SendCommands.cmd_GET_NEXT_SENSOR_LOG);

                if (result.ResponseType != ResponseCommands.rsp_NEXT_SENSOR_LOG)
                    break;

                if (result.ResponseData.Length < 9)
                    continue;

                int sensordata = BitConverter.ToInt16(new byte[] { result.ResponseData[0], 0x0 }, 0);

                byte[] datebuffer = new byte[6];
                Buffer.BlockCopy(result.ResponseData, 1, datebuffer, 0, 6);

                DateTime logdate = datebuffer.ByteToDateTime();

                if (logdate == DateTime.MinValue)
                    continue;

                items.Add(new SensorLogItem() { LogDate = logdate, SensorData = sensordata });

            }

            return items;
        }

        public bool Delete_All_Sensor_Log()
        {
            var result = this.SendCommand(SendCommands.cmd_DEL_ALL_SENSOR_LOGS);

            switch (result.ResponseType)
            {
                case ResponseCommands.rsp_ALL_SENSOR_LOGS_DELETED: return true;
                default: return false;
            }
        }

        #endregion

        #region Tag Log

        private bool Count_Tag(ref int countUser, ref int countNode, ref int countEvent, ref int countLog)
        {

            var result = this.SendCommand(SendCommands.cmd_START_TRANSFER_TAG_LOG);

            switch (result.ResponseType)
            {
                case ResponseCommands.rsp_TAG_LOG_TRANSFER_READY:

                    countUser = BitConverter.ToInt16(new byte[] {  result.ResponseData[1], result.ResponseData[0] }, 0);
                    countNode = BitConverter.ToInt16(new byte[] { result.ResponseData[3], result.ResponseData[2] }, 0);
                    countEvent = BitConverter.ToInt16(new byte[] { result.ResponseData[5], result.ResponseData[4] }, 0);
                    countLog = BitConverter.ToInt16(new byte[] { result.ResponseData[7], result.ResponseData[6] }, 0);
                    return true;
                default: return false;
            }

            //* BYTE 4 : Total users count High Byte
            //* BYTE 4 : Total users count Low Byte

            //* BYTE 5 : Total nodes count High Byte
            //* BYTE 5 : Total nodes count Low Byte

            //* BYTE 6 : Total event count High Byte
            //* BYTE 6 : Total event count Low Byte

            //* BYTE 7 : Total log count High Byte
            //* BYTE 8 : Total log count Low Byte
        }

        public List<TagLogItem> Read_Tag_Log()
        {
            List<TagLogItem> items = new List<TagLogItem>();

            int countUser = 0;
            int countNode = 0;
            int countEvent = 0;
            int countLog = 0;

            bool isValidCount = this.Count_Tag(ref countUser, ref countNode, ref countEvent, ref countLog);

            if (!isValidCount)
                return items;

            while (true)
            {
                var result = this.SendCommand(SendCommands.cmd_GET_NEXT_TAG_LOG);

                if (result.ResponseType != ResponseCommands.rsp_NEXT_TAG_LOG)
                    break;
                
                if (result.ResponseData.Length < 9)
                    continue;

                int tagnumber = BitConverter.ToInt32(new byte[] { result.ResponseData[2], result.ResponseData[1], result.ResponseData[0], 0x0 }, 0);

                byte[] datebuffer = new byte[6];
                Buffer.BlockCopy(result.ResponseData, 3, datebuffer, 0, 6);
                
                DateTime logdate = datebuffer.ByteToDateTime();

                if (logdate == DateTime.MinValue)
                    continue;

                items.Add(new TagLogItem() { LogDate = logdate, TagNumber = tagnumber });

            }
        
            return items;
        }

        public bool Delete_All_Tag_Log()
        {
            var result = this.SendCommand(SendCommands.cmd_DEL_ALL_TAG_LOGS);

            switch (result.ResponseType)
            {
                case ResponseCommands.rsp_ALL_TAG_LOGS_DELETED: return true;
                default: return false;
            }
        }

        #endregion

        #region Serial Number

        public string GetSerialNumber()
        {
            return this.GetDeviceHardwareSerial();
        }

        private string GetDeviceHardwareSerial()
        {
            string serial;
            bool success = device.GetDeviceSerial(out serial);

            return (success) ? serial  : default(string);
        }

        #endregion

        #region Tag

        public int GetTagCapacity(TAG_TYPE tagtype)
        {

            var result = this.SendCommand(SendCommands.cmd_GET_TAG_CAPACITY, new byte[] { (byte)tagtype }, true);

            switch (result.ResponseType)
            {
                case ResponseCommands.rsp_GET_TAG_CAPACITY:

                    byte[] databuffer = result.ResponseData;
                    Array.Resize(ref databuffer, 4);
                    Array.Reverse(databuffer);
                    

                    int tagnumber = BitConverter.ToInt32(databuffer, 0);

                    return tagnumber;

                default: return -1;
            }
          
        }

        public Int32 ReadTagNumber(out bool isTimeOut)
        {
            isTimeOut = false;

            var result = this.SendCommand(SendCommands.cmd_READ_TAG, null, true);

            switch (result.ResponseType)
            {
                case ResponseCommands.rsp_TAG_NUMBER:

                    byte[] databuffer = result.ResponseData;
                    Array.Reverse(databuffer);
                    Array.Resize(ref databuffer, 4);

                    int tagnumber = BitConverter.ToInt32(databuffer, 0);

                    return tagnumber;

                case ResponseCommands.rsp_TIMEOUT_OCCURED:
                    isTimeOut = true;
                    return -1;
                default: return -1;
            }
        }

        public bool AddTag(TAG_TYPE tagtype, Int32 tagnumber)
        {
            byte[] tagdata = BitConverter.GetBytes(tagnumber);
            Array.Reverse(tagdata);
            Buffer.SetByte(tagdata, 0, (byte)tagtype);

            var result = this.SendCommand(SendCommands.cmd_ADD_TAG, tagdata);

            switch (result.ResponseType)
            {
                
                case ResponseCommands.rsp_TAG_ADDED : return true;
                case ResponseCommands.rsp_TAG_ALREADY_ADDED :
                case ResponseCommands.rsp_USER_MEMORY_FULL :
                case ResponseCommands.rsp_NODE_MEMORY_FULL :
                case ResponseCommands.rsp_WRONG_PARAMETER :
                default: return false;
            }
        }

        public bool DeleteAllTag(TAG_TYPE tagtype)
        {
            var result = this.SendCommand(SendCommands.cmd_DEL_ALL_TAGS, new byte[] { (byte)tagtype });

            switch (result.ResponseType)
            {
                case ResponseCommands.rsp_ALL_USERS_DELETED :
                case ResponseCommands.rsp_ALL_NODES_DELETED :
                case ResponseCommands.rsp_ALL_EVENTS_DELETED :
                case ResponseCommands.rsp_ALL_TAGS_DELETED : return true;
                
                case ResponseCommands.rsp_WRONG_PARAMETER:
                default: return false;
            }
        }

        public bool DeleteTag(TAG_TYPE tagtype, Int32 tagnumber)
        {
            byte[] tagdata = BitConverter.GetBytes(tagnumber);
            Array.Reverse(tagdata);
            Buffer.SetByte(tagdata, 0, (byte)tagtype);

            var result = this.SendCommand(SendCommands.cmd_DEL_ONE_TAG, tagdata);


            switch(result.ResponseType)
            {
                case ResponseCommands.rsp_TAG_DELETED : return true;
                case ResponseCommands.rsp_UNKNOWN_TAG : 
                case ResponseCommands.rsp_WRONG_PARAMETER : 
                default : return false;
            }
        }

        public bool CheckTag(Int32 tagnumber, ref TAG_TYPE tagtype)
        {

            byte[] tagdata = BitConverter.GetBytes(tagnumber);

            Array.Resize(ref tagdata, 3);
            Array.Reverse(tagdata);
            
            var result = this.SendCommand(SendCommands.cmd_CHECK_TAG, tagdata );


            switch (result.ResponseType)
            {
                case ResponseCommands.rsp_TAG_ALREADY_ADDED:
                    tagtype = (TAG_TYPE)result.ResponseData[0];
                    return true;
                case ResponseCommands.rsp_UNKNOWN_TAG: 
                default:
                    tagtype = TAG_TYPE.UNKNOWN;
                    return false;
            }
        }

        #endregion

        #region Alarm

        public bool CleanAlarms(DayOfWeek day)
        {
            byte[] data = new byte[]
                {
                    (byte)(((int)day) + 1)
                };

            var result = this.SendCommand(SendCommands.cmd_DEL_ALL_ALARMS_FOR_A_DAY, data);

            switch (result.ResponseType)
            {
                case ResponseCommands.rsp_ALARMS_DELETED: return true;
                case ResponseCommands.rsp_ALARM_MEMORY_FULL:
                default: return false;
            }
        }

        public bool AddAlarms(DayOfWeek day, int hour, int minute, int duration)
        {
            byte[] data = new byte[]
                {
                    (byte) (((int)day) + 1),
                    (byte)hour,
                    (byte)minute,
                    (byte)duration,
                };

            var result = this.SendCommand(SendCommands.cmd_ADD_ALARM_FOR_A_DAY, data);

            switch (result.ResponseType)
            {
                case ResponseCommands.rsp_ALARM_ADDED: return true;
                case ResponseCommands.rsp_ALARM_MEMORY_FULL:
                default: return false;
            }
        }

        #endregion


        #region Date Time

        public bool SetDateTime(DateTime date)
        {
            byte[] _data = new byte[]
                                { 
                                    (byte)date.Second, 
                                    (byte)date.Minute,
                                    (byte)date.Hour,
                                    (byte)(date.DayOfWeek+1),
                                    (byte)date.Day,
                                    (byte)date.Month,
                                    (byte)int.Parse(string.Format("{0:yy}", date)),
                                };

            HidResponse result = this.SendCommand(SendCommands.cmd_SET_TIME_DATE, _data);

            return (result.ResponseType == ResponseCommands.rsp_TIME_DATE_SYNCED);
                
        }

        public DateTime GetDateTime()
        {
            HidResponse result = this.SendCommand(SendCommands.cmd_GET_TIME_DATE);

            if (result.ResponseType == ResponseCommands.rsp_TIME_DATE)
            {
                return result.ResponseData.ByteToDateTime();
            }
            else
                return DateTime.MinValue;
        }

        #endregion

        public void Beep()
        {
            this.SendCommand(SendCommands.cmd_BEEP, null, false);
        }

        #endregion

        #region Base Process

        private HidResponse SendCommand(SendCommands sendCommand, byte[] senddata = null, bool CheckResponse = true)
        {
            // HOST COMMANDS
            // 0, STX, COMMMAND, DATA SIZE, DATA1,...., DATAn, CRCH, CRCL, ETX


            HidResponse response = new HidResponse();
            
            ClearBuffer();

            int datasize = ((senddata==null) ? 0 : senddata.Length);

            outputBuffer[0] = 0;
            outputBuffer[1] = HIDParams.STX;
            outputBuffer[2] = (byte)sendCommand;
            outputBuffer[3] = (byte)datasize;

            if (senddata!=null)
                Buffer.BlockCopy(senddata, 0, outputBuffer, 4, senddata.Length);

            byte[] crc = GetCrc(outputBuffer, 2, ( 2+ datasize));

            outputBuffer[datasize + 4] = crc[0];
            outputBuffer[datasize + 5] = crc[1];
            outputBuffer[datasize + 6] = HIDParams.ETX;
            
            
            var success = device.writeRawReportToDevice(outputBuffer);

            if (success && CheckResponse)
            {
                success = device.readSingleReportFromDevice(ref inputBuffer);
                if (success)
                {

                    response.ResponseType = (ResponseCommands)inputBuffer[2];
                    response.ResponseData = new byte[inputBuffer[3]];

                    for (int i = 0; i < inputBuffer[3]; i++)
                    {
                        response.ResponseData[i] = inputBuffer[4 + i];
                    }

                    return response;
                }
            }

            return response;
        }



        private void ClearBuffer()
        {
            Array.Clear(this.outputBuffer, 0, this.outputBuffer.Length);
            Array.Clear(this.inputBuffer, 0, this.inputBuffer.Length);
        }

        private byte[] GetCrc(byte[] values , int startIndex = 0, int count = 0)
        {
            ushort rv = 0;
            byte[] returnval = new byte[2];

            count += startIndex;

            for (int i = startIndex; i < count; i++)
			{
                byte crc = values[i];

                rv = (ushort)((rv >> 8) | (rv << 8));
                rv ^= (ushort)(crc);
                rv ^= (ushort)((rv & 0xFF) >> 4);
                rv ^= (ushort)((rv << 8) << 4);
                rv ^= (ushort)(((rv & 0xff) << 4) << 1);
            }

            returnval[0] = (byte)((rv >> 8) & 0xFF);
            returnval[1] = (byte)(rv & 0xFF);
            return returnval;
        }


        #endregion
    }
}
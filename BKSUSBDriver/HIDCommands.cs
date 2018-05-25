using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BKSUSBDriver
{
    public enum SendCommands
    {
        cmd_UNKNOWN = (byte)0,
        cmd_GET_SERIAL =  (byte) 101,
        cmd_ADD_TAG =  (byte) 102,
        cmd_DEL_ONE_TAG =  (byte) 103,
        cmd_CHECK_TAG =  (byte) 104,
        cmd_SET_TIME_DATE =  (byte) 105,
        cmd_GET_TIME_DATE =  (byte) 106,
        cmd_START_TRANSFER_TAG_LOG =  (byte) 107,
        cmd_GET_NEXT_TAG_LOG =  (byte) 108,
        cmd_DEL_ALL_TAG_LOGS =  (byte) 109,
        cmd_DEL_ALL_TAGS =  (byte) 110,
        cmd_READ_TAG =  (byte) 111,
        cmd_BEEP =  (byte) 112,
        cmd_START_TRANSFER_SENSOR_LOG =  (byte) 113,
        cmd_GET_NEXT_SENSOR_LOG =  (byte) 114,
        cmd_DEL_ALL_SENSOR_LOGS =  (byte) 115,
        cmd_GET_TAG_CAPACITY =  (byte) 116,
        cmd_ADD_ALARM_FOR_A_DAY = (byte)117,
        cmd_DEL_ALL_ALARMS_FOR_A_DAY = (byte)118,
    }


    public enum ResponseCommands
    {
        rsp_UNKNOWN = (byte)0,
        rsp_GET_SERIAL = (byte) 201,
        rsp_TAG_ADDED = (byte) 202,
        rsp_TAG_ALREADY_ADDED = (byte) 203,
        rsp_TAG_DELETED = (byte) 204,
        rsp_UNKNOWN_TAG = (byte) 205,
        rsp_TIME_DATE_SYNCED = (byte) 206,
        rsp_TIME_DATE = (byte) 207,
        rsp_TAG_LOG_TRANSFER_READY = (byte) 208,
        rsp_NEXT_TAG_LOG = (byte) 209,
        rsp_ALL_TAG_LOGS_DELETED = (byte) 210,
        rsp_ALL_USERS_DELETED = (byte) 211,
        rsp_ALL_NODES_DELETED = (byte) 212,
        rsp_ALL_TAGS_DELETED = (byte) 213,
        rsp_TAG_NUMBER = (byte) 214,
        rsp_TAG_LOG_TRANSFER_COMPLATE = (byte) 215,
        rsp_USER_MEMORY_FULL = (byte) 216,
        rsp_NODE_MEMORY_FULL = (byte) 217,
        rsp_EVENT_MEMORY_FULL = (byte) 218,
        rsp_ALL_EVENTS_DELETED = (byte) 219,
        rsp_SENSOR_LOG_TRANSFER_READY = (byte) 220,
        rsp_NEXT_SENSOR_LOG = (byte) 221,
        rsp_SENSOR_LOG_TRANSFER_COMPLATE = (byte) 222,
        rsp_ALL_SENSOR_LOGS_DELETED = (byte) 223,
        rsp_WRONG_PARAMETER = (byte) 224,

        rsp_GET_TAG_CAPACITY = (byte) 225,
        rsp_TIMEOUT_OCCURED = (byte) 226,

        rsp_ALARM_ADDED = (byte) 227,
        rsp_ALARMS_DELETED = (byte) 228,
        rsp_ALARM_MEMORY_FULL = (byte) 229,
        
    }


    internal class HIDCommands
    {
        public static byte cmd_GET_SERIAL = 101;
        public static byte cmd_ADD_TAG = 102;
        public static byte cmd_DEL_ONE_TAG = 103;
        public static byte cmd_CHECK_TAG = 104;
        public static byte cmd_SET_TIME_DATE = 105;
        public static byte cmd_GET_TIME_DATE = 106;
        public static byte cmd_START_TRANSFER_TAG_LOG = 107;
        public static byte cmd_GET_NEXT_TAG_LOG = 108;
        public static byte cmd_DEL_ALL_TAG_LOGS = 109;
        public static byte cmd_DEL_ALL_TAGS = 110;
        public static byte cmd_READ_TAG = 111;
        public static byte cmd_BEEP = 112;
        public static byte cmd_START_TRANSFER_SENSOR_LOG = 113;
        public static byte cmd_GET_NEXT_SENSOR_LOG = 114;
        public static byte cmd_DEL_ALL_SENSOR_LOGS = 115;
        public static byte cmd_GET_TAG_CAPACITY = 116;

        public static byte rsp_GET_SERIAL = 201;
        public static byte rsp_TAG_ADDED = 202;
        public static byte rsp_TAG_ALREADY_ADDED = 203;
        public static byte rsp_TAG_DELETED = 204;
        public static byte rsp_UNKNOWN_TAG = 205;
        public static byte rsp_TIME_DATE_SYNCED = 206;
        public static byte rsp_TIME_DATE = 207;
        public static byte rsp_TAG_LOG_TRANSFER_READY = 208;
        public static byte rsp_NEXT_TAG_LOG = 209;
        public static byte rsp_ALL_TAG_LOGS_DELETED = 210;
        public static byte rsp_ALL_USERS_DELETED = 211;
        public static byte rsp_ALL_NODES_DELETED = 212;
        public static byte rsp_ALL_TAGS_DELETED = 213;
        public static byte rsp_TAG_NUMBER = 214;
        public static byte rsp_TAG_LOG_TRANSFER_COMPLATE = 215;
        public static byte rsp_USER_MEMORY_FULL = 216;
        public static byte rsp_NODE_MEMORY_FULL = 217;
        public static byte rsp_EVENT_MEMORY_FULL = 218;
        public static byte rsp_ALL_EVENTS_DELETED = 219;
        public static byte rsp_SENSOR_LOG_TRANSFER_READY = 220;
        public static byte rsp_NEXT_SENSOR_LOG = 221;
        public static byte rsp_SENSOR_LOG_TRANSFER_COMPLATE = 222;
        public static byte rsp_ALL_SENSOR_LOGS_DELETED = 223;
        public static byte rsp_WRONG_PARAMETER = 224;

        public static byte rsp_GET_TAG_CAPACITY = 225;
        public static byte rsp_TIMEOUT_OCCURED = 226; 

        #region Old Commad

        //public static byte cmd_GET_SERIAL              = 101 ;//Yapıldı
        //public static byte cmd_ADD_TAG                 = 102 ;//Yapıldı
        //public static byte cmd_DEL_TAG                 = 103 ;//Yapıldı
        //public static byte cmd_CHECK_TAG               = 104 ;//Yapıldı
        //public static byte cmd_SET_TIME_DATE           = 105 ;//Yapıldı
        //public static byte cmd_GET_TIME_DATE           = 106 ;//Yapıldı
        //public static byte cmd_START_TRANSFER          = 107 ;//Yapıldı
        //public static byte cmd_GET_NEXT_LOG            = 108 ;//Yapıldı
        //public static byte cmd_DEL_ALL_LOGS            = 109 ;//Yapıldı
        //public static byte cmd_DEL_ALL_TAGS            = 110 ;//Yapıldı
        //public static byte cmd_READ_TAG                = 111 ;//Yapıldı
        //public static byte cmd_BEEP                    = 112 ;//Yapıldı

        //public static byte cmd_SHOW_EEPROM             = 113 ;
        //public static byte cmd_SHOW_EEPROM_2           = 114 ;

        //public static byte rsp_GET_SERIAL              = 201 ;//Yapıldı
        //public static byte rsp_TAG_ADDED               = 202 ;//Yapıldı
        //public static byte rsp_TAG_ALREADY_ADDED       = 203 ;//Yapıldı
        //public static byte rsp_TAG_DELETED             = 204 ;//Yapıldı
        //public static byte rsp_UNKNOWN_TAG             = 205 ;//Yapıldı
        //public static byte rsp_TIME_DATE_SYNCED        = 206 ;//Yapıldı
        //public static byte rsp_TIME_DATE               = 207 ;//Yapıldı
        //public static byte rsp_TRANSFER_READY          = 208 ;//Yapıldı
        //public static byte rsp_NEXT_LOG                = 209 ;//Yapıldı
        //public static byte rsp_ALL_LOGS_DELETED        = 210 ;//Yapıldı
        //public static byte rsp_ALL_USERS_DELETED       = 211 ;//Yapıldı
        //public static byte rsp_ALL_NODES_DELETED       = 212 ;//Yapıldı
        //public static byte rsp_ALL_TAGS_DELETED        = 213 ;//Yapıldı
        //public static byte rsp_TAG_NUMBER              = 214 ;//Yapıldı
        //public static byte rsp_TRANSFER_COMPLATE       = 215 ;//Yapıldı
        //public static byte rsp_USER_MEMORY_FULL        = 216 ;//Yapıldı
        //public static byte rsp_NODE_MEMORY_FULL        = 217 ;//Yapıldı

        //public static byte rsp_EEPROM                  = 218;

        #endregion
    }
}

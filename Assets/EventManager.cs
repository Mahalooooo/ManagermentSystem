
using System;
using System.Collections.Generic;


   namespace Tool
{
    public class EventManager
    {


        static Dictionary<string, Action<object>> mRegisteredStrMsgs = new Dictionary<string, Action<object>>();


        //==========================================================================

        public static void AddListener(string msgName, Action<object> onMsgReceived)
        {
            if (string.IsNullOrEmpty(msgName))
            {
               //("注册消息请传递消息名 当前消息名称为 空");
                return;
            }
            if (!mRegisteredStrMsgs.ContainsKey(msgName))
            {
                mRegisteredStrMsgs.Add(msgName, _ => { });
            }
            mRegisteredStrMsgs[msgName] += onMsgReceived;
        }


        public static void RemoveListenerAll(string msgName)
        {
            if (mRegisteredStrMsgs.ContainsKey(msgName))
                mRegisteredStrMsgs.Remove(msgName);
        }

        public static void RemoveListener(string msgName, Action<object> onMsgReceived)
        {
            if (string.IsNullOrEmpty(msgName)) return;
            if (mRegisteredStrMsgs.ContainsKey(msgName))
            {
                mRegisteredStrMsgs[msgName] -= onMsgReceived;
            }
        }

        public static void Send(string msgName, object data = null)
        {
            if (mRegisteredStrMsgs.ContainsKey(msgName))
            {
                mRegisteredStrMsgs[msgName](data);
            }
        }

    }
}
 

using System;
using Easy.MessageHub;

namespace yphkd.Events
{
    class Publisher
    {
        private static Publisher instance = new Publisher();
        private Publisher()
        {
        }

        /*
        private static IMessagePublisher pub;
        public static IMessagePublisher Default()
        {
            if (instance == null)
            {
                instance = new Publisher();
                pub = new MessagePublisher();
            }

            return pub;
        }
        */

        public static MessageHub Default()
        {
            return new MessageHub();
        }
    }

    public class ReplicationStatusEvent
    {
        public static int STOPPED = 8;
        public static int BUSY = 5;
        public static int IDLE = 6;
        public static int CONNECTING = 1;
        public static int OFFLINE = 2;
        public static int ERROR = 9;
        public static int UNKNOWN = 0;

        public int status;
        public ulong busyProgress;
        public ulong busyTotal;
        public ulong dbItemCount;
        public string errorMessage;

        public override string ToString()
        {
            if (status == UNKNOWN)
            {
                return "Unknown";
            }
            else if (status == CONNECTING)
            {
                return "Connecting";
            }
            else if (status == OFFLINE)
            {
                return "Offline dbItems=" + dbItemCount;
            }
            else if (status == BUSY)
            {
                return "Busy dbItems=" + dbItemCount + " [" + busyProgress + " / " + busyTotal + "]";
            }
            else if (status == IDLE)
            {
                return "Idle dbItems=" + dbItemCount;
            }
            else if (status == STOPPED)
            {
                return "Stopped dbItems=" + dbItemCount;
            }
            else if (status == ERROR)
            {
                return "Error: " + errorMessage;
            }

            return "";
        }

        public ReplicationStatusEvent(int status, ulong dbItemCount, ulong busyProgress, ulong busyTotal)
        {
            this.status = status;
            this.busyProgress = busyProgress;
            this.busyTotal = busyTotal;
            this.dbItemCount = dbItemCount;

            this.errorMessage = "";
        }

        public ReplicationStatusEvent(int status, ulong dbItemCount)
        {
            this.status = status;
            this.dbItemCount = dbItemCount;

            this.busyProgress = 0;
            this.busyTotal = 0;
            this.errorMessage = "";
        }

        public ReplicationStatusEvent(int status, string errorMessage)
        {
            this.status = status;
            this.errorMessage = errorMessage;

            this.busyProgress = 0;
            this.busyTotal = 0;
            this.dbItemCount = 0;
        }

        public ReplicationStatusEvent(int status)
        {
            this.status = status;

            this.busyProgress = 0;
            this.busyTotal = 0;
            this.dbItemCount = 0;
            this.errorMessage = "";
        }
    }

    
}

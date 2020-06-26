namespace Assignment
{
    class DataMessage
    {

    }

    class DataMessageSerializer
    {
        public static DataMessage ToMessage(byte[] networkData)
        {
            return new DataMessage();
        }

        public static byte[] ToNetworkData(DataMessage message)
        {
            return new byte[0];
        }
    }
}
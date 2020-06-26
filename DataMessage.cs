namespace Assignment
{
    class DataMessage
    {
        public string MessageBody { get; set; } = "";
    }

    class DataMessageSerializer
    {
        public static DataMessage ToMessage(byte[] networkData)
        {
            DataMessage message = new DataMessage();
            message.MessageBody = System.Text.Encoding.ASCII.GetString(networkData);
            return message;
        }

        public static byte[] ToNetworkData(DataMessage message)
        {
            return System.Text.Encoding.ASCII.GetBytes(message.MessageBody);
        }
    }
}
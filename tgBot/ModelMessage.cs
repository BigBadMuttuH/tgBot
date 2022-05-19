public struct ModellMessage
{
    public string? chat_id;
    public int message_id;
    //public string? message_id;
    public string? update_id;
    public string? text;

    public override string ToString()
    {
        return $"{chat_id}\t" +
               $"{message_id}\t" +
               $"{update_id}\t" +
               $"{text}";

        //return $"chat_id:{chat_id}\t" +
        //       $"msg_id:{message_id}\t" +
        //       $"update_id:{update_id}\t" +
        //       $"text:{text}";
    }
}
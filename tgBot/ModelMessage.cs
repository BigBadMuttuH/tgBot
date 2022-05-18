using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct ModellMessage
{
    public string? chat_id;
    public string? message_id;
    public string? update_id;
    public string? text;

    public static string ToString(ModellMessage model)
    {
        return $"chat_id:{model.chat_id}\t" +
               $"msg_id:{model.message_id}\t" +
               $"update_id:{model.update_id}\t" +
               $"text:{model.text}";
    }
}
using SunRose.Models;

namespace SunRose.Services.Interfaces
{
    public interface IMessageService
    {
        bool SaveMessage(string msg,Guid userId);
         IList<Message>  GetUserMessages(Guid userId);
         IList<Message>  GetAllMessages();
    }
}

﻿using SunRose.Models;
using SunRose.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;
 

namespace SunRose.Services.Implementation
{
    public class MessageService : IMessageService
    {
        private static IList<Message> _messages = new List<Message>();


        public  IList<Message>  GetAllMessages()
        {
            return _messages.Skip(_messages.Count - 20).ToList();

        }

        public  IList<Message>  GetUserMessages(Guid userId)
        {
            var userMessage = _messages.Where(x => x.UserId == userId).ToList();//.Skip(_messages.Count - 10).ToList();
            var result = userMessage.Skip(userMessage.Count-10).ToList();


            return result;
        }

        public bool SaveMessage(string msg,Guid userId)
        {
                    
            try
            {   
                _messages.Add(new Message { Id = new Guid(),Text = msg,Timestamp = DateTime.Now,UserId = userId });
            }
            catch(Exception e)
            {
                return false;
            }
          
            return true;
        }



    }
}

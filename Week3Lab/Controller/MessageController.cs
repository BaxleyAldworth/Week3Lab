using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;
using Week3Lab.Models;

namespace Week3Lab.Controller
{
    public class MessagesController : ApiController
    {
        //Retrieve out of the cache the current posts
        private List<MessageModel> GetMessages()
        {
            MemoryCache memoryCache = MemoryCache.Default;
            var messages = (List<MessageModel>)memoryCache.Get("messages");

            if (messages == null)
            {
                messages = new List<MessageModel>();
                memoryCache.Set("messages", messages, DateTimeOffset.Now.AddSeconds(100));
            }

            return messages;
        }

        

        //put the list of posts back in the cache
        private void SavePosts(List<MessageModel> messages)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Set("messages", messages, DateTimeOffset.Now.AddSeconds(100)); 
        }

        //action
        public IHttpActionResult GetAllMessages()
        {
            var messages = list
                get messages
        }

        //have to add RESTSHARP to your console app

        //messages - not going to use class level variable i've created
        //get post / save post

        //work on api first
        //then work on console app to call it

        /*
        public MessageModel CreateMessage(MessageModel m)
        {
            var newMessage = new MessageModel()
            {
                Author = m.Author,
                Body = m.Author,
                PostedDate = DateTime.Now
            };
            return newMessage;
        }
        */






    }
}

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
        private List<Message> GetMessages()
        {
            MemoryCache memoryCache = MemoryCache.Default;
            var messages = (List<Message>)memoryCache.Get("messages");

            if (messages == null)
            {
                messages = new List<Message>();
                memoryCache.Set("messages", messages, DateTimeOffset.Now.AddSeconds(100));
            }

            return messages;
        }

        //put the list of posts back in the cache
        private void SaveMessages(List<Message> messages)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Set("messages", messages, DateTimeOffset.Now.AddSeconds(100)); 
        }

        //action
        [HttpGet]
        public IHttpActionResult GetAllMessages()
        {
            //var messagesAll = GetMessages();
            return Ok(GetMessages());
        }

        public IHttpActionResult CreateMessage(Message m)
        {
            //get all messages
            //add message
            //save messages
            var currentAllMessages = GetMessages();
            if (currentAllMessages.Any())
                m.ID = currentAllMessages.Max(x => m.ID) + 1;
            else
                m.ID = 1;

            currentAllMessages.Add(m);

            SaveMessages(currentAllMessages);

            return Ok(m);
            //delete going to be similar
            
            
            
            
            
            
            /*
            var newMessage = new Message()
            {
                Author = m.Author,
                Body = m.Author,
                PostedDate = DateTime.Now,
                ID = messagesAll.Max(x => m.ID) + 1
            };
            messagesAll.Add(newMessage);
            SaveMessages(messagesAll);
            */
        } 
    }
}

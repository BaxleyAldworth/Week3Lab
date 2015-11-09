
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3LabConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient(/*localhost?*/);

            var getMessages = new RestRequest(/*api/:id*/);

            IRestResponse<MessageResponse> response = client.Execute<MessageResponse>(getMessages);

            
            var showMessages = new RestRequest("api/messages", Method.GET);
            var postMessage = new RestRequest("api/messages/{id}", Method.POST);

            MessageResponse allMessages = client.Execute<MessageResponse>(showMessages).Data;
            MessageResponse saveMessage = client.Execute<MessageResponse>(postMessage).Data;

            Console.WriteLine("Welcome to Bootleg Slack. (S)how messages or (w)rite message?");


            //get user input and then act
            string userInput = Console.ReadLine();

            if (userInput == "s" || userInput == "S")
            {
                foreach (var x in allMessages.messages)
                {
                    Console.WriteLine(x.Author);
                    Console.WriteLine(x.Body);
                    Console.WriteLine(x.PostedDate);
                    Console.ReadLine();
                }
            }

            if (userInput == "w" || userInput == "W" )
            {
                Console.WriteLine("Please enter a message:");
                string B = Console.ReadLine();

            }

            else
            {   Console.WriteLine("Invalid input. Goodbye!");
                Console.ReadLine();
            }
        }
    }
}

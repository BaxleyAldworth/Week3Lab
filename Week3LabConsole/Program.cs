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
            var client = new RestClient("http://localhost:52349/");

            Message msg = new Message();

            Console.WriteLine("Welcome to Bootleg Slack.");
            Console.WriteLine("What's your name?");
            var userName = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("(S)how messages, (w)rite message, (e)xit program?");
                string userInput = Console.ReadLine();

                if (userInput == "s" || userInput == "S")
                {
                    var request = new RestRequest("api/messages", Method.GET);
                    var messages = client.Execute<List<Message>>(request).Data;

                    Console.Clear();
                    messages.ForEach(x => Console.WriteLine(x));
                    Console.ReadLine();
                }

                if (userInput == "w" || userInput == "W")
                {
                    var request = new RestRequest("api/messages", Method.POST)
                    { RequestFormat = DataFormat.Json };
                    Console.WriteLine("Please enter your message:");
                    msg.Body = Console.ReadLine();
                    msg.Author = userName;
                    msg.PostedDate = DateTime.Now;
                    request.AddJsonBody(msg);
                    var response = client.Execute<Message>(request);
                    Console.WriteLine("Message successfully posted.");
                }

                if (userInput == "e" || userInput == "E")
                {
                    Console.WriteLine("Goodbye.");
                    Console.ReadLine();
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
    }
}


///use the variable names
//creat a post request with the json of the message
// var request = new RestRequest("api/messages", Method.POST)
//{ RequestFormat = DataFormat.Json };

//execute the post request
//var response = client.Execute<Message>(request);

//Get all the messages back
//request = new RestRequest("api/messages", Method.GET);
//var messages = client.Execute<List<Message>>(request).Data;
///Console.WriteLine(messages);

//clear the console and print each message we get back
//Console.Clear();
//messages.ForEach(x => Console.WriteLine(x));
//Console.WriteLine(response.Data);

/*
            Console.WriteLine("Welcome to Bootleg Slack.");
            Console.WriteLine("What's your name?");
            var userName = Console.ReadLine();

            //get user input and then act
            while (true)
            {
                Console.WriteLine("(S)how messages, (w)rite message, (e)xit program?");
                string userInput = Console.ReadLine();

                if (userInput == "s" || userInput == "S")
                {
                    foreach (var x in //allMessages.messages)
                    {
                        Console.WriteLine(x.Author);
                        Console.WriteLine(x.Body);
                        Console.WriteLine(x.PostedDate);
                        Console.ReadLine();
                    }
                }

                if (userInput == "w" || userInput == "W")
                {
                    var newMessage = new Message();

                    newMessage.Author = userName;

                    Console.WriteLine("Please enter your message:");
                    newMessage.Body = Console.ReadLine();

                    //saveMessage
                }

                if (userInput == "e" || userInput == "E")
                {
                    Console.WriteLine("Goodbye.");
                    Console.ReadLine();
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            */

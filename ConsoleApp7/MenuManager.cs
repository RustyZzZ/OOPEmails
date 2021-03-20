using System;
using System.Collections.Generic;

namespace ConsoleApp7
{
    public class MenuManager
    {
        public User user;

        public MenuManager(string username)
        {
            user = History.getUserByUsername(username);
        }

        public enum Menu : int
        {
            NewMessage = 1,
            Incoming = 2,
            Outcoming = 3,
            Draft = 4,
            Quit = 0
        }

        public void printMenu()
        {
            Console.WriteLine("1) New message");
            Console.WriteLine("2) Inbox");
            Console.WriteLine("3) Outbox");
            Console.WriteLine("4) Draft");
            Console.WriteLine("0) Quit");
        }

        public int doAction(string action)
        {
            var ac = int.Parse(action);
            switch ((Menu) ac)
            {
                case Menu.NewMessage:
                {
                    newMessage(user);
                    break;
                }
                case Menu.Incoming:
                {
                    printMailList(user.inbox);
                    break;
                }
                case Menu.Outcoming: 
                {
                    printMailList(user.outbox);
                    break;
                }
                case Menu.Draft: {
                    printMailList(user.drafts);
                    break;
                }
                case Menu.Quit:
                {
                   break; 
                }
                
            }

            return ac;
        }

        private void newMessage(User from)
        {
            Console.WriteLine("Creating email ");
            var to = GetInput("To: ");
            var text = GetInput("Text: ");
            var cc = GetInput("CC: ");
            var bcc = GetInput("BCC: ");
            var email = new Email(from.username,to, cc, bcc, text);
            var isSend = GetInput("Do you wanna sent it? (y/N)");
            if (isSend.ToLower().Equals("y"))
            {
                email.Send();
            }
            email.SaveToHistory();
        }

        public void printMailList(List<Email> messages)
        {
            if (messages.Count == 0)
            {
                Console.WriteLine("No messages yet...");
                return;
            }

            foreach (var email in messages)
            {
                Console.WriteLine(email.toStringToUser(user.username));
            }
        }
        
        public static string GetInput(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }
    }
}
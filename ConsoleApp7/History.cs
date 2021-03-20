using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConsoleApp7
{
    public class History
    {
        private static List<Email> emails = new();
        private static List<User> users = new() {new User("rdiachuk"), 
            new User("rdiachuk2"), new User("rdiachukBCC")};

        public static void SaveEmail(Email email)
        {
            emails.Add(email);
            Console.WriteLine($"backup {email}");
        }
        // username
        // email.from == username && email.status == "sent" -> Outbox
        // email.to == username && email.status == "sent" -> Inbox
        // email.from == username && email.status == "draft" -> Draft

        public static List<Email> GetOutbox(string username)
        {

            return getUserByUsername(username).outbox;

        }

        public static List<Email> GetInbox(string username)
        {
            return getUserByUsername(username).inbox;
        }

        public static List<Email> GetDraft(string username) 
        {
            return getUserByUsername(username).drafts;


        }

        public static User getUserByUsername(string username)
        {
            return users.First(user => user.username == username);
            throw new Exception("User does not exist");
        }

        public static Email getEmailById(int id)
        {
            foreach (var email in emails)
            {
                if (email.id == id)
                {
                    return email;
                }
            }

            throw new Exception("Email does not exist");
        }
        
    }
}
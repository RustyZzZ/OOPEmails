using System;

namespace ConsoleApp7
{
    public class Email
    {
        public static int lastIndex = 0;
        public int id;
        public User from;
        public User to;
        public User cc;
        public User bcc;
        public string text;
        public DateTime sentTime;
        public Status status;
        public bool read;

        public Email(string from, string to, string text)
        {
            this.from = History.getUserByUsername(from);
            this.to = History.getUserByUsername(to);
            this.text = text;
            sentTime = DateTime.Now;
            status = Status.DRAFT;
            id = ++lastIndex;
            read = false;
        }

        public Email(string from, string to, string cc, string bcc, string text) : this(from,to, text)
        {
            if (to != cc)
            {
                this.cc = History.getUserByUsername(cc);
            }
            
            if (to != bcc)
            {
                this.bcc = History.getUserByUsername(bcc);
            }

          
        }


        public override string ToString()
        {
            return "Email: \n"+
                $"id = {id} \n from = {from.username}\n cc = {(cc?.username)} \n" +
                $"to = {to.username} \n text = {text} \n status = {status}\n read = {read} \n";
        }

        public string toStringToUser(string username)
        {
            if (username.Equals(from.username) || username.Equals(bcc.username))
            {
                return "Email: \n"+
                       $"id = {id} \n from = {from.username}\n cc = {(cc?.username)} " +
                       $"\n bcc = {(bcc?.username)} \n" +
                       $"to = {to.username} \n text = {text} \n status = {status}\n read = {read} \n";
            }

            return ToString();
        }

        public virtual void SaveToHistory()
        {
            History.SaveEmail(this);
            if (status == Status.SENT)
            {
                from.outbox.Add(this);
                to.inbox.Add(this);
                cc?.inbox.Add(this);
                bcc?.inbox.Add(this);
            }
            else
            {
                from.drafts.Add(this);
            }
        }

        public virtual void Send()
        {
            this.status = Status.SENT;
        }

        public virtual void Read()
        {
            if (status != Status.SENT && status != Status.NOTIFIED) throw new Exception("Can`t read not sent message");

            this.read = true;
        }
    }

    public enum Status
    {
        DRAFT,
        SENT,
        NOTIFIED
    }
}
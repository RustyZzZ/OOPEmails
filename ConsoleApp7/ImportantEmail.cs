using System;

namespace ConsoleApp7
{
    public class ImportantEmail : Email
    {
        public int notifyAfterHours;
        public ImportantEmail(string from, string to, string text, int notifyAfterHours) : base(from, to, text)
        {
            this.notifyAfterHours = notifyAfterHours;
        }

        public ImportantEmail(string from, string to, string cc, string text, int notifyAfterHours) : base(@from, to, cc, null, text)
        {
            this.notifyAfterHours = notifyAfterHours;
        }
        
        public override void Read()
        {
            base.Read();
            if (read && status == Status.SENT)
            {
                Notify();
            }

        }
        
        public override string ToString()
        {
            return "ImportantEmail: \n"+
                   $"id = {id} \n from = {from.username}\n cc = {(cc?.username)} \n" +
                   $"to = {to.username} \n text = {text} \n status = {status}\n read = {read} \n" +
                   $"notifyAfterHours = {notifyAfterHours} \n";
        }

        public void Notify()
        {
            Console.WriteLine($"THIS IS VERY IMPORTANT EMAIL. READ IT ID={id}");
            this.status = Status.NOTIFIED;
        }
    }
}
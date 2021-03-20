using System.Collections.Generic;
using System.Data;

namespace ConsoleApp7
{
    public class User
    {
        public string username;
        public List<Email> inbox;
        public List<Email> outbox;
        public List<Email> drafts;

        public User(string username)
        {
            this.username = username;
            inbox = new List<Email>();
            outbox = new List<Email>();
            drafts = new List<Email>();
        }
    }

    public struct Coords
    {
        public Coords(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public override string ToString() => $"({X}, {Y})";
    }
}
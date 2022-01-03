using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    #region Iterator
    public interface IIterator
    {
        void First();
        string Next();
        bool IsEnd();
        string CurrentItem();
    }
    public class ScienceIterator : IIterator
        {
            private LinkedList<string> Subjects;
            private int position;
            public ScienceIterator(LinkedList<string> subjects)
            {
                this.Subjects = subjects;
                position = 0;
            }

            public string CurrentItem()
            {
            return Subjects.ElementAt(position);
        }

            public void First()
            {
            position = 0;
            }

            public bool IsEnd()
            {
            return position < Subjects.Count ? false : true;
            }

            public string Next()
            {
            return Subjects.ElementAt(position++);
            }
        }
    public class ArtIterator : IIterator
        {
        private string[] Subjects;
        private int position;
            public ArtIterator(string[] subjects)
            {
                this.Subjects = subjects;
                position = 0;
            }

            public string CurrentItem()
            {
                return Subjects.ElementAt(position);
            }

            public void First()
            {
                position = 0;
            }

            public bool IsEnd()
            {
                return position < Subjects.Length ? false : true;
            }

            public string Next()
            {
                return Subjects.ElementAt(position++);
            }
        }
    #endregion
    #region Aggragate
    public interface ISubjects
    {
        IIterator CreateIterator();
    }
    public class Science : ISubjects
    {
        private LinkedList<string> Subjects;
        public Science()
        {
            Subjects = new LinkedList<string>();
            Subjects.AddFirst("Mathematics"); 
            Subjects.AddFirst("Computer Science"); 
            Subjects.AddFirst("Physics"); 
            Subjects.AddFirst("Electronics");
        }

        public IIterator CreateIterator()
        {
            return new ScienceIterator(Subjects);
        }
    }
    public class Art : ISubjects
    {
        private string[] Subjects;
        public Art()
        {
            Subjects = new[] { "English", "History", "Geography", "Psychology" };
        }
        public IIterator CreateIterator()
        {
            return new ArtIterator(Subjects);
        }
    }
    #endregion

    class Program
    {
        public static void Print(IIterator iterator)
        {
            while (!iterator.IsEnd())
            {
                Console.WriteLine(iterator.Next());
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("***Iterator Pattern Demonstration.***");
            // For Science
            ISubjects subjects = new Science();
            IIterator iterator = subjects.CreateIterator();
            Console.WriteLine("\nScience subjects :");
            Print(iterator);
            // For Arts
            subjects = new Art();
            iterator = subjects.CreateIterator();
            Console.WriteLine("\nArts subjects :");
            Print(iterator);
            
            Console.ReadLine();
        }
    }
}

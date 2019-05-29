using System;
namespace BucketSortList
{
    public class SortableObject : IComparable<SortableObject>
    {
        public int Number { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return String.Format("{0,2} {1}", Number, Text);
        }

        public int CompareTo(SortableObject obj)
        {
            if (Number < obj.Number) return 1;
            if (Number > obj.Number) return -1;

            if (String.Compare(Text, obj.Text) == 1) return 1;
            if (String.Compare(Text, obj.Text) == -1) return 1;

            return 0;
        }

        public static bool operator >(SortableObject x, SortableObject y)
        {
           // Console.WriteLine("a");

            if (x.Number < y.Number) return false;
           // Console.WriteLine("b");
            if (x.Number > y.Number) return true;
           // Console.WriteLine("c");

            if (String.Compare(x.Text, y.Text) == 1) return false;
            //Console.WriteLine("d");
            if (String.Compare(x.Text, y.Text) == -1) return true;
          // Console.WriteLine("e");

            return false;
        }

        public static bool operator <(SortableObject x, SortableObject y)
        {
            Console.WriteLine("a");
            if (x.Number < y.Number) return true;
            Console.WriteLine("b");
            if (x.Number > y.Number) return false;
            Console.WriteLine("c");

            if (String.Compare(x.Text, y.Text) == 1) return true;
            Console.WriteLine("d");

            if (String.Compare(x.Text, y.Text) == -1) return false;
            Console.WriteLine("e");

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryingOut
{
    class Program
    {
        static void Main(string[] args)
        {

            string first = "Sie tanzen in die Straße.";
            string second = "Sie tanzen in die Strasse.";

            Console.WriteLine("First sentence is {0}", first);
            Console.WriteLine("Second sentence is {0}", second);

            // Store CultureInfo for the current culture. Note that the original culture 
            // can be set and retrieved on the current thread object.
           // System.Threading.Thread thread = System.Threading.Thread.CurrentThread;
           // System.Globalization.CultureInfo originalCulture = thread.CurrentCulture;

            // Set the culture to en-US.
          //  thread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            // For culture-sensitive comparisons, use the String.Compare  
            // overload that takes a StringComparison value. 
            int i = String.Compare(first, second, StringComparison.Ordinal);
            Console.WriteLine("Comparing in {0} returns {1}.", "e", i);

            // Change the current culture to Deutch-Deutchland.
          //  thread.CurrentCulture = new System.Globalization.CultureInfo("de-DE");
           // i = String.Compare(first, second, StringComparison.CurrentCulture);
          //  Console.WriteLine("Comparing in {0} returns {1}.", thread.CurrentCulture.Name, i);

            // For culture-sensitive string equality, use either StringCompare as above 
            // or the String.Equals overload that takes a StringComparison value.
        //    thread.CurrentCulture = originalCulture;
           bool b = String.Equals(first, second, StringComparison.CurrentCulture);
            Console.WriteLine("The two strings {0} equal.", b == true ? "are" : "are not");

            Console.ReadLine();
        }
    }
}

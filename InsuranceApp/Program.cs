//imports

//global variables
//main process or when run --- above main method
namespace InsuranceApp
{
   
    internal class Program
    {
        //global variable
        static List<string> deviceCategory = new List<string>()
    {
      "Laptop", "Desktop", "Other(such as a smartphone or drone)"
    };
        //methods and functions
        static void OneDevice()
        {
            //User enters Device Name
            Console.WriteLine("Enter Device's name");
            Console.ReadLine();
            Console.Clear();

            //User enters number of devices used at school
            Console.WriteLine("Enter number of devices used at school");
            Console.ReadLine();
            Console.Clear();

            //User enters category of device
            Console.WriteLine("Enter Device Category");
            Console.ReadLine();
            Console.Clear();



            


            //User enters cost for each device
            Console.WriteLine("Enter Cost For Device");
            Console.ReadLine();
            Console.Clear();

            //Display all user info
            Console.WriteLine


            



        }

        //Main process
        static void Main(string[] args)
        {
            //display app title
            Console.WriteLine("Insurance App");

            //call OneDevice()
            OneDevice();
;


        }



    }

    
}
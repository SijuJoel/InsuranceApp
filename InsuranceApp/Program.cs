//imports

//main process or when run --- above main method
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace InsuranceApp
{
    internal class Program
    {
        //global variable
        //list of strings, of device type
        readonly static List<string> DEVICECATEGORY = new List<string>()

        {
          "Laptop", "Desktop", "Other(such as a smartphone or drone)"
        };
        


        static int laptopCounter = 0, desktopCounter = 0, otherCounter = 0;
        static string mostExpensiveDeviceName;
        static float totalInsuranceCost = 0, mostExpensiveDevice = 0;
        private static string menu;
 
        //methods and functions

        //this is used to display errors for devicecost, numofdevice, and devicecategory
        static float Checkfloat(string question, float min, float max)

        {
            while (true)

                try

                {

                    Console.WriteLine(question);

                    float userfloat = (float)Convert.ToDecimal(Console.ReadLine());

                    if (userfloat >= min && userfloat <= max)

                    {
                        return userfloat;
                    }

                    DisplayErrorMessage($"ERROR: You must enter an integer between {min} and {max}");

                }

                catch

                {
                    DisplayErrorMessage($"ERROR: You must enter an integer between {min} and {max}");
                }
            //makes error message color red
            static void DisplayErrorMessage(string error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ForegroundColor = ConsoleColor.White;

            }
        }
        //checks if the itergers typed in aren;t letters ad spaced out, if wrong information is entered a error messga eis shown
        static int Checkint(string question, int min, int max)
        {
            while (true)

                try

                {



                    Console.WriteLine(question);

                    int userint = Convert.ToInt32(Console.ReadLine());

                    if (userint >= min && userint <= max)

                    {
                        return userint;
                    }

                    DisplayErrorMessage($"ERROR: You must enter an integer between {min} and {max}");
                }

                catch

                {
                    DisplayErrorMessage($"ERROR: You must enter an integer between {min} and {max}");
                }
            //makes the error message the color red
            static void DisplayErrorMessage(string error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ForegroundColor = ConsoleColor.White;

            }
        }


        static void OneDevice()
        {
            

            string deviceName; //this is a string which will return what ever the user puts in, which in this case will be the devicename
            int numOfDevice, deviceCategory; // this int means that it will return a whole number without decimals
            float deviceCost, depreciation, insuranceCost = 0; //floats mean that it returns a number with decimal


           



            //makes error message color red
            static void DisplayErrorMessage(string error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error);
                Console.ForegroundColor = ConsoleColor.White;

            }


            //User enters Device Name
            Console.WriteLine("Enter Device's name:");
            deviceName = Console.ReadLine();
             
            if (string.IsNullOrEmpty(deviceName))

            {
                DisplayErrorMessage("ERROR: Device Name must be entered");
                OneDevice();
                return;
            }
            Console.WriteLine();




            //User enters category of device
            int categoryCount = 0;
            Console.WriteLine("Enter Device Category:");
            Console.WriteLine("pick a number 1, 2, or 3");
            Console.WriteLine("1.Laptop");
            Console.WriteLine("2.Desktop");
            Console.WriteLine("3.Other(such as a smartphone or drone):");
            deviceCategory = Checkint(menu, 1, 3);




            //user enters cost for device
            deviceCost = Checkfloat("Enter the Device cost:\n", 0, 1000000);


            //User enters number of devices used at school
            numOfDevice = Checkint("Enter the number of devices used at school:\n", 0, 1000000);
         
            
          
            //calculate insurance
            if (numOfDevice > 5)
            {
                insuranceCost += deviceCost;
                insuranceCost = +(numOfDevice - 5);

            }

            if (numOfDevice < 6)
            {
                insuranceCost += (numOfDevice - 5) * deviceCost * 0.9f;
            }
            else
            {
                insuranceCost += numOfDevice * deviceCost;

            }
            //display summary
            Console.WriteLine($" {deviceName}");
            Console.WriteLine($"total cost for {numOfDevice} x {deviceName} is  =  ${insuranceCost} ");

            //calculate depreciation over 6 months
            Console.WriteLine("Depreciation value for device along 6 month period");
            Console.WriteLine("Month   Value Loss");
            
            depreciation = deviceCost;
            for (int month = 0; month < 6; month++)

            {

                depreciation = depreciation * 0.95f;
                depreciation = (float)Math.Round(depreciation, 2);
                Console.WriteLine($"{month + 1}\t ${depreciation}");

            }

            Console.WriteLine($"Category:{DEVICECATEGORY[deviceCategory-1]}");



            //calculate how many of each  category
            if (deviceCategory.Equals(1))
            {
                laptopCounter += numOfDevice;
            }
            else if (deviceCategory.Equals(2))
            {
                desktopCounter += numOfDevice;
            }
            else if (deviceCategory.Equals(3))
            {
                otherCounter += numOfDevice;
            }
            //end of the display summary first part

            //calculate the total insurance cost
            totalInsuranceCost += insuranceCost;

            //calculate the most expensive device
            if (insuranceCost > mostExpensiveDevice)
            {
                mostExpensiveDevice = insuranceCost;
                mostExpensiveDeviceName = deviceName;
            }
        }

      
        //check if they chose the option "X" or "Enter" if not show a error
        static string CheckProceed()
        {

            while (true)
            {
                Console.WriteLine("press <Enter> to add another device or type 'X' to exit");
                string checkProceed = Console.ReadLine();

                checkProceed = checkProceed.ToUpper();
                if (checkProceed.Equals("") || checkProceed.Equals("X"))
                {
                    return checkProceed;
                }

                DisplayErrorMessage("Error invalid response");
            }
        }
        //makes error messgae color red
        static void DisplayErrorMessage(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.White;

        }


    


        //Main process
        //to Add another device after they press "Enter"
        static void Main(string[] args)
            {
                //display app title
                Console.WriteLine("Insurance App");
                Console.WriteLine();
                string proceed = "";
                while (proceed.Equals(""))
                {
                    OneDevice();
                    proceed = CheckProceed();

                }
                //display second part of summary after user enters "x"
                Console.WriteLine($"The number of Laptops: {laptopCounter}");
                Console.WriteLine($"The number of Desktops: {desktopCounter}");
                Console.WriteLine($"The number of other Device: {otherCounter}");

                //display total value for insurance
                Console.WriteLine($"The total value for Insurance:${totalInsuranceCost}");

                //display the most expensive device
                Console.WriteLine($"The most expensive device - {mostExpensiveDeviceName} costing ${mostExpensiveDevice}");



            }
    }
}

    
       


    
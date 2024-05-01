//imports

//main process or when run --- above main method
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace InsuranceApp
{
   
    internal class Program
    {
        //global variable
        static List<string> deviceCategory = new List<string>()
        
        {
          "Laptop", "Desktop", "Other(such as a smartphone or drone)"
        };
        
        static int laptopCounter, desktopCounter, otherCounter;
        static string mostExpensiveDeviceName;
        static float totalInsuranceCost, mostExpensiveDevice = 0;
      
        //methods and functions
        static void OneDevice()
        {


           
            string deviceName;
            int numOfDevice, deviceCategory;
            float deviceCost, depreciation, insuranceCost = 0;
            

            //User enters Device Name
            Console.WriteLine("Enter Device's name:");
            deviceName  = Console.ReadLine();
            Console.WriteLine();
            

            //User enters category of device
            Console.WriteLine("Enter Device Category:");
            Console.WriteLine("pick a number 1, 2, or 3");
            Console.WriteLine("1.Laptop");
            Console.WriteLine("2.Desktop");
            Console.WriteLine("3.Other(such as a smartphone or drone):");
            deviceCategory = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();


            //User enters number of devices used at school
            Console.WriteLine("Enter number of devices used at school:");
            numOfDevice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            //user enters cost for device
            Console.WriteLine("Enter Device Cost:");
            deviceCost = (float)Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();








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
            Console.WriteLine("Month   Value Loss");
            Console.WriteLine("Depreciation value for device along 6 month period");
            depreciation = deviceCost;
            for (int month = 0; month < 6; month++)

            {
                
                depreciation = depreciation * 0.95f;
                depreciation = (float)Math.Round(depreciation, 2);
                Console.WriteLine($"{month + 1}\t ${depreciation}");

            }

            Console.WriteLine($"Category:{deviceCategory}");

            

            //display how many of each  category
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

        //Main process
        static void Main(string[] args)
        {
            //display app title
            Console.WriteLine("Insurance App");
            Console.WriteLine();
            
            string proceed = "";
            while (proceed.Equals(""))
            {
                //call OneDevice()
                OneDevice();

                Console.WriteLine("Press <ENTER> To Add Another Device or type X to Exit");
                proceed = Console.ReadLine();
                Console.WriteLine();

            }
            //display second part of summary
            Console.WriteLine($"The number of Laptops: {laptopCounter}");
            Console.WriteLine($"The number of Desktops: {desktopCounter}");
            Console.WriteLine($"The number of other Device: {otherCounter}");

            //display total value for insurance
            Console.WriteLine($"The total value for Insurance:{totalInsuranceCost}");

            //display the most expensive device
            Console.WriteLine($"The most expensive device - {mostExpensiveDeviceName} @ {mostExpensiveDevice}");

            










            


        }



    }

    
}
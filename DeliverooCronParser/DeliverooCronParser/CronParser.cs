using System;

namespace DeliverooCronParser
{
    public class Program
    {
        public void PrintRange(string arg)
        {
            try
            {
                //print each day of month in range
                for (int i = Int32.Parse(arg[0].ToString()); i <= Int32.Parse(arg.Substring(arg.IndexOf('-') + 1)); i++)
                {
                    Console.Write(i + " ");
                }
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void PrintFew(string arg)
        {
            try
            {
                //print each character
                foreach (char c in arg)
                {
                    //replace comma with space
                    if (c == ',')
                    {
                        Console.Write(" ");
                    } //check to see if the character is the last character and add a new line
                    else
                    {
                        Console.Write(c);
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        //Print Minutes
        public bool PrintMins(string arg)
        {
            



            try
            {
                Console.Write("Minutes\t\t|\t");

                if (arg == "*")
                {
                    Console.WriteLine("60");
                    return true;
                }

                //check to see if there is a division
                if (arg.Substring(0, 2) == "*/" && 60 % Int32.Parse(arg.Substring(2)) == 0)
                {
                    //print value
                    for (int i = 0; i < 60; i += Int32.Parse(arg.Substring(2)))
                    {
                        Console.Write(i + " ");
                    }
                    Console.Write("\n");
                    return true;

                }

                //Check to see if value is valid
                if (60 % Int32.Parse(arg) == 0)
                {
                    for (int i = 0; i < 60; i += Int32.Parse(arg))
                    {
                        Console.Write(i + " ");
                    }

                    Console.Write("\n");
                    return true;
                }

                Console.WriteLine("No Valid Output");
                return false;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        //PRINT DAY OF MONTH
        public bool PrintDOM(string arg)
        {

            Console.Write("Day of Month\t|\t");
            //check to see if there is a comma
            try
            {
                //check to see if there is a comma
                if (arg.IndexOf(',') > -1)
                {
                    PrintFew(arg);
                    Console.Write("\n");
                    return true;
                } //check to see if there is a range

                //check to see if there is range 
                if (arg.IndexOf('-') > -1)
                {
                    PrintRange(arg);
                    Console.Write("\n");
                    return true;
                } //if input is invalid 

                Console.WriteLine("No Valid Output");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //PRINT MONTHS OF YEAR
        public bool PrintMonths(string arg)
        {
            Console.Write("Month\t\t|\t");
            try
            {   //check to see if "all" is called
                if (arg == "*")
                {
                    Console.WriteLine("1 2 3 4 5 6 7 8 9 10 11 12");
                    return true;
                }

                if (arg.IndexOf('-') > -1) //check to see if there is a range
                {
                    PrintRange(arg);
                    Console.Write("\n");
                    return true;
                }

                if (arg.IndexOf('/') > -1 && 12 % Int32.Parse(arg.Substring(arg.IndexOf('/') + 1)) == 0)
                {
                    int range = Int32.Parse(arg.Substring(arg.IndexOf('/') + 1));
                    for (int i = range; i < 13; i += range)
                    {
                        Console.Write(i + " ");
                    }
                    Console.Write("\n");
                    return true;
                }

                if (arg.IndexOf(',') > -1)
                {
                    PrintFew(arg);
                    Console.Write("\n");
                    return true;
                }

                Console.WriteLine("No Valid Output");
                return false;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }


        }

        //PRINT WEEK 
        public bool PrintWeek(string arg)
        {
            try
            {
                Console.Write("Day of Week\t|\t");
                if (arg == "*")
                {
                    Console.WriteLine("1 2 3 4 5 6 7");
                    return true;
                }

                if (arg.IndexOf('-') > -1)
                {
                    PrintRange(arg);
                    Console.Write("\n");
                    return true;
                }

                if (arg.IndexOf(',') > -1)
                {
                    PrintFew(arg);
                    Console.Write("\n");
                    return true;
                }

                Console.WriteLine("No Valid Output");
                return false;
            } catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        //PRINT HOURS OF DAY
        public bool PrintHour(string arg)
        {
            try
            {
                int hour = Int32.Parse(arg);
                Console.Write("Hour\t\t|\t");

                if (arg.IndexOf(',') > -1)
                {
                    PrintFew(arg);
                    Console.Write("\n");
                    return true;
                }

                if (arg.IndexOf('-') > -1)
                {
                    PrintRange(arg);
                    Console.Write("\n");
                    return true;
                }

                if (hour > 0)
                {
                    for (int i = 0; i < 25; i += hour)
                    {
                        Console.Write(i + " ");
                    }
                    Console.Write("\n");
                    return true;
                }

                if (hour == 0)
                {
                    Console.Write(arg + "\n");
                    return true;
                }

                Console.WriteLine("No Valid Output");
                return false;
            } catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        //MAIN
        static void Main(string[] args)
        {
            //create program instance
            Program CronParser = new Program();

            Console.WriteLine("\nCron Expression Parser - Deliveroo Demo - Joseph Hoang\n\nInfo\t\t|\tValue\n-----------------------------------");
            //loop through each command line argument
            //dependent on the index of the argument run certain functions
            bool printedMins, printedHours, printedDOM, printedMonths, printedWeek;

            for (int i = 0; i < args.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        printedMins = CronParser.PrintMins(args[i]);
                        Console.WriteLine("-----------------------------------");
                        break;
                    case 1:
                        printedHours = CronParser.PrintHour(args[i]);
                        Console.WriteLine("-----------------------------------");
                        break;
                    case 2:
                        printedDOM = CronParser.PrintDOM(args[i]);
                        Console.WriteLine("-----------------------------------");
                        break;
                    case 3:
                        printedMonths = CronParser.PrintMonths(args[i]);
                        Console.WriteLine("-----------------------------------");
                        break;
                    case 4:
                        printedWeek = CronParser.PrintWeek(args[i]);
                        Console.WriteLine("-----------------------------------");
                        break;
                    case 5:
                        Console.WriteLine("Command\t\t|\t" + args[i]);
                        Console.WriteLine("-----------------------------------");
                        break;
                    default:
                        Console.WriteLine("Too Many Commands");
                        break;
                }
            }
            Console.WriteLine("\n");


        }
    }
}

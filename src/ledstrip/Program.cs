using System;

namespace ledstrip
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ledStrip = new LedStrip();
            var input = String.Empty;

            PrintMenu();

            while((input = Console.ReadLine().ToLower().Trim()) != "q") {
                try {
                    LedOperation(ledStrip, input);
                } catch (ArgumentException e)
                {
                    Console.WriteLine($"{e.Message}");
                }
                Console.WriteLine("Press any key...\n");
                Console.ReadKey();
                PrintMenu();
            }

            Console.WriteLine($"Current LED values: {ledStrip.GetValues()}");            
        }

        private static void PrintMenu() {
            Console.WriteLine("To turn light on enter: 'on'");
            Console.WriteLine("Turn light off enter: 'off'");
            Console.WriteLine("To edit color input: 'set X Y Z'");
            Console.WriteLine("To quit press 'q'\n");
        }

        private static void LedOperation(LedStrip ledStrip, string input)
        {
            string[] values = input.Split(' ');
            switch(values[0])
                {
                    case "on":
                        ledStrip.TurnOn();
                        break;

                    case "off":
                        ledStrip.TurnOff();
                        break;

                    case "set":
                        if(values.Length == 4)  
                        {
                            int i = 0;
                            bool isNumeric_1 = int.TryParse(values[1], out i);
                            bool isNumeric_2 = int.TryParse(values[2], out i);
                            bool isNumeric_3 = int.TryParse(values[3], out i);
                            if(isNumeric_1 && isNumeric_2 && isNumeric_3)
                            {
                                try 
                                {
                                    byte r = byte.Parse(values[1]);
                                    byte g = byte.Parse(values[2]);
                                    byte b = byte.Parse(values[3]);                        
                                    ledStrip.Edit(r, g, b);
                                }
                                catch (OverflowException e)
                                {
                                    Console.WriteLine($"{e.Message}");
                                }
                            }
                            else 
                            {
                                throw new ArgumentException("Input is not in correct format");
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Invalid number of values.");
                        }
                        break;

                    default:
                        throw new ArgumentException("Unknown command.");
                }
        }
    }
}

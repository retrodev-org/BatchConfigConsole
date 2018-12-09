using System;
using System.Collections.Generic;

namespace BatchConfigConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int mode = 0;
            string input = null;
            string newVarName = null;
            int newVarLength = 0;
            string newVarType = "string";
            string inputName = null;
            List<string> varList = new List<string>();

            while (mode == 0 || mode == 1)
            {
                while (mode == 0)
                {
                    Console.Write("Variable Name: ");
                    input = Console.ReadLine();

                    if (input == "print")
                    {
                        mode = 1;
                    }
                    else if (input == "exit")
                        mode = 2;
                    else
                    {
                        mode = 0;
                        inputName = input;

                        Console.Write("Length: ");
                        input = Console.ReadLine();

                        try
                        {
                            newVarLength = Int32.Parse(input);
                            newVarName = inputName;
                            // TODO newVarType update

                            string varBegin = "<" + newVarName + ">";
                            string varEnd = "</" + newVarName + ">";

                            string varType = "<type>" + newVarType + "</type>";
                            string varLength = "<length>" + newVarLength.ToString() + "</length>";
                            string varDescription = "<description>" + newVarName + "</DescriptionAttribute>";

                            varList.Add(varBegin);
                            varList.Add(varType);
                            varList.Add(varDescription);
                            varList.Add(varEnd);
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine("Error: invalid length. Try again. " + error);
                        }
                    }
                } // end while(mode == 0)

                if (mode == 1)
                {
                    Console.Write("Print list? (Y/N) ");
                    input = Console.ReadLine();
                    if (input == "Y" || input == "y" || input == "yes" || input == "Yes")
                    {
                        foreach (var str in varList)
                        {
                            Console.WriteLine(str);
                        }

                        Console.Write("Start again? (Y/N) ");
                        input = Console.ReadLine();
                        if (input == "N" || input == "n" || input == "no" || input == "No")
                            mode = 2;
                        else
                            mode = 0;
                    }
                }
            } // end while(mode == 0 || mode == 1)
        }
    }
}

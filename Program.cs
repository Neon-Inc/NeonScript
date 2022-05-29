using System;
using System.Collections.Generic;
using System.IO;

namespace ProgrammingLanguage1
{
    public class Program
    {
        public static Dictionary<string, string> variables = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            try{
                string file = args[0];
                string[] lines = System.IO.File.ReadAllLines(file);
                foreach (string line in lines){
                    parsecommand(line);
                }
                Console.ReadKey();
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }

        }
        public static void parsecommand(string line){
            string[] words = line.Split(' ');
            string command = words[0];
            switch (command){
                case "print":
                    commandFuncs.print(words);
                    break;
                case "read":
                    commandFuncs.input(words);
                    break;
                case "if":
                    commandFuncs.ifstatement(words);
                    break;
                case "title":
                    Console.Title = words[1];
                    break;



                default:
                    break;
            }}}
    public class commandFuncs{
        public static void ifstatement   (string[] args){
            string condition1 = args[1];
            //the "iffer"
            string iffer = args[2];
            string condition2 = args[3];
            string action = ""; 
            for (int i = 4; i < args.Length ; i++)
            {
                action += args[i] + " ";
            }
            switch (iffer){
                case "==":
                    if (condition1 == condition2){
                        goto action;
                    }else return;
                    break;
                case "!=":
                    if (condition1 != condition2){
                        goto action;
                    }else return;
                    break;
                case ">":
                    if (int.Parse(condition1) > int.Parse(condition2)){
                        goto action;
                    }else return;
                    break;
                case "<":
                    if (int.Parse(condition1) < int.Parse(condition2)){
                        goto action;
                    }else return;
                    break;
                case ">=":
                    if (int.Parse(condition1) >= int.Parse(condition2)){
                        goto action;
                    }else return;
                    break;
                case "<=":
                    if (int.Parse(condition1) <= int.Parse(condition2)){
                        goto action;
                    }else return;
                    break;
                default:
                    break;
            }
        action:
            Program.parsecommand(action);
            return;




        }
        public static void Add           (string[] args){
            Program.variables.Add(args[1], args[2]);
        }
        public static void clearVariables(string[] args){
            Console.WriteLine("Do you want to clear all variables? (y/n)");
            char input = Console.ReadKey().KeyChar;
            if (input == 'y')
            {
                Console.Clear();
                Console.Write("Deleting all variables...");
                Program.variables.Clear();
            }
            
            
        }
        public static void removeVariable(string[] args)
        {
         Program.variables.Remove(args[1]);
         

        }
        public static void setVariable   (string[] args)
        {
            Program.variables[args[1]] = args[2];
        }
        public static void printVariable (string[] args)
        {
            Console.WriteLine(Program.variables[args[1]]);
        }
        public static void print         (string[] words){
            for (int i = 1; i < words.Length; i++)
            {
                Console.Write(words[i] + " ");
            }
        }
        public static void input         (string[] words)
        {
            Console.WriteLine(words[1]);
            string input = Console.ReadLine();
            Program.variables[words[1]] = input;
        }


        

    }
}
 

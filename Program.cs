using System;
using System.IO;
using System.Collections.Generic;
namespace NeonScript {
    class MainClass {
        public static List<string> includes = new List<string>();
        public static void Main(string[] args) {
            string input = "";
            foreach (string path in args) {
                if (path.Length > 0 && File.Exists(path)) {
                    input = path;
                }
            }
            File.WriteAllText("output.c","#include <stdio.h>\n#include <stdlib.h>\n" + Compile(input));

        }
        public static string Compile(string input) {
            string[] src = File.ReadAllLines(input);
            string ccode = "int main(){";
            foreach (string line in src) {
                ccode += parse(line + "\n");
            }
            foreach (string include in includes) {
                if (File.Exists(include)) {
                    ccode = Compile(include) + ccode;
                }
            }
            ccode += "return 0}";
            return ccode;
        }
        public static string parse(string src) {
            string output = "";
            string[] args = src.Split(' ');
            switch (args[0].ToLower()) {
                case "print":
                    output += "printf(\"";
                    for (int i = 1; i < args.Length - 1; i++) {
                        output += args[i] + " ";
                    }
                    output += args[args.Length - 1];
                    break;
                case "input":
                    output += "scanf(\"%s\",&" + args[1] + ");";
                    break;
                case "if":
                    switch (args[2]) {
                        case "==":
                            break;
                        case "!=":
                            break;
                        case "<":
                            break;
                        case ">":
                            break;
                        case "<=":
                            break;
                        case ">=":
                            break;
                        default:
                            //Error
                            System.Environment.Exit(-1);
                            break;
                    }
                    output = "if(" + args[1] + args[2] + args[3] + "){";
                    string inp = "";
                    for (int i = 4; i < args.Length; i++) {
                        inp += args[i];
                    }
                    output += parse(inp);
                    break;
                case "title":
                    output = "printf(\"%c]0;%s%c\", '\033', \"" + args[1] + "\", '\007')";
                    break;
                case "var":
                    output = "char[256] " + args[1] + " = " + args[2] + ";";
                    break;
                case "setvar":
                    output = "strcpy(&" + args[1] + ",\" " + args[2] + "\");";
                    break;
                case "line":
                    output = "printf(\"\\n\");";
                    break;
                case "jumppnt":
                    output = args[1] + "();return 0;} int " + args[1] + "(){";
                    break;
                case "jump":
                    output = args[1] + "();";
                    break;
                case "include":
                    includes.Add(args[1]);
                    break;
                case "cusc":
                    output = args[1].Replace("\\s", " ");
                    break;

            }
            return output;
        }
    }
}

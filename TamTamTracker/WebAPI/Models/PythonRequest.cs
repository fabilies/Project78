using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class PythonRequest
    {
        //Required 
        public string python_file_name = @"C:\Git\Project78\TamTamSuggestions\TamTamTracker\PythonApplication\PythonApplication.py";
        public string python_exe = @"C:\Users\fabia\AppData\Local\Programs\Python\Python36-32\python.exe";

        public string run_cmd()
        {
            // Python file
            string fileName = python_file_name;
           
            // Start process
            Process p = new Process();
            string suggestion = "";
                p.StartInfo = new ProcessStartInfo(python_exe, fileName)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                p.Start();

                suggestion = p.StandardOutput.ReadToEnd();
                // Example : "[1]\r\n"
                var chars_remove = new string [] { "[", "\r" , "]" , "\n" };
                foreach (var c in chars_remove)
                {
                    suggestion = suggestion.Replace(c, string.Empty);
                }
                
                p.WaitForExit();

            return suggestion;


        }


    }
    }
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;


namespace cmdEmulator
{
    public class cmdEmulatorClass
    {

        /// <summary>
        /// This method receives the cmd command to be executed as a string and then returns an interpreted message of the execution
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string cmdEmulator(string command)
        {
            int result = ExecuteCommand(command);
            switch (result)
            {

                case 0:
                    return "Comando Exitoso";
                    break;
                case 1:
                    return "Función Incorrecta";
                    break;
                case 2:
                    return "Hay un dato erróneo";
                    break;
                default:
                    return "No Ejecutado";
                    break;
            }
        }

        /// <summary>
        /// This method executes the CMD command invoking the cmd process with c#. This allows us to get the exit code to test for success
        /// it returns the code as an integer, which will be interpreted by the caller method
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private int ExecuteCommand(string command)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/C "+command)
            {
                CreateNoWindow=true,
                UseShellExecute=false,
                WorkingDirectory="C:\\",
            };

            var process = Process.Start(processInfo);
            process.WaitForExit();
            var exitCode = process.ExitCode;
            process.Close();
            return exitCode;
        }



    }
}

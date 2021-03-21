using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAPP
{
    /*
         * File sistem port: 8082 
         * GUI port: 8081
         * Kernel port: 8080
         * 
         */
    class Messages
    {
        private Comunication comunication;
        private App core;
        private Apps functions;

        public Messages(App core, Comunication comunication)
        {
            this.comunication = comunication;
            this.core = core;
            this.functions = new Apps(comunication);

        }

        public void Actions(string msg)
        {

            string[] msgClean = msg.Replace("<EOF>", "").Replace("{", "").Replace("}", "").Split(',');

            if (msgClean.Length > 2)
            {
                longMessage(msgClean, msg);
            }
            else
            {
                //shortMessage(msgClean);
            }

        }

        private void longMessage(string[] msgClean, string rawMsg)
        {
            switch (msgClean[0].Split(':')[1])
            {
                case "info":
                    if (msgClean[3].Split(':')[1] == "halt")
                    {
                        core.stopApp();
                    }
                    else
                    {
                        comunication.sendMessage(functions.childPID(msgClean[3].Split(':')[1]), 8081);
                    }
                    break;
                case "stop":
                    core.stopApp();
                    break;

                default:
                    break;



            }

            switch (msgClean[1].Split(':')[1])
            {
                case "GUI":
                    comunication.sendMessage(rawMsg, 8081);
                    break;
                case "GestorArc":
                    comunication.sendMessage(rawMsg, 8082);
                    break;
                case "kernel":
                    //core.stopKernel();
                    break;
                case "APP":
                    comunication.sendMessage(rawMsg, 8083);
                    break;
                default:
                    break;
            }
        }





    }
}

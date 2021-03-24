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
            Console.WriteLine(msg);
            string info = "";
            string[] inmsg;
            string[] msgClean = msg.Replace("<EOF>", "").Replace("{", "").Replace("}", "").Split(',');

            string[] action = msgClean[0].Split(':');
            string[] dts = msgClean[2].Split(':');


            if (dts[1] == "APP")
            {
                switch (action[1])
                {
                    case "start":
                        Console.WriteLine("hola");
                        inmsg = msgClean[3].Split('\"');
                        info = functions.startApps(inmsg[1]);
                        comunication.sendMessage(info, 8080);
                        break;
                    case "halt":
                        inmsg = msgClean[3].Split('\"');
                        functions.closeApp(inmsg[1]);
                        break;
                    case "stop":
                        core.stopApp();
                        break;
                }
            }


        }

        public string Response()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);

            var value = random.Next(0, 2);
            string msg = "";

            switch (value)
            {
                case 0:
                    msg = "{codterm:0, msg:”OK”}";
                    break;
                case 1:
                    msg = "{codterm:1, msg:”0”}";
                    break;
                case 2:
                    msg = "{codterm:2, msg:”Err”}";
                    break;
            }
            return msg;
        }




    }
}

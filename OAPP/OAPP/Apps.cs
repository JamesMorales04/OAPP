using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAPP
{
    class Apps
    {
        private Process[] pidApps = new Process[3];
        Comunication comunications;

        public Apps(Comunication comunications)
        {
            this.comunications = comunications;
        }
        public string childPID(string appSon)
        {

            int index = int.Parse(appSon[3].ToString()) - 1;

            try
            {
                var processId = pidApps[index].Id;

                Console.WriteLine(processId);
                return "" + processId;
            }
            catch (InvalidOperationException)
            {
                //No iniciado
            }

            return "";
        }

        public void startApps(string app)
        {

            int index = int.Parse(app[3].ToString()) - 1;


            pidApps[index] = new Process();

            pidApps[index].StartInfo.FileName = "notepad.exe";

            pidApps[index].EnableRaisingEvents = true;

            switch (index)
            {
                case 1:
                    pidApps[index].Exited += new EventHandler(App_Exited1);
                    break;
                case 2:
                    pidApps[index].Exited += new EventHandler(App_Exited2);
                    break;
                case 3:
                    pidApps[index].Exited += new EventHandler(App_Exited3);
                    break;
            }

            pidApps[index].Start();

            childPID(app);

        }

        private void App_Exited1(object sender, System.EventArgs e)
        {
            
            Console.WriteLine("aaaaaaaaaaa");
            //comunications.sendMessage("{ cmd:info, src:GUI, dst:GUI, msg:halt}", 8081);
        }
        private void App_Exited2(object sender, System.EventArgs e)
        {

            Console.WriteLine("aaaaaaaaaaa");
            //comunications.sendMessage("{ cmd:info, src:GUI, dst:GUI, msg:halt}", 8081);
        }
        private void App_Exited3(object sender, System.EventArgs e)
        {

            Console.WriteLine("aaaaaaaaaaa");
            //comunications.sendMessage("{ cmd:info, src:GUI, dst:GUI, msg:halt}", 8081);
        }

    }
}

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

        public string startApps(string app)
        {
            Console.WriteLine(app);
            try
            {
                int index = int.Parse(app[3].ToString()) - 1;
                if (pidApps[index] == null)
                {

                    pidApps[index] = new Process();

                    pidApps[index].StartInfo.FileName = "notepad.exe";

                    pidApps[index].EnableRaisingEvents = true;
                    Console.WriteLine(index);

                    switch (index)
                    {
                        case 0:
                            pidApps[index].Exited += new EventHandler(App_Exited1);
                            break;
                        case 1:
                            pidApps[index].Exited += new EventHandler(App_Exited2);
                            break;
                        case 2:
                            pidApps[index].Exited += new EventHandler(App_Exited3);
                            break;
                    }
                    Console.WriteLine("-------------");

                    pidApps[index].Start();

                    string pid = childPID(app);

                    return "{cmd:info, src:APP, dst:GUI, msg:\"" + app + "->" + pid + "\"}";
                }
                else
                {
                    return "{cmd:send, src:APP, dst:GUI, msg:\"Error->" + app + "already running\"}";
                }

            }
            catch (Exception)
            {
                return "{cmd:send, src:APP, dst:GUI, msg:\"Error->" + app + "not work\"}";
            }
        }

        public void closeApp(string app)
        {
            int index = int.Parse(app[3].ToString()) - 1;
            pidApps[index].CloseMainWindow();
            pidApps[index] = null;

        }
        private void App_Exited1(object sender, System.EventArgs e)
        {
            pidApps[0] = null;
            Console.WriteLine("aaaaaaaaaaa");
            comunications.sendMessage("{ cmd:send, src:APP, dst:GestorArc, msg:\"Log->Halt APP1\"}", 8080);
        }
        private void App_Exited2(object sender, System.EventArgs e)
        {
            pidApps[1] = null;
            Console.WriteLine("eeeeeeee");
            comunications.sendMessage("{ cmd:send, src:APP, dst:GestorArc, msg:\"Log->Halt APP2\"}", 8080);
        }
        private void App_Exited3(object sender, System.EventArgs e)
        {
            pidApps[2] = null;
            Console.WriteLine("iiiiiiiiiii");
            comunications.sendMessage("{ cmd:send, src:APP, dst:GestorArc, msg:\"Log->Halt APP1\"}", 8080);
        }

    }
}

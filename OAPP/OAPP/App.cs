using System;
using System.Threading;
namespace OAPP
{
    class App
    {
        static void Main(string[] args)
        {
            App core = new App();
            Comunication comunicationSet = new Comunication();
            /*Messages messages = new Messages(core, comunicationSet);

            comunicationSet.setterMessages(messages);

            Thread listener = new Thread(() => comunicationSet.StartListening(8080));
            listener.Start();
            */
            Apps prueba = new Apps(comunicationSet);

            prueba.startApps("APP3");

        }

        public void stopApp()
        {
            //TODO:
        }
    }
}

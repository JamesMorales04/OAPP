﻿using System;
using System.Threading;
namespace OAPP
{
    class App
    {
        static void Main(string[] args)
        {
            App core = new App();
            Comunication comunicationSet = new Comunication();
            Messages messages = new Messages(core, comunicationSet);

            comunicationSet.setterMessages(messages);

            Thread listener = new Thread(() => comunicationSet.StartListening(8083));
            listener.Start();

            //Apps prueba = new Apps(comunicationSet);

            //prueba.startApps("APP3");
            //prueba.startApps("APP1");

            //comunicationSet.sendMessage("", 8083);
            //messages.Actions("");
            //messages.Actions("{cmd:start, src:GUI, dst:APP, msg:\"APP2\"}");

        }

        public void stopApp()
        {
            System.Environment.Exit(1);
        }
    }
}

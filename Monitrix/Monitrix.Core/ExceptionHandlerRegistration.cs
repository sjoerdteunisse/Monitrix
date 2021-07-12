using System;
using System.Runtime.ExceptionServices;

namespace Monitrix.Core
{
    public class ExceptionHandlerRegistration
    {
       public enum HandlingType { SILENT }

        private HandlingType _handlingType;

        public ExceptionHandlerRegistration(HandlingType handlingType) 
        {
            this.Setup();
            this._handlingType = handlingType;
        }

        private void Setup() 
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (sender != null)
                Console.WriteLine(sender.ToString());

            Console.WriteLine("An unhandeld exception occured");

            Console.WriteLine(e.ExceptionObject.ToString());
        }

        static void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            if (sender != null)
                Console.WriteLine(sender.ToString());

            Console.WriteLine("An exception occured but was catched");
            
            Console.WriteLine(e.Exception.ToString());
        }
    }
}

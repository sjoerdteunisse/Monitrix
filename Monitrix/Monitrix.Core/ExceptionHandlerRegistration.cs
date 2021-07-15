using System;
using System.Runtime.ExceptionServices;

namespace Monitrix.Core
{
    public class ExceptionHandlerRegistration
    {
       public enum HandlingType { COUT }

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

        /// <summary>
        /// Catch all unhandeld exceptions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (sender != null)
                Console.WriteLine(sender.ToString());

            Console.WriteLine("An unhandeld exception occured");

            Console.WriteLine(e.ExceptionObject.ToString());
        }

        /// <summary>
        /// Catch all exceptions 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            if (sender != null)
                Console.WriteLine(sender.ToString());

            Console.WriteLine("An exception occured");

            Console.WriteLine(e.Exception.ToString());
        }
    }
}

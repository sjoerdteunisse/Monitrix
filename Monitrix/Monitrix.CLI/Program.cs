using Monitrix.Core;
using System;

namespace Monitrix.CLI
{
    class Program
    {
        static void Main(string[] args)
        {

            var excH = new ExceptionHandlerRegistration(ExceptionHandlerRegistration.HandlingType.COUT);
            
                throw new SystemException(":");

            try
            {
                throw new SystemException(":");

            }
            catch (Exception)
            {
            }
        }
    }
}

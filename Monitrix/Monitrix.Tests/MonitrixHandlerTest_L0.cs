using Xunit;
using System;
using Monitrix.Core;

namespace Monitrix.Tests
{
    public class MonitrixHandlerTest_L0
    {
        /// <summary>
        /// L1 test
        /// </summary>
        [Fact]
        public void Using_A_ExceptionHandler_Should_Insantiate_Correctly_And_Catch()
        {
            var exceptionMonitor = new ExceptionHandlerRegistration(ExceptionHandlerRegistration.HandlingType.COUT);

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

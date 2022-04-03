using EconomicManagementAPP.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace EconomicManagementAPP.test
{
    [TestClass]
    public class MinZeroTest
    {
        [TestMethod]
        public void ValueNegative_ReturnError()
        {
            var minZero = new MinZero();
            var data = -1;

            var context = new ValidationContext(new { Balance = data });

            var testResult = minZero.GetValidationResult(data, context);

            Assert.AreEqual("The balance must be greater than zero", testResult?.ErrorMessage);
        }

        [TestMethod]
        public void ValueNotDecimal_ReturnError()
        {
            var minZero = new MinZero();
            var data = "df";

            var context = new ValidationContext(new { Balance = data });

            var testResult = minZero.GetValidationResult(data, context);

            Assert.AreEqual("The balance must be a decimal", testResult?.ErrorMessage);
        }


        [TestMethod]
        public void NullData_NoErrorMessage()
        {
            var minZero = new MinZero();
            string data = null;

            var context = new ValidationContext(new { Balance = data });

            var testResult = minZero.GetValidationResult(data, context);

            Assert.IsNull(testResult);
        }
    }
}

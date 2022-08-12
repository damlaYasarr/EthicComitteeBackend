using Business.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestNinja.UnitTest
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void GetUserDetails_Test_Behavior()
        {
            var servis = new IUserManager();

           var result= servis.GetApplyforStudent(1);
            Assert.IsNotNull(result);
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutions.Domain.Shippers;

namespace TestSolutions.Domain.Tests
{
    [TestFixture]
    public class ShippersTest
    {
        private readonly Shipper _shipper;
        private const int ShipperId = 2;
        private const string CompanyName = "TestCompanyName";
        private const string ContactName = "TestContactName";

        public ShippersTest()
        {
            _shipper = new Shipper();
        }

        [Test]
        public void Test_Shipper_Set_Get_ShipperId()
        {
            _shipper.ShipperId = ShipperId;

            Assert.That(_shipper.ShipperId, Is.EqualTo(ShipperId));
        }

        [Test]
        public void Test_Shipper_Set_Get_CompanyName()
        {
            _shipper.CompanyName = CompanyName;

            Assert.That(_shipper.CompanyName, Is.EqualTo(CompanyName));
        }

        [Test]
        public void Test_Shipper_Set_Get_ContactName()
        {
            _shipper.ContactName = ContactName;

            Assert.That(_shipper.ContactName, Is.EqualTo(ContactName));
        }
    }
}

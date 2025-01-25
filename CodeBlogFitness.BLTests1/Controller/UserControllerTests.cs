using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrage
            var username = Guid.NewGuid().ToString();
            var birthdate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            //Act
            var controller = new UserController(username);
            controller.SetNewUserData(gender, birthdate, weight, height);
            var controler2 = new UserController(username);
            //assert
            Assert.AreEqual(username, controler2.CurrentUser.Name);
            Assert.AreEqual(birthdate, controler2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controler2.CurrentUser.Weight);
            Assert.AreEqual(height, controler2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrage
            var username = Guid.NewGuid().ToString();
            //Act
            var controller = new UserController(username);
            //Assert
            Assert.AreEqual(username, controller.CurrentUser.Name);
        }
    }
}
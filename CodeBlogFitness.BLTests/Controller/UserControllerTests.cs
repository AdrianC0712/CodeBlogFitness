using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrage
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-20);
            var weight = 115;
            var height = 176;
            var gender = "man";
            var controller = new UserController(userName);
            //Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);

            //Assert
            Assert.AreEqual(userName,controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate,controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight,controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender,controller2.CurrentUser.Gender);

        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrage
            var userName = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}
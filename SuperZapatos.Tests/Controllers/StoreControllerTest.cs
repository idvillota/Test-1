using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperZapatos.Controllers;
using SuperZapatos.Models;

namespace SuperZapatos.Tests.Controllers
{
    [TestClass]
    public class StoresControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            StoresController controller = new StoresController();

            // Act
            IEnumerable<Store> stores = controller.GetStores();

            // Assert
            Assert.IsNotNull(stores);
            Assert.AreEqual(3, stores.Count());
            var testStore = new Store { id = 1, Name = "Store 1", Address = "Street 1" };
            Assert.AreEqual(stores, testStore);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            StoresController controller = new StoresController();

            // Act
            var store = controller.GetStore(1);

            // Assert
            var testStore = new Store { id = 1, Name = "Store 1", Address = "Street 1" };
            Assert.AreEqual(store, testStore);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            StoresController controller = new StoresController();

            // Act
            var testStore = new Store { id = 100, Name = "Store 100", Address = "Street 100" };
            controller.PostStore(testStore);

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            StoresController controller = new StoresController();

            // Act
            var testStore = new Store { id = 100, Name = "Store 100", Address = "Street 100" };
            testStore.Name = "updated field";
            controller.PutStore(100, testStore);

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            StoresController controller = new StoresController();

            // Act
            controller.DeleteStore(100);

            // Assert
        }
    }
}

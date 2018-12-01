using System;
using System.Collections.Generic;
using BLL.Services.Concrete;
using DAL.Data.Abstract;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test
{
	[TestClass]
	public class UserServiceTest
	{
		readonly List<User> mockUsers = new List<User>() {
			new User(){ 
			Id = 0,
			Name = "Petr",
			Age = 1,
			LastName = "Bot",
			Password = "FakePass123"},
			new User(){
			Id = 1,
			Name = "Ivan",
			Age = 1,
			LastName = "Bot",
			Password = "FakePass123"
			}};
		[TestMethod]
		public void GetAllUsersTest()
		{
			Mock<IUserRepository> mock = new Mock<IUserRepository>();
			mock.Setup(m => m.Repository).Returns(mockUsers);
			UserService service = new UserService(mock.Object);

			Assert.AreEqual(service.GetAllUsers, mockUsers);
		}
	}
}

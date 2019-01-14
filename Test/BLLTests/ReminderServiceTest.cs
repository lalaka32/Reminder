using System;
using System.Collections.Generic;
using BLL.Services.Concrete;
using BLL.Services.Interfaces;
using DAL.Data.Interfaces;
using Entities;
using Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test
{
	[TestClass]
	public class UserServiceTest
	{


		private Mock<IReminderRepository> _reminderMock;
		private Mock<IStateRepository> _stateMock;
		private IReminderService _service;

		[TestInitialize]
		public void TestInitialize()
		{
			_reminderMock = new Mock<IReminderRepository>();
			_stateMock = new Mock<IStateRepository>();
			_stateMock.Setup(x => x.GetAll()).Returns(new List<StateOfReminder>() {
				new StateOfReminder() {

				Id = 1,
				Name = "Planned"

			},
			new StateOfReminder() {

				Id = 2,
				Name = "Deferred"
			},
			new StateOfReminder()
			{

				Id = 2,
				Name = "Completed"

			}});
			_service = new ReminderService(_reminderMock.Object, _stateMock.Object);
		}

		[TestMethod]
		public void CreateReminderValid()
		{
			//Arrange
			var reminder = new Reminder
			{
				Picture = new byte[0],
				Id = 1,
				DateOfCreation = DateTime.Now,
				User = new User() { Id = 1 },
				Category = new CategoryOfReminder() { Id = 1 },
				Name = "Sister birthday",
				DateOfEvent = DateTime.Now.AddHours(1),
				Description = "Host party"
			};

			//Act
			_service.Create(reminder);

			//Assert
			_reminderMock.Verify(r => r.Create(reminder), Times.Once);
		}

		[TestMethod]
		public void CreateReminderInValid()
		{
			//Arrange
			Reminder reminder = null;

			//Act
			_service.Create(reminder);

			//Assert
			_reminderMock.Verify(r => r.Create(reminder), Times.Never);
		}

		[TestMethod]
		public void UpdateReminderValid()
		{
			//Arrange
			var record = new Reminder
			{
				Id = 1,
				DateOfCreation = DateTime.Now,
				User = new User() { Id = 1 },
				Category = new CategoryOfReminder() { Id = 1 },
				Name = "Sister birthday",
				DateOfEvent = DateTime.Now.AddHours(1),
				Description = "Host party"
			};

			//Act
			_service.Update(record);

			//Assert
			_reminderMock.Verify(r => r.Update(record), Times.Once);
		}

		[TestMethod]
		public void UpdateReminderInvalid()
		{
			//Arrange
			Reminder record = null;

			//Act
			_service.Update(record);

			//Assert
			_reminderMock.Verify(r => r.Update(record), Times.Never);
		}

		[TestMethod]
		public void DeleteReminderValid()
		{
			//Arrange
			int? id = 1;

			//Act
			_service.Delete(id);

			//Assert
			_reminderMock.Verify(r => r.Delete(id), Times.Once);
		}

		[TestMethod]
		public void DeleteReminderInvalid()
		{
			//Arrange
			int? id = null;

			//Act
			_service.Delete(id);

			//Assert
			_reminderMock.Verify(r => r.Delete(id), Times.Never);
		}

		[TestMethod]
		public void GetReminderByIdValid()
		{
			//Arrange
			int? id = 1;

			_reminderMock.Setup(r => r.Read(It.IsAny<int>())).Returns((int idTest) => new Reminder
			{
				Id = idTest
			});

			//Act
			var result = _service.Read(id);

			//Assert
			Assert.AreEqual(id, result.Id);
		}

		[TestMethod]
		public void GetReminderByIdInvalid()
		{
			//Arrange
			int? id = 0;

			//Act
			var result = _service.Read(id);

			//Assert
			Assert.AreEqual(null, result);
		}

		[TestMethod]
		public void GetUserReminderValid()
		{
			//Arrange
			string login = "login";

			_reminderMock.Setup(r => r.GetRemindersByLogin(It.IsAny<string>())).Returns((string urerLogin) => new List<Reminder>
			{
				new Reminder
				{
					User = new User(){ Login = urerLogin }
				}
			});

			//Act
			var result = _service.GetUserReminders(login);

			//Assert
			_reminderMock.Verify(u => u.GetRemindersByLogin(login), Times.Once);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void GetUserRemindersInValid()
		{
			//Arrange
			string login = null;

			_reminderMock.Setup(r => r.GetRemindersByLogin(It.IsAny<string>())).Returns((string loginUser) => new List<Reminder>
			{
				new Reminder
				{
					 User = new User(){ Login = loginUser }
				}
			});

			//Act
			var result = _service.GetUserReminders(login);

			//Assert
			Assert.AreEqual(null, result);
		}

	}
}


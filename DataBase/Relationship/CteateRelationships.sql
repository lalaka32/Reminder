USE ReminderDB
GO


--FK

ALTER TABLE NotificationAndCategory
ADD CONSTRAINT FK_Notification_CategoryId FOREIGN KEY(NotificationId)
        REFERENCES Notifications(Id),
	CONSTRAINT FK_Category_NotificationId FOREIGN KEY(CategoryId)
		REFERENCES CategoryOfNotification(Id);

ALTER TABLE NotificationAndDoing
ADD CONSTRAINT FK_Notification_DoingId FOREIGN KEY(NotificationId)
        REFERENCES Notifications(Id),
	CONSTRAINT FK_Doing_NotificationId FOREIGN KEY(DoingId)
		REFERENCES Doings(Id);

ALTER TABLE NotificationAndState
ADD CONSTRAINT FK_Notification_StateId FOREIGN KEY(Notificationid)
        REFERENCES Notifications(Id),
	CONSTRAINT FK_State_NotificationId FOREIGN KEY(StateId)
		REFERENCES StatesOfNotification(Id);

ALTER TABLE NotificationAndUser
ADD CONSTRAINT FK_Notification_UserId FOREIGN KEY(Notificationid)
        REFERENCES Notifications(Id),
	CONSTRAINT FK_User_NotificationId FOREIGN KEY(UserId)
		REFERENCES Users(Id);

ALTER TABLE UserAndRole
ADD CONSTRAINT FK_User_RoleId FOREIGN KEY(UserId)
        REFERENCES Users(Id),
	CONSTRAINT FK_Role_UserId FOREIGN KEY(RoleId)
		REFERENCES Roles(Id);
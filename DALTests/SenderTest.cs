using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DALTests
{
	public class SenderTest
	{
        [Fact]
        public void Test1() //IsValidGetArchiveCodeByID1()
        {
            //Arrange
            var senderService = new SenderService();
            const string SenderName = "gfresf";

            //Act
            Sender sender = senderService.getSenderByID(1);
            bool isValid = true;
            if (SenderName != sender.SenderName)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Sender with ID=1 is not valid");
        }

        [Fact]
        public void Test2() //IsValidGetArchiveCodeByCode1()
        {
            //Arrange
            var senderService = new SenderService();
            const string Name = "gfdshgt";

            //Act
            Sender sender = senderService.getSenderByName(Name);
            bool isValid = true;
            if (Name != sender.SenderName)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Sender with Name=gfdshgt is not valid");
        }

        [Fact]
        public void Test3() //IsValidInsertArchiveCodeByCode()
        {
            //Arrange
            var senderService = new SenderService();
            const string Name = "novo";

            //Act
            Sender sender = new Sender(100, Name);
            senderService.InsertSender(sender);
            sender = senderService.getSenderByName(Name);
            bool isValid = true;
            if (Name != sender.SenderName)
                isValid = false;

            senderService.DeleteSenderByName(Name);
            //Assert
            Assert.True(isValid, "The Sender with Name=novo is not valid");
        }

        [Fact]
        public void Test4() //IsValidUpdateArchiveCodeByCode()
        {
            //Arrange
            var senderService = new SenderService();
            const string Name = "updated";

            //Act
            Sender sender = new Sender(100, "new");
            senderService.InsertSender(sender);
            sender = new Sender(100, Name);
            senderService.UpdateSenderByName("new", sender);
            sender = senderService.getSenderByName(Name);
            bool isValid = true;
            if (Name != sender.SenderName)
                isValid = false;

            senderService.DeleteSenderByName(Name);
            //Assert
            Assert.True(isValid, "The Sender with Name=new is not valid");
        }

        [Fact]
        public void Test5() //IsValidDeleteArchiveCodeByCode()
        {
            //Arrange
            var senderService = new SenderService();
            const string Name = "test9";

            //Act
            Sender sender = new Sender(100, Name);
            senderService.InsertSender(sender);
            senderService.DeleteSenderByName(Name);
            sender = null;
            sender = senderService.getSenderByName(Name);
            bool isValid = true;
            if (sender.SenderName != null)
                isValid = false;
            if (sender.SenderName == Name)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Sender with Name=test9 is not valid");
        }
    }
}

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
        public void Test1() 
        {
            //Arrange
            var senderService = new SenderService();
            const string SenderName = "gfresf";

            //Act
            Sender sender = senderService.GetSenderByID(1);
            bool isValid = true;
            if (SenderName != sender.SenderName)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Sender with ID=1 is not valid");
        }

        [Fact]
        public void Test2() 
        {
            //Arrange
            var senderService = new SenderService();
            const string Name = "gfdshgt";

            //Act
            Sender sender = senderService.GetSenderByName(Name);
            bool isValid = true;
            if (Name != sender.SenderName)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Sender with Name=gfdshgt is not valid");
        }

        [Fact]
        public void Test3() 
        {
            //Arrange
            var senderService = new SenderService();
            const string Name = "novo";

            //Act
            Sender sender = new Sender(100, Name);
            senderService.InsertSender(sender);
            sender = senderService.GetSenderByName(Name);
            bool isValid = true;
            if (Name != sender.SenderName)
                isValid = false;

            senderService.DeleteSenderByName(Name);
            //Assert
            Assert.True(isValid, "The Sender with Name=novo is not valid");
        }

        [Fact]
        public void Test4() 
        {
            //Arrange
            var senderService = new SenderService();
            const string Name = "updated";

            //Act
            Sender sender = new Sender(100, "new");
            senderService.InsertSender(sender);
            sender = new Sender(100, Name);
            senderService.UpdateSenderByName("new", sender);
            sender = senderService.GetSenderByName(Name);
            bool isValid = true;
            if (Name != sender.SenderName)
                isValid = false;

            senderService.DeleteSenderByName(Name);
            //Assert
            Assert.True(isValid, "The Sender with Name=new is not valid");
        }

        [Fact]
        public void Test5() 
        {
            //Arrange
            var senderService = new SenderService();
            const string Name = "test9";

            //Act
            Sender sender = new Sender(100, Name);
            senderService.InsertSender(sender);
            senderService.DeleteSenderByName(Name);
            sender = null;
            sender = senderService.GetSenderByName(Name);
            bool isValid = true;
            if (sender.SenderName != null)
                isValid = false;
            if (sender.SenderName == Name)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Sender with Name=test9 is not valid");
        }

        [Fact]
        public void Test6()
        {
            //Arrange
            var senderService = new SenderService();
            const string Name1 = "test9";
            const string Name2 = "test91";
            const string Name3 = "test92";
            List<Sender> senders = new List<Sender>();
            List<Sender> result = new List<Sender>();
            List<string> names = new List<string>();

            //Act
            Sender sender1 = new Sender(100, Name1);
            Sender sender2 = new Sender(101, Name2);
            Sender sender3 = new Sender(102, Name3);

            senders.Add(sender1);
            senders.Add(sender2);
            senders.Add(sender3);

            senderService.InsertSenders(senders);

            names.Add(Name1);
            names.Add(Name2);
            names.Add(Name3);

            result = senderService.GetSendersByNames(names);

            bool isValid = true;
            foreach (Sender sender in result)
            {
                if (!names.Contains(sender.SenderName))
                    isValid = false;
            }

            senderService.DeleteSendersByNames(names);

            //Assert
            Assert.True(isValid, "Not valid");
        }
    }
}

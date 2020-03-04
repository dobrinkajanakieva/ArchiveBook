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
        public void GetSenderByID() 
        {
            //Arrange
            var senderEngine = new SenderEngine();
            const string SenderName = "gfresf";

            //Act
            Sender sender = senderEngine.GetSenderByID(1);

            //Assert
            Assert.Equal(1, sender.ID_Sender);
            Assert.Equal(SenderName, sender.SenderName);
        }

        [Fact]
        public void GetSenderByName() 
        {
            //Arrange
            var senderEngine = new SenderEngine();
            const string SenderName = "gfdshgt";

            //Act
            Sender sender = senderEngine.GetSenderByName(SenderName);

            //Assert
            Assert.Equal(2, sender.ID_Sender);
            Assert.Equal(SenderName, sender.SenderName);
        }

        [Fact]
        public void InsertSender() 
        {
            //Arrange
            var senderEngine = new SenderEngine();
            const string SenderName = "novo";

            //Act
            Sender sender = new Sender(100, SenderName);
            senderEngine.InsertSender(sender);
            sender = senderEngine.GetSenderByName(SenderName);

            //Assert
            Assert.Equal(SenderName, sender.SenderName);
        }

        [Fact]
        public void UpdateSenderByName() 
        {
            //Arrange
            var senderEngine = new SenderEngine();
            const string SenderName = "updated";

            //Act
            Sender sender = new Sender(100, "new");
            senderEngine.InsertSender(sender);
            sender = new Sender(100, SenderName);
            senderEngine.UpdateSenderByName("new", sender);
            sender = senderEngine.GetSenderByName(SenderName);

            //Assert
            Assert.Equal(SenderName, sender.SenderName);
        }

        [Fact]
        public void DeleteSenderByName() 
        {
            //Arrange
            var senderEngine = new SenderEngine();

            //Act
            senderEngine.DeleteSenderByName("hyt");
            Sender sender = null;
            sender = senderEngine.GetSenderByName("hyt");

            //Assert
            Assert.Null(sender.SenderName);
        }

        [Fact]
        public void InsertSenders()
        {
            //Arrange
            var senderEngine = new SenderEngine();
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

            senderEngine.InsertSenders(senders);

            names.Add(Name1);
            names.Add(Name2);
            names.Add(Name3);

            result.Add(senderEngine.GetSenderByName(Name1));
            result.Add(senderEngine.GetSenderByName(Name2));
            result.Add(senderEngine.GetSenderByName(Name3));

            

            senderEngine.DeleteSendersByNames(names);

            //Assert
            foreach (Sender sender in result)
            {
                Assert.Contains(sender.SenderName, names);
            }
        }

        [Fact]
        public void DeleteSenders()
        {
            //Arrange
            var senderEngine = new SenderEngine();
            const string Name1 = "test9";
            const string Name2 = "test91";
            const string Name3 = "test92";
            List<Sender> result = new List<Sender>();
            List<string> names = new List<string>();

            //Act
            names.Add(Name1);
            names.Add(Name2);
            names.Add(Name3);

            result.Add(senderEngine.GetSenderByName(Name1));
            result.Add(senderEngine.GetSenderByName(Name2));
            result.Add(senderEngine.GetSenderByName(Name3));

            senderEngine.DeleteSendersByNames(names);

            //Assert
            foreach (Sender sender in result)
            {
                Assert.Null(sender.SenderName);
            }
        }
    }
}

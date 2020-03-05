using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
	public interface ISenderEngine
	{
		List<Sender> GetSenders();
		Sender GetSenderByID(int id);
		Sender GetSenderByName(string name);
		void InsertSender(Sender sender);
		void InsertSenders(List<Sender> senders);
		void DeleteSenderById(int id);
		void DeleteSenderByName(string name);
		void DeleteSendersByNames(List<string> names);
		void UpdateSenderById(int id, Sender sender);
		void UpdateSenderByName(string name, Sender sender);

	}
}

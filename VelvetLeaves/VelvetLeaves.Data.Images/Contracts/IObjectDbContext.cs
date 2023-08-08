using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelvetLeaves.Data.ObjectDatabase.Contracts
{
	public interface IObjectDbContext
	{
		public IMongoCollection<Image> Images { get; set; }
		public IMongoCollection<AppPreferences> AppPreferences { get; set; }
	}
}

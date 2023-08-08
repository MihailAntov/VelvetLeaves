using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelvetLeaves.Data.ObjectDatabase;
using VelvetLeaves.Data.ObjectDatabase.Contracts;

namespace VelvetLeaves.Services.UnitTests.HelperClasses
{
	public class ImageServiceTest : ImageService
	{
		
		public ImageServiceTest(IObjectDbContext context) : base(context)
		{
		}

		protected override Task<List<Image>> FindAsyncInCollection(string id)
		{
			if(id == null || id == "nonExistentId")
			{
				return Task.FromResult(new List<Image>());
			}
			
			return Task.FromResult( new List<Image> { new Image { Id = id, Content = "randomContent" } });
		}

		protected override Task<Image?> FindOneAndDeleteInCollection(string id)
		{
			Image? image;
			
			if(id == "imageId")
			{
				image = new Image { Id = id, Content = "RandomContent" };
			}
			else
			{
				image = null;
			}

			return Task.FromResult(image);
		}
	}
}

using System;
using System.Collections.Generic;

namespace UmbracoTest.Web.Models
{
	public class ImageGalleryViewModel
	{
		public IList<ImageCommentViewModel> Gallery {get; private set;}

		public ImageGalleryViewModel()
		{
			Gallery = new List<ImageCommentViewModel>();
		}
	}
}


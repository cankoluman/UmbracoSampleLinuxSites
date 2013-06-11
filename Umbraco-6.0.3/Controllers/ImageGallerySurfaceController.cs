using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using UmbracoTest.Web.Models;

namespace UmbracoTest.Web.Controllers
{
    public class ImageGallerySurfaceController : SurfaceController
    {
        [ChildActionOnly]
		public ActionResult ShowGallery()
		{
			var galleryModel = new ImageGalleryViewModel();

			var imageType = Services.ContentTypeService.GetMediaType("ImageWithComment");
			var photos = Services
						.MediaService
						.GetMediaOfMediaType(imageType.Id)
						.Where(p => p.Trashed == false)
						.ToList();

			foreach (var photo in photos)
			{
				galleryModel
					.Gallery
					.Add(new ImageCommentViewModel()
				    {
							ImageComment = photo.GetValue<string>("comments"),
							ImageUrl = Umbraco.TypedMedia(photo.Id).Url
					});
			}

			return PartialView("ImageGallery", galleryModel);
        }
    }
}

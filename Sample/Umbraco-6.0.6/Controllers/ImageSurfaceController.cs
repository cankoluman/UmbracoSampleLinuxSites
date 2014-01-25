using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoTest.Web.Models;

namespace UmbracoTest.Web.Controllers
{
    public class ImageSurfaceController : SurfaceController
    {
		[HttpPost]
		public ActionResult UploadImage(ImageCommentViewModel image, IEnumerable<HttpPostedFileBase> mediaFiles)
        {
			var mediaFile =  mediaFiles.FirstOrDefault();
			if (mediaFile != null && mediaFile.ContentLength > 0) 
			{
				var fileName = Path.GetFileName(mediaFile.FileName);

				var media = Services.MediaService.CreateMedia(fileName, -1, "ImageWithComment");
				media.SetValue("umbracoFile", mediaFile);
				media.SetValue("comments", image.ImageComment);

				Services.MediaService.Save(media);
			}

			return Redirect("/");
        }

		[HttpGet]
		public ActionResult RenderForm()
		{
			var imageViewModel = new ImageCommentViewModel();
			return PartialView("Forms/ImageUploadForm", imageViewModel);
		}
    }
}

// This file has been autogenerated from a class added in the UI designer.

using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Sample
{
	public partial class NavigationController : UINavigationController
	{
		public NavigationController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes() {
				Font = UIFont.BoldSystemFontOfSize(18f),
				TextColor = UIColor.White
			});

			this.NavigationBar.SetBackgroundImage(CreateImageWithColor(UIColor.Clear), UIBarMetrics.Default);
			this.NavigationBar.ShadowImage = CreateImageWithColor(UIColor.Clear);
			this.NavigationBar.TintColor = UIColor.White;
			this.NavigationBar.Translucent = true;

		}

		private UIImage CreateImageWithColor(UIColor color)
		{
			var rect = new CGRect(0f, 0f, 1f, 1f);
			UIGraphics.BeginImageContext(rect.Size);
			var context = UIGraphics.GetCurrentContext();
			context.SetFillColor(color.CGColor);
			context.FillRect(rect);
			var image = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();
			return image;
		}
	}
}

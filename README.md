# CustomPageSegmentedControl

Awesome way of representing the customer header.

This is an Obj-C binding project based on https://github.com/AugustRush/ARSegmentPager.

###Usage

public partial class ViewController : UIViewController, IARSegmentControllerDelegate
{
	UIImage defaultImage;
	UIImage blurImage;
	ARSegmentPageController pager;

	public string SegmentTitle {
		get {
			return "Sample";
		}
	}

	protected ViewController(IntPtr handle) : base(handle)
	{
	}

	public override void ViewDidLoad()
	{
		base.ViewDidLoad();

		this.defaultImage = UIImage.FromFile("background.jpg");
		this.blurImage = UIImage.FromFile("background.jpg");

		BtnClickMe.TouchUpInside += (sender, e) => {
			if (pager != null) {
				pager.RemoveObserver(this, new NSString("segmentTopInset"));
				pager = null;
			}

			var arPager = new ARSegmentPageController();
			var c = UIStoryboard.FromName("Main", null).InstantiateViewController("TableViewController") as TableViewController;
			arPager.SetViewControllers(new NSObject[] { c });
			arPager.SegmentMiniTopInset = 64f;
			arPager.HeaderHeight = 200f;
			arPager.SegmentHeight = 0f;
			arPager.FreezenHeaderWhenReachMaxHeaderHeight = true;
			this.pager = arPager;
			this.pager.AddObserver(this, new NSString("segmentTopInset"), NSKeyValueObservingOptions.New, IntPtr.Zero);
			this.NavigationController.PushViewController(this.pager, true);
		};
	}

	public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
	{
		var topInset = ((NSNumber)change.ValueForKey(ChangeNewKey)).NFloatValue;
		var imageView = this.pager.HeaderView.ImageView;
		if (topInset <= this.pager.SegmentMiniTopInset) {
			this.pager.Title = "Page Title";
			imageView.Image = this.blurImage;
		} else {
			this.pager.Title = string.Empty;
			imageView.Image = this.defaultImage;
		}
	}
}
```


###Output

![](https://github.com/guntidheerajkumar/CustomPageSegmentedControl/blob/master/CustomPageSegmentedControlOutput.gif)

using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace CustomPageSegmentedControl
{
	// @protocol ARSegmentControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ARSegmentControllerDelegate
	{
		// @required -(NSString *)segmentTitle;
		[Abstract]
		[Export("segmentTitle")]
		string SegmentTitle { get; }

		// @optional -(id)streachScrollView;
		[Export("streachScrollView")]
		NSObject StreachScrollView { get; }
	}

	// @protocol ARSegmentPageControllerHeaderProtocol <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ARSegmentPageControllerHeaderProtocol
	{
		// @required @property (nonatomic) UIImageView * imageView;
		[Abstract]
		[Export("imageView", ArgumentSemantic.Assign)]
		UIImageView ImageView { get; set; }
	}

	// @interface ARSegmentPageHeader : UIView <ARSegmentPageControllerHeaderProtocol>
	[BaseType(typeof(UIView))]
	interface ARSegmentPageHeader : ARSegmentPageControllerHeaderProtocol
	{
		// @property (nonatomic, strong) UIImageView * imageView;
		[Export("imageView", ArgumentSemantic.Strong)]
		UIImageView ImageView { get; set; }
	}

	// @interface ARSegmentPageController : UIViewController
	[BaseType(typeof(UIViewController))]
	interface ARSegmentPageController
	{
		// @property (assign, nonatomic) CGFloat segmentHeight;
		[Export("segmentHeight")]
		nfloat SegmentHeight { get; set; }

		// @property (assign, nonatomic) CGFloat headerHeight;
		[Export("headerHeight")]
		nfloat HeaderHeight { get; set; }

		// @property (assign, nonatomic) CGFloat segmentMiniTopInset;
		[Export("segmentMiniTopInset")]
		nfloat SegmentMiniTopInset { get; set; }

		// @property (readonly, assign, nonatomic) CGFloat segmentToInset;
		[Export("segmentToInset")]
		nfloat SegmentToInset { get; }

		// @property (readonly, nonatomic, weak) UIViewController<ARSegmentControllerDelegate> * currentDisplayController;
		[Export("currentDisplayController", ArgumentSemantic.Weak)]
		ARSegmentControllerDelegate CurrentDisplayController { get; }

		// @property (readonly, nonatomic, strong) UIView<ARSegmentPageControllerHeaderProtocol> * headerView;
		[Export("headerView", ArgumentSemantic.Strong)]
		ARSegmentPageHeader HeaderView { get; }

		// @property (assign, nonatomic) BOOL freezenHeaderWhenReachMaxHeaderHeight;
		[Export("freezenHeaderWhenReachMaxHeaderHeight")]
		bool FreezenHeaderWhenReachMaxHeaderHeight { get; set; }

		// -(instancetype)initWithControllers:(UIViewController<ARSegmentControllerDelegate> *)controller, ... __attribute__((sentinel(0, 1)));
		[Internal]
		[Export("initWithControllers:", IsVariadic = true)]
		IntPtr Constructor(ARSegmentControllerDelegate controller, IntPtr varArgs);

		// -(void)setViewControllers:(NSArray *)viewControllers;
		[Export("setViewControllers:")]
		void SetViewControllers(NSObject[] viewControllers);

		// -(UIView<ARSegmentPageControllerHeaderProtocol> *)customHeaderView;
		[Export("customHeaderView")]
		ARSegmentPageControllerHeaderProtocol CustomHeaderView { get; }
	}

	// @interface ARSegmentView : UIToolbar
	[BaseType(typeof(UIToolbar))]
	interface ARSegmentView
	{
		// @property (readonly, nonatomic, strong) UISegmentedControl * segmentControl;
		[Export("segmentControl", ArgumentSemantic.Strong)]
		UISegmentedControl SegmentControl { get; }
	}
}

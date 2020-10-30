using System;
using System.IO;
using Foundation;
using UIKit;

namespace XamariniOSImageStore
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		string fileName;
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		int Count = 0;
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		partial void UIButton8_TouchUpInside(UIButton sender)
		{
			StoreImage("Xamarin.jpg");
		}

		public void StoreImage(string filename)
		{
			if (File.Exists(fileName))
			{
				Count++;
				string filenames = "image" + Count.ToString() + ".jpg";
				fileName = Path.Combine(folderPath, filenames);
			}
			else
			{
				fileName = Path.Combine(folderPath, "image.jpg");
			}
			var img = UIImage.FromFile(filename);
			NSData image = img.AsJPEG();
			NSError err = null;
			image.Save(fileName, false, out err);
			lblPath.Text = "File Path:" + fileName;
			imgProfile.Image = UIImage.FromFile(fileName);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

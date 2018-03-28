package md5ee0b2984d4379a09c746892b6c51e139;


public class MainMenuView
	extends md52af954b89e412540bc9b68f2eb771b47.MvxActivity_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("FirstMvvMAsignment.Droid.Views.MainMenuView, FirstMvvMAsignment.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainMenuView.class, __md_methods);
	}


	public MainMenuView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainMenuView.class)
			mono.android.TypeManager.Activate ("FirstMvvMAsignment.Droid.Views.MainMenuView, FirstMvvMAsignment.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

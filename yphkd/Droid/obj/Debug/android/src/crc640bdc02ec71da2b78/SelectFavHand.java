package crc640bdc02ec71da2b78;


public class SelectFavHand
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("yphkd.Droid.Classes.Login.Activites.SelectFavHand, yphkd.Droid", SelectFavHand.class, __md_methods);
	}


	public SelectFavHand ()
	{
		super ();
		if (getClass () == SelectFavHand.class)
			mono.android.TypeManager.Activate ("yphkd.Droid.Classes.Login.Activites.SelectFavHand, yphkd.Droid", "", this, new java.lang.Object[] {  });
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

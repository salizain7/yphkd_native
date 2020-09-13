package crc640bdc02ec71da2b78;


public class SplashActivity
	extends crc64f9f4a990206954a4.BaseActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onResume:()V:GetOnResumeHandler\n" +
			"";
		mono.android.Runtime.register ("yphkd.Droid.Classes.Login.Activites.SplashActivity, yphkd.Droid", SplashActivity.class, __md_methods);
	}


	public SplashActivity ()
	{
		super ();
		if (getClass () == SplashActivity.class)
			mono.android.TypeManager.Activate ("yphkd.Droid.Classes.Login.Activites.SplashActivity, yphkd.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();

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

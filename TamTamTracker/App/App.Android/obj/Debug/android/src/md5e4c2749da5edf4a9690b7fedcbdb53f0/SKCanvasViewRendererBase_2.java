package md5e4c2749da5edf4a9690b7fedcbdb53f0;


public abstract class SKCanvasViewRendererBase_2
	extends md51558244f76c53b6aeda52c8a337f2c37.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SkiaSharp.Views.Forms.SKCanvasViewRendererBase`2, SkiaSharp.Views.Forms", SKCanvasViewRendererBase_2.class, __md_methods);
	}


	public SKCanvasViewRendererBase_2 (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SKCanvasViewRendererBase_2.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Forms.SKCanvasViewRendererBase`2, SkiaSharp.Views.Forms", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SKCanvasViewRendererBase_2 (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SKCanvasViewRendererBase_2.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Forms.SKCanvasViewRendererBase`2, SkiaSharp.Views.Forms", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SKCanvasViewRendererBase_2 (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SKCanvasViewRendererBase_2.class)
			mono.android.TypeManager.Activate ("SkiaSharp.Views.Forms.SKCanvasViewRendererBase`2, SkiaSharp.Views.Forms", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}

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

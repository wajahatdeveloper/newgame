using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPanel : Singleton<LoadingPanel>
{
	public void Show()
	{
		transform.GetChild( 0 ).gameObject.SetActive( true );
	}

	public void Hide()
	{
		transform.GetChild( 0 ).gameObject.SetActive( false );
	}
}
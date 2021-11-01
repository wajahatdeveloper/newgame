using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncSprite : MonoBehaviour
{
	public Image image;
	public SpriteRenderer spriteRenderer;
	public float updateRate;

	private void OnEnable()
	{
		StartCoroutine( Sync() );
	}

	public IEnumerator Sync()
	{
		while (true)
		{
			image.sprite = spriteRenderer.sprite;
			yield return new WaitForSeconds( updateRate );
		}
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}
}
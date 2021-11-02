using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroSkin : MonoBehaviour
{
	public List<Sprite> icons = new List<Sprite>();
	public List<RuntimeAnimatorController> animators = new List<RuntimeAnimatorController>();

	public List<Animator> externalAnimators = new List<Animator>();

	public UnityEvent onAnimatorChange;

	private int heroId;

	private void OnEnable()
	{
		int heroId = PlayerPrefs.GetInt( "Hero", 1 );

		GetComponent<SpriteRenderer>().sprite = icons[heroId];
		GetComponent<Animator>().runtimeAnimatorController = animators[heroId];

		onAnimatorChange.Invoke();

		foreach (Animator animator in externalAnimators)
		{
			animator.runtimeAnimatorController = animators[heroId];
		}
	}
}
using UnityEngine;

[CreateAssetMenu( fileName = "NFTData", menuName = "ScriptableObjects/NFTData", order = 1 )]
public class NFTData : ScriptableObject
{
	public string Id;
	public string Name;
	public string Description;
	public Sprite Icon;
	public bool isFirstEdition;
}
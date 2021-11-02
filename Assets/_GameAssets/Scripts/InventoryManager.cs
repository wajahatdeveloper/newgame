using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineX;

public class InventoryManager : MonoBehaviour
{
	private const string weaponItemKey = "weaponItem";
	private const string trinketItemKey = "trinketItem";
	private const string armorItemKey = "armorItem";
	public List<GameObject> itemsWeapons = new List<GameObject>();
	public List<GameObject> itemsTrinkets = new List<GameObject>();
	public List<GameObject> itemsArmors = new List<GameObject>();

	private void OnEnable()
	{
		OnClick_ItemWeapon ( itemsWeapons	.First(x=>x.name==PlayerPrefs.GetString( weaponItemKey,  "Item_Staff")).GetComponent<ButtonX>());
		OnClick_ItemTrinket( itemsTrinkets	.First(x=>x.name==PlayerPrefs.GetString( trinketItemKey, "Item_DoubleXP")).GetComponent<ButtonX>());
		OnClick_ItemArmor  ( itemsArmors	.First(x=>x.name==PlayerPrefs.GetString( armorItemKey,   "Item_Boots")).GetComponent<ButtonX>());
	}

	public void OnClick_ItemWeapon( ButtonX item )
	{
		itemsWeapons.ForEach( item => DeselectItem(item) );
		SelectItem( item.gameObject );
		PlayerPrefs.SetString( weaponItemKey, item.name);
	}

	public void OnClick_ItemTrinket( ButtonX item )
	{
		itemsTrinkets.ForEach( item => DeselectItem( item ) );
		SelectItem( item.gameObject );
		PlayerPrefs.SetString( trinketItemKey, item.name);
	}

	public void OnClick_ItemArmor( ButtonX item )
	{
		itemsArmors.ForEach( item => DeselectItem( item ) );
		SelectItem( item.gameObject );
		PlayerPrefs.SetString( armorItemKey, item.name);
	}

	public void SelectItem(GameObject item)
	{
		item.GetComponent<Image>().color = Color.green;
	}

	public void DeselectItem(GameObject item)
	{
		item.GetComponent<Image>().color = Color.white;
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameplayModel;

public class CharacterSelectionController : MonoBehaviour
{
	public GameObject prefabCharButton;
	public Transform content;
	public Button selectButton;

	public List<NFTData> NFTDatas = new List<NFTData>();

	private void OnEnable()
	{
		selectButton.enabled = false;
		_PopulateCharList();
	}

	private void _PopulateCharList()
	{
		// Get Current Player's NFT's from API and Populate in List
		StartCoroutine( GetPlayerNFTs( "crystalkingdoms.io/api/heroes/users/0xABCDXYZ" ) );
	}

	IEnumerator GetPlayerNFTs( string uri )
	{
		Debug.Log( "Calling GetPlayerNFTs" );
		LoadingPanel.Instance.Show();
		using (UnityWebRequest webRequest = UnityWebRequest.Get( uri ))
		{
			// Request and wait for the desired page.
			yield return webRequest.SendWebRequest();

			string[] pages = uri.Split( '/' );
			int page = pages.Length - 1;

			switch (webRequest.result)
			{
				case UnityWebRequest.Result.ConnectionError:
				case UnityWebRequest.Result.DataProcessingError:
					Debug.LogError( pages[page] + ": Error: " + webRequest.error );
					LoadingPanel.Instance.Hide();
					break;
				case UnityWebRequest.Result.ProtocolError:
					Debug.LogError( pages[page] + ": HTTP Error: " + webRequest.error );
					LoadingPanel.Instance.Hide();
					break;
				case UnityWebRequest.Result.Success:
					Debug.Log( pages[page] + ":\nReceived: " + webRequest.downloadHandler.text );
					var playerNFTs = JsonUtility.FromJson<GetPlayerNFTs>( webRequest.downloadHandler.text );

					foreach ( var playerNFT in playerNFTs.heroes )
					{
						if (ReadTimestamp(playerNFT + "used"))
						{
							if ((DateTime.Now - expiryTime).Hours > 24)
							{
								AddSelectable( playerNFT );
							}
						}
						else
						{
							// First time
							AddSelectable( playerNFT );
						}
					}

					// Only Allow further if at least one nft in list
					selectButton.interactable = playerNFTs.heroes.Count > 0;
					LoadingPanel.Instance.Hide();
					break;
			}
		}
	}

	private void AddSelectable( string playerNFT )
	{
		// add as selectable
		var nftData = NFTDatas.Where( x => x.Id == playerNFT ).First();
		if (nftData == null) { return; }
		var charItem = Instantiate( prefabCharButton, content );
		charItem.GetComponentInChildren<Image>().sprite = nftData.Icon;
		charItem.GetComponentInChildren<Text>().text = nftData.name;
		charItem.GetComponent<Button>().onClick.AddListener( () => { OnClick_Select( nftData.Id ); } );
	}

	public void OnClick_Select(string id)
	{
		currentNftCharId = id;
		GameplayModel.currentNftChar = NFTDatas.Where( x => x.Id == id ).First();

		ScheduleTimer( id );

		_NextScene();
	}

	private void _NextScene()
	{
		SceneManager.LoadScene( 2 );
	}


	#region TimeStamp
	DateTime expiryTime;

	void ScheduleTimer(string id)
	{
		expiryTime = DateTime.Now.AddDays( 1.0 );
		WriteTimestamp( id+ "used" );
	}

	private bool ReadTimestamp( string key )
	{
		long tmp = Convert.ToInt64( PlayerPrefs.GetString( key, "0" ) );
		if (tmp == 0)
		{
			return false;
		}
		expiryTime = DateTime.FromBinary( tmp );
		return true;
	}

	private void WriteTimestamp( string key )
	{
		PlayerPrefs.SetString( key, expiryTime.ToBinary().ToString() );
	}
	#endregion
}
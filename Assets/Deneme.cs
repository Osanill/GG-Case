using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Deneme : MonoBehaviour
{
    public GameObject[] skins;
	public GameObject[] skins1;
	public Sprite[] sprites;
	private int a = 9;
	private int temp = 10;
	private int clickNo = 0;
	
	
	public void OnClick()
    {
		if(clickNo < 9)
		{
			StartCoroutine(MyFunction(0.2f));		
		}else
		{
			SceneManager.LoadScene("Home");
		}
		clickNo += 1; 
	}

	private IEnumerator MyFunction(float delayTime)
	{
		int randomIndex;
		int randomIndexSprite;
		
		for(int i = 0; i < a + 1; i++)
		{
			if(a == 1)
			{
				for(int j = 0; j < 9; j++)
				{
					//skins1[j].GetComponent<Image>().color =  new Color(128f/255f, 128f/255f, 128f/255f);
					if(skins1[j].GetComponent<Image>().color == Color.green)
					{
						skins1[j].GetComponent<Image>().color = new Color(233f/255f, 232f/255f, 232f/255f);
					}
				}
				ChangeColorToGreen(0);
				skins[0].transform.GetChild(1).GetComponent<Image>().sprite = sprites[0];
				a = a - 1;
				break;
			}

			randomIndex = Random.Range(0, a);
			randomIndexSprite = Random.Range(0, a);
			
			while(randomIndex == temp)
			{
				randomIndex = Random.Range(0, a);
			}

			temp = randomIndex;

			if(i == a)
			{	
				for(int j = 0; j < 9; j++)
				{
					if(skins1[j].GetComponent<Image>().color == Color.green)
					{
						skins1[j].GetComponent<Image>().color = new Color(233f/255f, 232f/255f, 232f/255f);
					}
				}

				ChangeColorToGreen(randomIndex);
				skins[randomIndex].transform.GetChild(1).GetComponent<Image>().sprite = sprites[randomIndexSprite]; 	
				
				// Below Lines remove selected skin and sprite from the arrays.
				List<GameObject> tmpSkin = new List<GameObject>(skins);
				tmpSkin.RemoveAt(randomIndex);
				skins = tmpSkin.ToArray();

				List<Sprite> tmpSprite = new List<Sprite>(sprites);
				tmpSprite.RemoveAt(randomIndexSprite);
				sprites = tmpSprite.ToArray();
				break;
			} 
			
			ChangeColorToGreen(randomIndex);
			yield return new WaitForSeconds(delayTime);
			ChangeColorToDefault(randomIndex);
				
		}
		
		a = a - 1;
	}


	private void ChangeColorToDefault(int randomIndex)
	{
		skins[randomIndex].GetComponent<Image>().color =  new Color(128f/255f, 128f/255f, 128f/255f);
	}
	
	private void ChangeColorToGreen(int randomIndex)
	{
		skins[randomIndex].GetComponent<Image>().color = Color.green;
	}
}

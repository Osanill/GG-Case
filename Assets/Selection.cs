using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Selection : MonoBehaviour
{

	public Image[] images;
	public Sprite[] sprites;
	int a = 9;
	public void Select()
	{		
		Invoke("Change", 0.5f);	
	}

	void Change()
	{
		if(a == 0)
		{
			GameObject.Find("GameManager").GetComponent<GameManager>().EndGame();
			return;
		}

		Debug.Log("Select Function");
		int randomIndexImage = Random.Range(0, a);
		int randomIndexSprite = Random.Range(0, a);
		

		images[randomIndexImage].sprite = sprites[randomIndexSprite];
		
		
		List<Image> tmpImage = new List<Image>(images);
		tmpImage.RemoveAt(randomIndexImage);
		images = tmpImage.ToArray();

		List<Sprite> tmpSprite = new List<Sprite>(sprites);
		tmpSprite.RemoveAt(randomIndexSprite);
		sprites = tmpSprite.ToArray();
	
		a = a - 1;
	}
}

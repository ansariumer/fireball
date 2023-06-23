// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Trajectory : MonoBehaviour
// {
//     [SerializeField]
//     int dotsNumber;
//     [SerializeField]
//     GameObject dotsParent;
//     [SerializeField]
//     GameObject dotPrefab;
//     [SerializeField]
//     float dotSpacing;

//     Transform[] dotsList;

//     Vector2 pos;
//     // dot pos 
//     float timeStamp;

//     // ----------------------------------------
//     void Start()
//     {
//         // hide trajectory in the start'
//         Hide ();
//         // prepare dots 
//         PrepareDots ();
//     }

//     void PrepareDots ()
//     {
//         dotsList = new Transform[dotsNumber];
        
//         for (int i = 0; i < dotsNumber; i++)
//         {
//             dotsList [i] = Instantiate (dotPrefab, null).transform;
//             dotsList [i].parent = dotsParent.transform; 
//         }
//     }

//     public void UpadateDots (Vector3 playerPos, Vector2 forceApplied)
//     {
//         timeStamp = dotSpacing;
//         for (int i = 0; i < dotsNumber; i++)
//         {
//             pos.x = (playerPos.x + forceApplied.x * timeStamp);
//             pos.y = (playerPos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2f;

//             dotsList [i].position = pos;
//             timeStamp += dotSpacing;
//             timeStamp += dotSpacing;
//         }
//     }
// }
﻿
using UnityEngine;

public class Trajectory : MonoBehaviour
{
	[SerializeField] int dotsNumber;
	[SerializeField] GameObject dotsParent;
	[SerializeField] GameObject dotPrefab;
	[SerializeField] float dotSpacing;
	[SerializeField] [Range (0.01f, 0.3f)] float dotMinScale;
	[SerializeField] [Range (0.3f, 1f)] float dotMaxScale;

	Transform[] dotsList;

	Vector2 pos;
	//dot pos
	float timeStamp;

	//--------------------------------
	void Start ()
	{
		//hide trajectory in the start
		Hide ();
		//prepare dots
		PrepareDots ();
	}

	void PrepareDots ()
	{
		dotsList = new Transform[dotsNumber];
		dotPrefab.transform.localScale = Vector3.one * dotMaxScale;

		float scale = dotMaxScale;
		float scaleFactor = scale / dotsNumber;

		for (int i = 0; i < dotsNumber; i++) {
			dotsList [i] = Instantiate (dotPrefab, null).transform;
			dotsList [i].parent = dotsParent.transform;

			dotsList [i].localScale = Vector3.one * scale;
			if (scale > dotMinScale)
				scale -= scaleFactor;
		}
	}

	public void UpdateDots (Vector3 playerPos, Vector2 forceApplied)
	{
		timeStamp = dotSpacing;
		for (int i = 0; i < dotsNumber; i++) {
			pos.x = (playerPos.x + forceApplied.x * timeStamp);
			pos.y = (playerPos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2f;
		
			//you can simlify this 2 lines at the top by:
//pos = (playerPos+force*time)-((-Physics2D.gravity*time*time)/2f);
//
//but make sure to turn "pos" in player.cs to Vector2 instead of Vector3	
			
			dotsList [i].position = pos;
			timeStamp += dotSpacing;
		}
	}

	public void Show ()
	{
		dotsParent.SetActive (true);
	}

	public void Hide ()
	{
		dotsParent.SetActive (false);
	}
}

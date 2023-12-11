using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FairyController : MonoBehaviour
{
	[SerializeField] private NavMeshAgent fairy;
	[SerializeField] private Transform end;
	[SerializeField] private GameObject lightPrefab;
	[SerializeField] private float spawnBetween;

	private bool spawning = false;

    // Start is called before the first frame update
    void Start()
    {
		spawning = true;
		fairy.SetDestination(end.position);
		InvokeRepeating("SpawnLight", 1, spawnBetween);
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Finish")
		{
			SpawnLight();
			spawning = false;
		}
		Debug.Log(other.gameObject.tag);
	}


	private void SpawnLight()
	{
		if(spawning)
		{
			Instantiate(lightPrefab, fairy.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
		}
		else
		{
			CancelInvoke("SpawnLight");
		}
	}

}

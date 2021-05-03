using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
	public GameObject waterTeste;
	Vector3 nextSpawnPoint;

	public void SpawnTile()
	{
		GameObject temp = Instantiate(waterTeste, nextSpawnPoint, Quaternion.identity);
		nextSpawnPoint = temp.transform.GetChild(1).transform.position;

	}
    // Start is called before the first frame update
    private void Start()
    {
        for(int i=0; i< 15; i++){
        	SpawnTile();
        }
    }
}

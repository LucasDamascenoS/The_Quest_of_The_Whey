using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
	[SerializeField] GameObject groundTeste;
	Vector3 nextSpawnPoint;

	public void SpawnTile (bool spawnItems)
	{
		GameObject temp = Instantiate(groundTeste, nextSpawnPoint, Quaternion.identity);
		nextSpawnPoint = temp.transform.GetChild(1).transform.position;


		// Dessa forma, temos mais controle sobre a chamada de SpawnObstacle(); e SpawnWheys() no GroundText
		if (spawnItems)
		{
			temp.GetComponent<GroundTeste>().SpawnObstacle();
			temp.GetComponent<GroundTeste>().SpawnWheys();
		}
	}
    // Start is called before the first frame update
    private void Start()
    {
        for(int i=0; i< 30; i++){
			// Assegurar que no primeiro tile não aparecerá obstaculos ou wheys(melhoria na jogabilidade)
			if(i<1){
				SpawnTile(false);
			} else{
				SpawnTile(true);
			}
        	
        }
    }
}

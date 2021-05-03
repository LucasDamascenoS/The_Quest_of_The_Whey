using UnityEngine;

public class GroundTeste : MonoBehaviour
{
	GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject wheyProteinPrefab;

    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] float tallObstacleChance = 0.2f; // Probabilidade do obstaculo alto ser gerado

    // Start is called before the first frame update
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        
        // Referencia feita no GroundSpawner.cs
        // SpawnObstacle();
        // SpawnWheys();
    }

    private void OnTriggerExit (Collider other){
    	groundSpawner.SpawnTile(true);
    	Destroy(gameObject, 2);
    }

    public void SpawnObstacle ()
    {
        // Choose wich obstacle to spawn, the normal or the tall
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if (random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab; //Podemos expoandir para mais tipos de obstáculos adicionando novas condições
        }



        // Chose a random point to spawn the object
        int obstacleSpawnIndex = Random.Range(2,5); // esses numeros se referen a ordem no prefab do GroundTest em que os abstaculos são lsitados
                                                    // atualmente, ainda há a cerca
                                                    // Esse último .transform apenas retorna o componente Transform dos tres tipos de obstáculos: da esquerda, do centro e da direita
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the osbtacle at the position
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }

    // To spawn the whey protein fab
    public void SpawnWheys ()
    {
        int wheyToSpawn = 10;
        for (int i = 0; i < wheyToSpawn; i++){
            // transform indica que o whey será um gameObject pai do ground tile, logo, quando o groun tile for destruido, os wheys também o serão
            GameObject temp = Instantiate(wheyProteinPrefab, transform);

            // Set the position of whey that we just spawned equal to a random point in the ground tile collider
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>()); // Acessar position do transform do whey
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        // Vai gerar um novo whey dentro do collider do ground tile, em um ponto randomico dos eixos, em o min e o max de cada eixo
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );


        // Checa se o ponto randomico que foi escolhido está dentro do collider do graound tile
        if (point != collider.ClosestPoint(point)) {
            // Se o ponto não estiver no collider, um novo ponto é gerado dentro dele
            point = GetRandomPointInCollider(collider);
        }

        // Feito para garantir que o whey sempre será gerado na mesma altura
        point.y = 1;
        return point;
    }
}

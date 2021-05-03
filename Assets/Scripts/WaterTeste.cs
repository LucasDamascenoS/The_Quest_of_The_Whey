using UnityEngine;

public class WaterTeste : MonoBehaviour
{
	WaterSpawner waterSpawner;
    // Start is called before the first frame update
    private void Start()
    {
        waterSpawner = GameObject.FindObjectOfType<WaterSpawner>();
    }

    private void OnTriggerExit (Collider other){
    	waterSpawner.SpawnTile();
    	Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

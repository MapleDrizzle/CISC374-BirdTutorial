using System.Threading;
using UnityEngine;

public class Spawn_Controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Pipes;
    public float spawnRate = 2;
    public float timer = 0;
    public float heightOffSet = 10;
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate) {
            timer = timer + Time.deltaTime;
        }
        else {
            spawnPipe();
            timer = 0;
        }
    }
    void spawnPipe() {
        float lowestPoint = transform.position.y - heightOffSet;
        float highestPoint = transform.position.y + heightOffSet;
        Instantiate(Pipes, new UnityEngine.Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}

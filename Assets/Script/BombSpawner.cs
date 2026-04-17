using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] float spawnTime = 5;
    [SerializeField] float spawnRate = 3;
    private float timer = 0;

    float topPoint = 2.2f;
    float bottomPoint = -2.2f;
    float leftPoint = -5.3f;
    float rightPoint = 5.3f;


    void Update()
    {
        if (timer < spawnTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            //-----------REMOVE BOMB--------------------------------------------------
            GameObject[] allBombs = GameObject.FindGameObjectsWithTag("Bomb");
            foreach(GameObject obj in allBombs)
            {
                Destroy(obj);
            }
            //------------SPAWN BOMB--------------------------------------------------
            for (int i = 0; i < spawnRate; ++i)
            {
                Debug.Log("created");
                Instantiate(bomb, new Vector3(Random.Range(leftPoint,rightPoint), Random.Range(topPoint,bottomPoint), 0), transform.rotation);
            }
            timer = 0;
        }
    }
}

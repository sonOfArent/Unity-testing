using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject player;
    public static GameObject[] enemies;

    public float enemySpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        print("Enemies converging on " + player.transform.position);

        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject currentEnemy = enemies[i];

            currentEnemy.transform.LookAt(player.transform.position);
            CharacterController controller = currentEnemy.GetComponent<CharacterController>();

            controller.Move((player.transform.position - currentEnemy.transform.position) * enemySpeed * Time.deltaTime);

        }
    }
}

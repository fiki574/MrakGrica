using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform FirstFloor, SecondFloor, ThirdFloor;

    public void CreateZombie(int amount, int floor, int level)
    {
        if (level == 1 && floor == 1)
            for (int i = 0; i < amount; i++)
                Instantiate(enemy, FirstFloor.position, FirstFloor.rotation);
    }
}

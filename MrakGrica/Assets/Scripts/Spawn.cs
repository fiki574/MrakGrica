using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform FirstFloor, SecondFloor, ThirdFloor, GroundFloor, FirstFloor2, SecondFloor2, GroundFloor2,
        First, Second,
        MinusFirst, MinusSecond, MinusThird;

    public void CreateZombie(int amount, int floor, int level)
    {
        if (level == 1 && floor == -1)
            for (int i = 0; i < amount; i++)
                Instantiate(enemy, FirstFloor2.position, FirstFloor2.rotation);

        if (level == 1 && floor == -2)
            for (int i = 0; i < amount; i++)
                Instantiate(enemy, SecondFloor2.position, SecondFloor2.rotation);

        if (level == 1 && floor == -3)
            for (int i = 0; i < amount; i++)
                Instantiate(enemy, GroundFloor2.position, GroundFloor2.rotation);

        if (level == 1 && floor == 0)
            for (int i = 0; i < amount; i++)
                Instantiate(enemy, GroundFloor.position, GroundFloor.rotation);

        if (level == 1 && floor == 1)
            for (int i = 0; i < amount; i++)
                Instantiate(enemy, FirstFloor.position, FirstFloor.rotation);

        if (level == 1 && floor == 2)
            for (int i = 0; i < amount; i++)
                Instantiate(enemy, SecondFloor.position, SecondFloor.rotation);

        if (level == 1 && floor == 3)
            for (int i = 0; i < amount; i++)
                Instantiate(enemy, ThirdFloor.position, ThirdFloor.rotation);

        if (level == 2 && floor == 0)
        {
            Instantiate(enemy, First.position, First.rotation);
            Instantiate(enemy, Second.position, Second.rotation);
        }

        if (level == 3 && floor == -1)
            Instantiate(enemy, MinusFirst.position, MinusFirst.rotation);            

        if (level == 3 && floor == -2)
            Instantiate(enemy, MinusSecond.position, MinusSecond.rotation);

        if (level == 3 && floor == -3)
            Instantiate(enemy, MinusThird.position, MinusThird.rotation);
    }

    private void Awake()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Equals("Level2"))
        {
            CreateZombie(2, 0, 2);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameRun : MonoBehaviour
{

    public GameObject enemyPrefab;
    public static int count = 0;
    public TMP_Text a;

    private string control;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (count <= 9)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-144, 144), Random.Range(-90, 90), 0);
            Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
            count++;
        }

        if (Input.GetKey(KeyCode.Q))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        if (HeroMovement.controlToggle == true)
        {
            control = "Key";
        } else
        {
            control = "Mouse";
        }

        a.SetText("HERO: Drive(" + control + ") TouchedEnemy(" + EnemyUpdate.touchedCount + ") EGG: OnScreen(" + HeroShoot.eggCount + ") ENEMY: Count(" + count + ") Destroyed(" + EnemyUpdate.destroyedCount + ")");
    }
}

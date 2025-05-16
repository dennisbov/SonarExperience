using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject MessageEmiterPref;
    [SerializeField] private GameObject StoragePref;
    [SerializeField] private GameObject DebrisPref;

    [SerializeField] private int maxMessagesAmount;
    [SerializeField] private int maxStoragesAmount;
    [SerializeField] private int maxDebrisAmount;
    void Awake()
    {
        StartCoroutine(SpawnMessageEmmiters());
        StartCoroutine(SpawnStorages());
        StartCoroutine(SpawnDebris());
    }

    private IEnumerator SpawnMessageEmmiters()
    {
        WWW request = new WWW("http://localhost/sqlconnect/spawnMessageemmiters.php");
        yield return request;
        string[] rows = request.text.Split('\n');

        for (int i = 0; i < maxMessagesAmount; i++)
        {
            if (rows[i].Length == 0)
                break;

            string[] param = rows[i].Split("\t");

            GameObject obj = Instantiate(MessageEmiterPref, new Vector2(float.Parse(param[3]), float.Parse(param[4])), Quaternion.identity);
            obj.GetComponent<MessageEmmiter>().Message = param[2];
        }
    }

    private IEnumerator SpawnStorages()
    {
        WWW request = new WWW("http://localhost/sqlconnect/spawnStorage.php");
        yield return request;
        string[] rows = request.text.Split('\n');

        for (int i = 0; i < maxStoragesAmount; i++)
        {
            if (rows[i].Length == 0)
                break;

            string[] param = rows[i].Split("\t");

            GameObject obj = Instantiate(StoragePref, new Vector2(float.Parse(param[3]), float.Parse(param[4])), Quaternion.identity);
            obj.GetComponent<Storage>().BatteriesAmmount = int.Parse(param[1]);
        }
    }

    private IEnumerator SpawnDebris()
    {
        WWW request = new WWW("http://localhost/sqlconnect/spawnDebris.php");
        yield return request;
        string[] rows = request.text.Split('\n');

        for (int i = 0; i < maxDebrisAmount; i++)
        {
            if (rows[i].Length == 0)
                break;

            string[] param = rows[i].Split("\t");

            GameObject obj = Instantiate(DebrisPref, new Vector2(float.Parse(param[3]), float.Parse(param[4])), Quaternion.identity);
            Debug.Log(param[1]);
            obj.GetComponent<BoatDebris>().BatteriesAmmount = int.Parse(param[1]);
            obj.GetComponent<BoatDebris>().LastMessage = param[2];
        }
    }
}

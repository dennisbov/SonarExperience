using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageCollector : MonoBehaviour
{
    [SerializeField] private BatteriesCounter batteriesCounter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<Storage>(out Storage storage))
        {
            if (storage.IsActive == false)
            {
                return;
            }
            batteriesCounter.ChangeBattariesAmount(storage.BatteriesAmmount);
            Destroy(storage.gameObject);
            StartCoroutine(ClearStorageFromDataBase());
        }

        if (collision.transform.TryGetComponent<BoatDebris>(out BoatDebris debris))
        {
            if (debris.IsActive == false)
            {
                return;
            }
            batteriesCounter.ChangeBattariesAmount(debris.BatteriesAmmount);
            debris.BatteriesAmmount = 0;
        }
    }

    private IEnumerator ClearStorageFromDataBase()
    {
        yield return null;
    }
}

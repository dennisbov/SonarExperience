using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageCreator : MonoBehaviour
{
    [SerializeField] private CurrentPlayerScoreInfo currentPlayerScoreInfo;
    [SerializeField] private GameObject storagePref;
    [SerializeField] private BatteriesCounter batteriesCounter;
    [SerializeField] private float placementOffset;

    public void CreateStorage()
    {
        GameObject storageObj = Instantiate(storagePref, transform.position + Vector3.down * placementOffset, Quaternion.identity);
        Storage storage = storageObj.GetComponent<Storage>();
        storage.IsActive = false;
        storage.BatteriesAmmount = batteriesCounter.CollectedBatteries;
        batteriesCounter.ChangeBattariesAmount(-batteriesCounter.CollectedBatteries);
        currentPlayerScoreInfo.storages.Add(new StorageStr(storage.transform.position, storage.BatteriesAmmount));
    }
}

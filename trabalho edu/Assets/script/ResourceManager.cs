using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class ResourceManager : MonoBehaviour
{

    [SerializeField] AssetReference assetReference = null;
    [SerializeField] Transform spawnPoint;
    AsyncOperationHandle<GameObject> handle;
    List<GameObject> prefabs = new List<GameObject>();

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (prefabs.Count <= 0)
                LoadAsset();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (prefabs.Count > 0)
                UnloadAsset();
        }
    }
    private void LoadAsset()
    {
        handle = assetReference.InstantiateAsync(spawnPoint.position, spawnPoint.rotation);
        handle.Completed += handle =>
        {
            prefabs.Add(handle.Result);
        };
    }

    private void UnloadAsset()
    {
        foreach (GameObject prefab in prefabs)
        {
            Addressables.ReleaseInstance(prefab);
        }
        prefabs.Clear();
    }
}

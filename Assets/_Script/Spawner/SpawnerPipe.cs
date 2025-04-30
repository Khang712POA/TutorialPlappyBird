using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    [SerializeField] private GameObject pipeHolder;
    void Start()
    {
        StartCoroutine(this._Spawner());
    }
    IEnumerator _Spawner()
    {
        yield return new WaitForSeconds(1);

        Vector3 teamp = pipeHolder.transform.position;

        teamp.y = Random.Range(-1.5f, 1.5f);

        Instantiate(pipeHolder, teamp, Quaternion.identity);

        StartCoroutine(this._Spawner());


    }
}

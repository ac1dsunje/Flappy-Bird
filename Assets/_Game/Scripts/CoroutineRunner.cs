using System.Collections;
using UnityEngine;

public class CoroutineRunner: MonoBehaviour
{
    public void Run(IEnumerator coroutine) => StartCoroutine(coroutine);
}
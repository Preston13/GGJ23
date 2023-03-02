using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Vector2 closedPos;
    public Vector2 openPos;
    public bool isOpen = false;

    public void ShopToggle()
    {
        if (!isOpen)
        {
            StartCoroutine(LerpShop(openPos, .5f));
            isOpen = true;
        }
        else
        {
            StartCoroutine(LerpShop(closedPos, .5f));
            isOpen = false;
        }
    }

    IEnumerator LerpShop(Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}

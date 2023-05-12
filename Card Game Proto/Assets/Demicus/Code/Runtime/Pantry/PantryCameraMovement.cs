using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantryCameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 position1;
    [SerializeField] private Vector3 position2;
    [SerializeField] private float duration;
    [SerializeField] public bool onFood;
    public void CamMovement()
    {
        switch(onFood)
        {
            case true:
                StartCoroutine(LerpPosition(position2, duration));
                break;
            case false:
                StartCoroutine(LerpPosition(position1, duration));
                break;
        }
    }
    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        while (transform.position != targetPosition)
        {
            var step = duration/Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            yield return new WaitForEndOfFrame();
        }
        onFood = !onFood;
    }
    
}

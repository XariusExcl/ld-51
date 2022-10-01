using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFinderSwiper : MonoBehaviour
{
    float _rotation = 0f;
    public float Rotation {get => _rotation; private set { _rotation = value;}}

    public void Swipe()
    {
        StartCoroutine(Co_Swipe());
    }
    
    IEnumerator Co_Swipe()
    {
        while(_rotation != 360f)
        {
            _rotation += 5f;
            transform.rotation = Quaternion.Euler(0f, 0f, -_rotation);
            yield return new WaitForEndOfFrame();
        }
        _rotation = 0f;
    }
}

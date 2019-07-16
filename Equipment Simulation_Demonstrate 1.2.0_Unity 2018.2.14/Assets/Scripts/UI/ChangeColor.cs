using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour 
{
    void OnClick()
    {
        transform.GetComponent<UIButton>().isEnabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private int levelNumber;

    public void OnClick()
    {
        GameManager.Instance.ChangeIndex(levelNumber);
    }
}

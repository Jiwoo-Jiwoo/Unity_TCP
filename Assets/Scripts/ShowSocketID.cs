using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowSocketID : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    void Update()
    {
        text.text = $"socketID: {NetworkManager.Instance.ID}";
    }
}

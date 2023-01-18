using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Points : MonoBehaviour
{
    public ulong points = 0;
    private TextMeshProUGUI text;
    private string showUI;
    // Start is called before the first frame update
    void Start()
    {
        text=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        showUI=points.ToString();
        text.text = showUI;
    }
}

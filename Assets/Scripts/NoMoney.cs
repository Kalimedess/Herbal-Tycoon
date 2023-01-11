using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoMoney : MonoBehaviour
{
    private float timeRaw;
    private int time;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    public IEnumerator showWarning()
    {
        text.enabled = true;
        yield return new WaitForSeconds(4);
        text.enabled = false;
    }
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.enabled = false;
    }
}

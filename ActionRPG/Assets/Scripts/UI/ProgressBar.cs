using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

    public GameObject progressBar;

    public void SetPercentage(float _Percentage)
    {
        transform.localScale = new Vector3(_Percentage, transform.localScale.y, transform.localScale.z);
    }
}

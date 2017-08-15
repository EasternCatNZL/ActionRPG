using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

    public Transform progressBar;

    public void SetPercentage(float _Percentage)
    {
        progressBar.localScale = new Vector3(_Percentage, progressBar.localScale.y, progressBar.localScale.z);
    }
}

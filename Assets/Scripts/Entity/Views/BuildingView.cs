using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingView : GameobjectHUD
{
    [SerializeField] private TMP_Text _remainTimeText;
    [SerializeField] private Slider _progressSlider;

    public void UpdateView(float progress, float remainTime)
    {
        _progressSlider.value = progress;
        _remainTimeText.text = remainTime.ToString("F1") + "s";
    }
}

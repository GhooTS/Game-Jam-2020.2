using GTVariable;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeView : MonoBehaviour
{
    public FloatVariable current;
    public FloatVariable max;
    public Image fill;
    public TextMeshProUGUI timeText;
    public RectTransform barTransform;
    [Min(1)]
    public float minValue = 30;
    public float maxValue = 120;
    public float barMinSize = 200;
    public float barMaxSize = 500;


    private void OnEnable()
    {
        UpdateView();
    }

    private void Update()
    {
        fill.fillAmount = current.value / max.value;
        timeText.text = $"-{Mathf.Round(current.value)} s.";
    }

    public void UpdateView()
    {
        float size;
        size = (max - minValue) / (maxValue - minValue);
        size = Mathf.Clamp(size, 0f, 1f);
        size = size * (barMaxSize - barMinSize) + barMinSize;

        barTransform.sizeDelta = new Vector2(size, barTransform.sizeDelta.y);
    }
}
using GTVariable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    public FloatVariable current;
    public FloatVariable max;
    public Image fill;



    private void Update()
    {
        

        fill.fillAmount = current.value / max.value;
    }


}
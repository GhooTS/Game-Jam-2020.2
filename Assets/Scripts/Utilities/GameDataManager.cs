using GTVariable;
using UnityEngine;
using System.Collections.Generic;

public class GameDataManager : MonoBehaviour
{
    public class Data<VarType, ParameterType>
        where VarType : Variable<ParameterType>
    {
        public VarType value;
        public ParameterType defaultValue;

        public void Reset()
        {
            value.SetValue(defaultValue);
        }
    }

    [System.Serializable]
    public class FloatData : Data<FloatVariable, float> { }

    [System.Serializable]
    public class IntData : Data<IntVariable, int> { }

    public List<FloatData> floatData;
    public List<IntData> intData;

    private void Awake()
    {
        foreach (var data in floatData)
        {
            data.Reset();
        }

        foreach (var data in intData)
        {
            data.Reset();
        }
    }
}

using UnityEngine;

namespace GTVariable
{
    [SelectionBase]
    [CreateAssetMenu(menuName = "ScriptableVars/Vars/Float")]
    public class FloatVariable : Variable<float>
    {
        public void Add(float value)
        {
            SetValue(this.value + value);
        }

        public void Substract(float Value)
        {
            SetValue(this.value - value);
        }
    }
}
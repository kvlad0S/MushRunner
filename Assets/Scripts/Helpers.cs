using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers  {


    public static float Map(float value, float originalMin, float originalMax, float newMin, float newMax, bool clamp = false) {
        float newValue = newMin + (newMax - newMin) * ((value - originalMin) / (originalMax - originalMin));

        return clamp ? Mathf.Clamp(newValue, Mathf.Min(newMin, newMax), Mathf.Max(newMin, newMax)) : newValue;
    }
}

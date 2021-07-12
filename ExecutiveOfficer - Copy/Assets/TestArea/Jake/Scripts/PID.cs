[System.Serializable]
public class PID {
    public float pFactor, iFactor, dFactor;

    float integral;
    float lastError;


    public PID(float pFactor, float iFactor, float dFactor) {
        this.pFactor = pFactor;
        this.iFactor = iFactor;
        this.dFactor = dFactor;
    }


    public float Update(float setpoint, float actual, float timeFrame) {
        //UnityEngine.MonoBehaviour.print("Setpoint - " + setpoint.ToString("F4") + ", Actual - " + actual.ToString("F4") + "Timeframe - " + timeFrame.ToString("F4") + "!");
        float present = setpoint - actual;
        //UnityEngine.MonoBehaviour.print("Present - " + present.ToString("F4") + "!");
        //UnityEngine.MonoBehaviour.print("Old Integral - " + integral.ToString("F4") + "!");
        integral += present * timeFrame;
        //UnityEngine.MonoBehaviour.print("New Integral - " + integral.ToString("F4") + "!");
        float deriv = (present - lastError) / timeFrame;
        //UnityEngine.MonoBehaviour.print("Deriv - " + deriv.ToString("F4") + "!");
        lastError = present;
        //UnityEngine.MonoBehaviour.print("PID Value - " + (present * pFactor + integral * iFactor + deriv * dFactor).ToString("F4") + "!");
        return present * pFactor + integral * iFactor + deriv * dFactor;
    }
}
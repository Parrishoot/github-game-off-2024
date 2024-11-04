using UnityEngine;

public class RampController
{
    public enum RampMode {
        UP,
        DOWN
    }

    private Timer rampUpTimer;

    private Timer rampDownTimer;

    public RampMode mode = RampMode.UP;

    private float rampMax;

    private float rampMin;

    public RampController(float rampMin, float rampMax, float rampUpTime, float rampDownTime, RampMode initialMode) {
        this.rampMin = rampMin;
        this.rampMax = rampMax;
        this.mode = initialMode;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTargetingEvent : GameEvent {
    public TargetingData targetData;

    public ShipTargetingEvent(ShipModule shipModule, TargetingMode tgtMode) {
        targetData = new TargetingData(shipModule, tgtMode);
    }
}
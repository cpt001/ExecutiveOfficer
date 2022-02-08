using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingData : IEquatable<TargetingData> {
    public ShipModule targetModule;
    public TargetingMode targetMode;

    public TargetingData(ShipModule shipModule, TargetingMode tgtMode) {
        targetModule = shipModule;
        targetMode = tgtMode;
    }

    public override bool Equals(object obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != typeof(TargetingData)) return false;
        return Equals((TargetingData)obj);
    }

    public bool Equals(TargetingData other) {
        return other != null &&
               EqualityComparer<ShipModule>.Default.Equals(targetModule, other.targetModule) &&
               targetMode == other.targetMode;
    }

    public override int GetHashCode() {
        var hashCode = -1897331333;
        hashCode = hashCode * -1521134295 + EqualityComparer<ShipModule>.Default.GetHashCode(targetModule);
        hashCode = hashCode * -1521134295 + targetMode.GetHashCode();
        return hashCode;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleDestroyedEvent : GameEvent {
    public ShipModule destroyedModule;

    public ModuleDestroyedEvent(ShipModule module) {
        destroyedModule = module;
    }
}
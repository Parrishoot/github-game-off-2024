using System;
using System.Collections.Generic;
using UnityEngine;

public static class LayerMaskUtil
{
// TODO: Update these to the real things
    public static List<string> WALL_LAYERS = new List<string>() {
        "Default"
    };

    public static List<string> GROUND_LAYERS = new List<string>() {
        "Default"
    };

    public static int GetWallMask() {
        return LayerMask.GetMask(WALL_LAYERS.ToArray());
    }

    public static int GetGroundMask() {
        return LayerMask.GetMask(GROUND_LAYERS.ToArray());
    }

    public static bool InLayerMask(int layer, LayerMask layerMask) {
        return layerMask == (layerMask | (1 << layer));
    }
}

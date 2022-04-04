using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static bool ExistLayerByLayerMask(this LayerMask layerMask, int layer)
    {
        if ((layerMask.value & 1 << layer) > 0)
        {
            return true;
        }

        return false;
    }
}

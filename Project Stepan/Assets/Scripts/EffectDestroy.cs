using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public void DestroyfromTime()
    {
        Destroy(gameObject, 0.2f);
    }

}

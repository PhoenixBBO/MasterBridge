using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public int pressurePadCnt = 0;

    private void Update()
    {
        if (pressurePadCnt >= 3)
        {
            UnlockBarrier();
        }
    }

    void UnlockBarrier()
    {
        print("FUCK YOU!");
    }
}

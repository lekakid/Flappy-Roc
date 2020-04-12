using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateRotator : MonoBehaviour
{
    [Header("Value")]
    public float Delay = 5f;

    [Header("Gates")]
    public List<Gate> Gates;

    float _accTime = 5f;

    // Update is called once per frame
    void Update()
    {
        _accTime += Time.deltaTime;

        if(_accTime > Delay) {
            _accTime -= Delay;

            foreach(Gate g in Gates) {
                if(g.isRunning)
                    continue;

                g.SetGateHeight();
                g.Run();
                break;
            }
        }
    }

    public void Init() {
        foreach(Gate g in Gates) {
            g.Init();
        }
    }
}

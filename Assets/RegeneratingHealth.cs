using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegeneratingHealth : MonoBehaviour
{

    [SerializeField] private float _initialHealthChargeDelay = 1.0f;
    [SerializeField] private float _healthRechargeTime = 0.5f;
    private MortalInfo healthInfo; 

    private float _curHealthRechargeTime = 0.0f;
    private float _curHealthChargeDelay = 0.0f;

    private void Start()
    {
        healthInfo = gameObject.GetComponent<MortalInfo>();
    }

    public void ResetHealthTimer()
    {
        _curHealthChargeDelay = _initialHealthChargeDelay;
    }

    // Update is called once per frame
    void Update()
    {
        // Initial health delay
        // You only recharge health a moment after you got shot
        if (_curHealthChargeDelay > 0)
        {
            _curHealthChargeDelay -= Time.deltaTime;
        }
        else
        {
            if (_curHealthRechargeTime > 0)
            {
                _curHealthRechargeTime -= Time.deltaTime;
            }
            else
            {
                healthInfo.Heal(1);
                _curHealthRechargeTime = _healthRechargeTime;
            }
        }
    }
}

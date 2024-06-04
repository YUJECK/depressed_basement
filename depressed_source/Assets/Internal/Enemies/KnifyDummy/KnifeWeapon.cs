using System;
using CodeBase.Hits;
using CodeBase.Items;
using UnityEngine;

[RequireComponent(typeof(HitOnCollide))]
[RequireComponent(typeof(Rigidbody2D))]
public class KnifeWeapon : WeaponObject
{
    [SerializeField] private float speed = 3;
    
    private void OnEnable()
    {
        GetComponent<HitOnCollide>().OnCollide += OnCollide;
    }

    public void AddForce()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed, ForceMode2D.Impulse);
    }
    
    private void OnCollide()
    {
        Destroy(gameObject);
    }

    public override HitData GetHitData()
    {
        return new BladeHitData();
    }
}
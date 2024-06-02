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
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
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
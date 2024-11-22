using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MovePlanet : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public float duration;
    public Ease easyType;

    /*private void FixedUpdate()
    {
        transform.DOMove(target.position, duration).SetEase(easyType);
    }
    */
    public void Down()
    {
        transform.DOMove(target.position, duration).SetEase(easyType);
    }
    public void Up()
    {
        transform.DOMove(target2.position, duration).SetEase(easyType);
    }
}

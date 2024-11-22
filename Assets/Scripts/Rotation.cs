using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FirstHalfLoop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FirstHalfLoop()
    {
        transform.DOMove(new Vector3(-12, -5, 0), 5).SetEase(Ease.Linear).OnComplete(SecondLoop);
    }
    public void SecondLoop()
    {
        transform.DOMove(new Vector3(-12, 2, 0), 5).SetEase(Ease.Linear).OnComplete(FirstHalfLoop);
    }
}

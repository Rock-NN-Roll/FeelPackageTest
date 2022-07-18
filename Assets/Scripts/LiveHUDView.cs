using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public partial class LiveHUDView : MonoBehaviour
{
    [Header("HUD related")]
    [SerializeField] private Image userProfilePic;
    [SerializeField] private Text userName;

    [SerializeField] private GameObject hpBarRoot = default;
    [SerializeField] private float maxHpForHpGroup = 20;
    [SerializeField] private float sliderTweenDelayTime;
    [SerializeField] private float sliderTweenTime;
    [SerializeField] private float lastMaxHp;
    [SerializeField] private float lastCurHp;
    [SerializeField] private Camera Cam;

    public void Awake()
    {
        Cam = Camera.main;
    }

    private IEnumerator DestroyHudView()
    {
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }
    protected void LateUpdate()
    {
        transform.rotation = Cam.transform.rotation;
    }
    
}
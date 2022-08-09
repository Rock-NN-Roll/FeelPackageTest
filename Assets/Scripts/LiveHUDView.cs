using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
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
    [SerializeField] private MMFeedbacks onDecreaseFeedbacks;
    [SerializeField] private MMFeedbacks onIncreaseFeedbacks;

    public void Awake()
    {
        Cam = Camera.current;
    }

    private IEnumerator DestroyHudView()
    {
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }

    public void OnMinusTen()
    {
        onDecreaseFeedbacks.PlayFeedbacks();
    }
    public void OnPlusTen()
    {
        onIncreaseFeedbacks.PlayFeedbacks();
    }
    
    protected void LateUpdate()
    {
        // transform.rotation = Cam.transform.rotation;
    }
    
}
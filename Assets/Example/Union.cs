using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Library;

/// <summary>
/// 穿山甲广告示例
/// </summary>
public class Union : MonoBehaviour
{
    public Button ShowNativeBanner;
    public Button ShowNativeInterstitial;
    public Button ShowFullScreen;
    public Button ShowRewardVideo;
    public Button ShowExpressBanner;
    public Button RemoveExpressBanner;
    public Button ShowExpressInterstitial;
    public Button ShowExpresFeed;
    public Button ShowSplash;
    public Button ShowExpressSplash;

    public void Awake()
    {
        UnionAdComponent.GetUnionAdComponent().Init();
    }

    public void Start()
    {
        RegisterBtn();
    }

    private void RegisterBtn()
    {
        ShowNativeBanner.onClick.AddListener(()=> { UnionAdComponent.GetUnionAdComponent().ShowNativeBanner(); });
        ShowNativeInterstitial.onClick.AddListener(() => { UnionAdComponent.GetUnionAdComponent().ShowNativeInterstitial(); });
        ShowFullScreen.onClick.AddListener(() => { UnionAdComponent.GetUnionAdComponent().ShowFullScreen(); });
        ShowRewardVideo.onClick.AddListener(() => { UnionAdComponent.GetUnionAdComponent().ShowRewardVideo(RewardVideoCallback,99); });
        ShowExpressBanner.onClick.AddListener(() => { UnionAdComponent.GetUnionAdComponent().ShowExpressBanner(); });
        RemoveExpressBanner.onClick.AddListener(() => { UnionAdComponent.GetUnionAdComponent().RemoveExpressBanner(); });
        ShowExpressInterstitial.onClick.AddListener(() => { UnionAdComponent.GetUnionAdComponent().ShowExpressInterstitial(); });
        ShowExpresFeed.onClick.AddListener(() => { UnionAdComponent.GetUnionAdComponent().ShowExpressFeed(); });
        ShowSplash.onClick.AddListener(() => { UnionAdComponent.GetUnionAdComponent().ShowSplash(); });
        ShowExpressSplash.onClick.AddListener(() => { UnionAdComponent.GetUnionAdComponent().ShowExpressSplash(); });
    }

    private void RewardVideoCallback(int i)
    {
        Debug.Log("激励视频成功"+i);
    }


}

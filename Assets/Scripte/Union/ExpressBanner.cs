using ByteDance.Union;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Library
{
    /// <summary>
    /// 个性化模板Banner广告
    /// </summary>
    public class ExpressBanner : AdBase
    {
        private static ExpressBanner expressBanner;
        public static ExpressBanner GetExpressBanner()
        {
            if (expressBanner == null)
            {
                expressBanner = new ExpressBanner();
            }

            return expressBanner;
        }
#if UNITY_IOS
        /// <summary>
        /// IOS端  个性化Banner模板广告对象
        /// </summary>
        public ExpressBannerAd IExpressBannerAd;
#endif
        /// <summary>
        /// Android端 个性化Banner模板广告对象
        /// </summary>
        public ExpressAd AExpressBannerAd;

        private void LoadExpressBannerAd(bool isShow)
        {
            IsRemoveBanner = false;
            var adSlot = new AdSlot.Builder()
#if UNITY_IOS
                             .SetCodeId(UnionAdParam.ExpressBannerIOSId)
#else
                             .SetCodeId(UnionAdParam.ExpressBannerAndroidId)
                             ////期望模板广告view的size,单位dp，//高度按照实际rit对应宽高传入
#endif
                             .SetExpressViewAcceptedSize(size.x, size.y)
                                 .SetSupportDeepLink(true)
                                 .SetImageAcceptedSize((int)size.x, (int)size.y)
                                 .SetAdCount(3)
                                 .SetOrientation(AdOrientation.Vertical)
                                 .Build();

            this.AdNative.LoadExpressBannerAd(adSlot, new ExpressAdListener(this, 1, isShow));
        }

        public void ShowExpressBannerAd()
        {
            if (IsRemoveBanner)
            {
                return;
            }
#if UNITY_IOS
        if (this.IExpressBannerAd == null)
        {
            Debug.LogError("请先加载广告");
            return;
        }
        int x = 0;
        int y =Screen.height - Mathf.CeilToInt(Screen.width / bannerSize.x * bannerSize.y);

        this.IExpressBannerAd.ShowExpressAd(x, y);
#else
            if (this.AExpressBannerAd == null)
            {
                Debug.LogError("请先加载广告");
                return;
            }
            //设置轮播间隔 30s--120s;不设置则不开启轮播
            this.AExpressBannerAd.SetSlideIntervalTime(30 * 1000);
            ExpressAdInteractionListener expressAdInteractionListener = new ExpressAdInteractionListener(this, 1);
            ExpressAdDislikeCallback dislikeCallback = new ExpressAdDislikeCallback(this, 1);
            this.AExpressBannerAd.SetDownloadListener(
                new AppDownloadListener(this));
            ByteDance.Union.NativeAdManager.Instance().ShowExpressBannerAd(CurrentActivity, AExpressBannerAd.handle, expressAdInteractionListener, dislikeCallback);
#endif
        }

        public void RemoveExpressBanner()
        {
            IsRemoveBanner = true;
#if UNIYT_IOS
              this.IExpressBannerAd.Dispose();
              this.IExpressBannerAd = null;
#else
            if (this.AExpressBannerAd != null)
            {
                ByteDance.Union.NativeAdManager.Instance().DestoryExpressAd(AExpressBannerAd.handle);
                AExpressBannerAd = null;
            }
#endif
        }

        public void LoadAndShowExpressBanner()
        {
            LoadExpressBannerAd(true);
        }

        public void Destory()
        {
            RemoveExpressBanner();
        }
    }

    /// <summary>
    /// 个性化模板插屏广告
    /// </summary>
    public class ExpressInterstital:AdBase
    {
        private static ExpressInterstital expressInterstital;
        public static ExpressInterstital GetExpressInterstital()
        {
            if (expressInterstital==null)
            {
                expressInterstital = new ExpressInterstital();
            }

            return expressInterstital;
        }
#if UNITY_IOS
        /// <summary>
        /// IOS端的 个性化插屏模板广告对象
        /// </summary>
        public ExpressInterstitialAd IExpressInterstitialAd;
#endif
        /// <summary>
        /// Android端 个性化插屏模板广告对象
        /// </summary>
        public ExpressAd AExpressInterstitialAd;

        private void LoadExpressInterstitialAd(bool isShow)
        {
            var adSlot = new AdSlot.Builder()
#if UNITY_IOS
                             .SetCodeId(UnionAdParam.ExpressInterstitialIOSId)
                             .SetExpressViewAcceptedSize(200, 300)
#else
                             .SetCodeId(UnionAdParam.ExpressInterstitialAndroidId)
                                 .SetExpressViewAcceptedSize(350, 0)
                             ////期望模板广告view的size,单位dp，//高度设置为0,则高度会自适应
#endif
                             .SetSupportDeepLink(true)
                                 .SetAdCount(1)
                                 .SetImageAcceptedSize(1080, 1920)
                                 .Build();
            this.AdNative.LoadExpressInterstitialAd(adSlot, new ExpressAdListener(this, 2, isShow));

        }

        /// <summary>
        /// Show the reward Ad.
        /// </summary>
        public void ShowExpressInterstitialAd()
        {
#if UNITY_IOS
        if (this.IExpressInterstitialAd == null)
        {
            Debug.LogError("请先加载广告");
            return;
        }

        int x = 0;
        int y =Screen.height - Mathf.CeilToInt(Screen.width / bannerSize.x * bannerSize.y);

        this.iExpressInterstitialAd.ShowExpressAd(x, y);
#else
            if (this.AExpressInterstitialAd == null)
            {
                Debug.LogError("请先加载广告");
                return;
            }
            ExpressAdInteractionListener expressAdInteractionListener = new ExpressAdInteractionListener(this, 1);
            this.AExpressInterstitialAd.SetDownloadListener(
                new AppDownloadListener(this));
           ByteDance.Union.NativeAdManager.Instance().ShowExpressInterstitialAd(CurrentActivity, AExpressInterstitialAd.handle, expressAdInteractionListener);
#endif
        }

        public void LoadAndShowExpressInterstitialAd()
        {
            LoadExpressInterstitialAd(true);
        }

        public void Destory()
        {
            if (this.AExpressInterstitialAd != null)
            {
                this.AExpressInterstitialAd = null;
            }
        }
    }

    /// <summary>
    /// 个性化模板 信息流广告
    /// </summary>
    public class ExpressFeed:AdBase
    {
        private static ExpressFeed expressFeed;
        public static ExpressFeed GetExpressFeed()
        {
            if (expressFeed ==null)
            {
                expressFeed = new ExpressFeed();
            }
            return expressFeed;
        }

        public ExpressAd ExpressFeedad;

        public void LoadExpressFeedAd(bool isShow)
        {
            var adSlot = new AdSlot.Builder()
#if UNITY_IOS
                             .SetCodeId(UnionAdParam.ExpressFeedIOSId)
#else
                             .SetCodeId(UnionAdParam.ExpressFeedAndroidId)
                                 ////期望模板广告view的size,单位dp，//高度设置为0,则高度会自适应
                                 .SetExpressViewAcceptedSize(350, 0)
#endif
                             .SetSupportDeepLink(true)
                                 .SetImageAcceptedSize(1080, 1920)
                                 .SetOrientation(AdOrientation.Vertical)
                                 .SetAdCount(1) //请求广告数量为1到3条
                                 .Build();
            this.AdNative.LoadNativeExpressAd(adSlot, new ExpressAdListener(this, 0,isShow));

        }

        /// <summary>
        /// Show the expressFeed Ad.
        /// </summary>
        public void ShowExpressFeedAd()
        {
#if UNITY_IOS
        if (this.ExpressFeedad == null)
        {
            Debug.LogError("请先加载广告");
            return;
        }
        int x = 0;
        int y =Screen.height - Mathf.CeilToInt(Screen.width / bannerSize.x * bannerSize.y);
        this.ExpressFeedad.ShowExpressAd(x, y);
#else
            if (this.ExpressFeedad == null)
            {
                Debug.LogError("请先加载广告");
                return;
            }
            ExpressAdInteractionListener expressAdInteractionListener = new ExpressAdInteractionListener(this, 0);
            ExpressAdDislikeCallback dislikeCallback = new ExpressAdDislikeCallback(this, 0);
            this.ExpressFeedad.SetExpressInteractionListener(
                expressAdInteractionListener);
            this.ExpressFeedad.SetDownloadListener(
                new AppDownloadListener(this));
            ByteDance.Union.NativeAdManager.Instance().ShowExpressFeedAd(CurrentActivity, ExpressFeedad.handle, expressAdInteractionListener, dislikeCallback);
#endif
        }

        public void LoadAndShowExpressFeedAd()
        {
            LoadExpressFeedAd(true);
        }

        public void Destrory()
        {
#if UNITY_ANDROID
            if (this.ExpressFeedad != null)
            {
                ByteDance.Union.NativeAdManager.Instance().DestoryExpressAd(ExpressFeedad.handle);
                ExpressFeedad = null;
            }
#endif
        }
    }



    public class ExpressAdListener : IExpressAdListener
    {
        private AdBase adBase;
        private int type;//0:feed   1:banner  2:interstitial
        private bool isShow;

        public ExpressAdListener(AdBase adBase, int type, bool isShow)
        {
            this.adBase = adBase;
            this.type = type;
            this.isShow = isShow;
        }
        public void OnError(int code, string message)
        {
            Debug.LogError("onExpressAdError: " + message + " errcode：" + code);
        }

        public void OnExpressAdLoad(List<ExpressAd> ads)
        {
            Debug.LogError("OnExpressAdLoad");
            IEnumerator<ExpressAd> enumerator = ads.GetEnumerator();
            if (enumerator.MoveNext())
            {
                switch (type)
                {
                    case 0:
                        (this.adBase as ExpressFeed).ExpressFeedad = enumerator.Current;
                        (this.adBase as ExpressFeed).ExpressFeedad.SetExpressInteractionListener(new ExpressAdInteractionListener(this.adBase, 0));
                        (this.adBase as ExpressFeed).ExpressFeedad.SetDownloadListener(
                            new AppDownloadListener(this.adBase));
                        break;
                    case 1:
                        (this.adBase as ExpressBanner).AExpressBannerAd = enumerator.Current;
                        break;
                    case 2:
                        (this.adBase as ExpressInterstital).AExpressInterstitialAd = enumerator.Current;
                        break;
                }
            }

            if (isShow)
            {
                switch (type)
                {
                    case 0:
                        (this.adBase as ExpressFeed).ShowExpressFeedAd();
                        break;
                    case 1:
                        (this.adBase as ExpressBanner).ShowExpressBannerAd();
                        break;
                    case 2:
                        (this.adBase as ExpressInterstital).ShowExpressInterstitialAd();
                        break;
                }
            }
        }
#if UNITY_IOS

        public void OnExpressBannerAdLoad(ExpressBannerAd ad)
        {
            Debug.Log("OnExpressBannerAdLoad");
            ad.SetExpressInteractionListener(
                new ExpressAdInteractionListener(this.adBase,1));
            //ad.SetDownloadListener(
            //    new AppDownloadListener(this.example));
            (this.adBase as ExpressBanner).IExpressBannerAd = ad;

         if (isShow)
            {
            (this.adBase as ExpressBanner).ShowExpressBannerAd();
        }

        }

        public void OnExpressInterstitialAdLoad(ExpressInterstitialAd ad)
        {
            Debug.Log("OnExpressInterstitialAdLoad");
            ad.SetExpressInteractionListener(
                new ExpressAdInteractionListener(this.adBase, 2));
            //ad.SetDownloadListener(
            //    new AppDownloadListener(this.example));
            (this.adBase as ExpressInterstital).IExpressInterstitialAd = ad;

         if (isShow)
            {
            (this.adBase as ExpressInterstital).ShowExpressInterstitialAd();
        }
        }
#else
#endif
    }

    public class ExpressAdInteractionListener : IExpressAdInteractionListener
    {
        private AdBase adBase;
        int type;//0:feed   1:banner  2:interstitial

        public ExpressAdInteractionListener(AdBase adBase, int type)
        {
            this.adBase = adBase;
            this.type = type;
        }
        public void OnAdClicked(ExpressAd ad)
        {
            Debug.LogError("express OnAdClicked,type:" + type);
        }

        public void OnAdShow(ExpressAd ad)
        {
            Debug.LogError("express OnAdShow,type:" + type);
        }

        public void OnAdViewRenderError(ExpressAd ad, int code, string message)
        {
            Debug.LogError("express OnAdViewRenderError,type:" + type);
        }

        public void OnAdViewRenderSucc(ExpressAd ad, float width, float height)
        {
            Debug.LogError("express OnAdViewRenderSucc,type:" + type);
        }
        public void OnAdClose(ExpressAd ad)
        {
            Debug.LogError("express OnAdClose,type:" + type);
        }
    }

    public class ExpressAdDislikeCallback : IDislikeInteractionListener
    {
        private AdBase adBase;
        int type;//0:feed   1:banner
        public ExpressAdDislikeCallback(AdBase adBase, int type)
        {
            this.adBase = adBase;
            this.type = type;
        }
        public void OnCancel()
        {
            Debug.LogError("express dislike OnCancel");
        }

        public void OnRefuse()
        {
            Debug.LogError("express dislike onRefuse");
        }

        public void OnSelected(int var1, string var2)
        {
            Debug.LogError("express dislike OnSelected:" + var2);
#if UNITY_IOS
        
#else
            //释放广告资源
            switch (type)
            {
                case 0:
                    if ((this.adBase as ExpressFeed).ExpressFeedad != null)
                    {
                        NativeAdManager.Instance().DestoryExpressAd((this.adBase as ExpressFeed).ExpressFeedad.handle);
                        (this.adBase as ExpressFeed).ExpressFeedad = null;
                    }
                    break;
                case 1:
                    if ((this.adBase as ExpressBanner).AExpressBannerAd != null)
                    {
                        NativeAdManager.Instance().DestoryExpressAd((this.adBase as ExpressBanner).AExpressBannerAd.handle);
                        (this.adBase as ExpressBanner).AExpressBannerAd = null;
                    }
                    break;
            }
#endif
        }
    }
}

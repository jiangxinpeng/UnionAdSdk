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
    /// 开屏广告
    /// </summary>
    public class Splash:AdBase
    {
        private static Splash splash;
        public static Splash GetSplash()
        {
            if (splash == null)
            {
                splash = new Splash();
            }

            return splash;
        }

       

        public BUSplashAd SplashAd
        {
            get;
            set;
        }

        /// <summary>
        /// 加载开屏广告
        /// </summary>
        public void LoadSplashAd()
        {
            var adSlot = new AdSlot.Builder()
#if UNITY_IOS
                .SetCodeId(UnionAdParam.SplashIOSId)
#else
                .SetCodeId(UnionAdParam.SplashAndroidId)
#endif
                .SetImageAcceptedSize(Screen.width, Screen.height)
                .Build();

#if UNITY_IOS
            AdNative.LoadSplashAd(adSlot, new SplashAdListener(this));
#else
            AdNative.LoadSplashAd(adSlot, new SplashAdListener(this,CurrentActivity, SplashAdManager));
#endif
        }



        public void Destory()
        {

        }
    }

    /// <summary>
    /// 开屏广告加载成功或失败的回调
    /// </summary>
    class SplashAdListener : ISplashAdListener
    {
        private AndroidJavaObject activity;
        private AndroidJavaObject splashAdManager;
        private AdBase adBase;

        public SplashAdListener(AdBase adBase)
        {
            this.adBase = adBase;
        }

        public SplashAdListener(AdBase adBase, AndroidJavaObject activity, AndroidJavaObject splashAdManager)
        {
            this.activity = activity;
            this.splashAdManager = splashAdManager;
            this.adBase = adBase;
        }

        public void OnError(int code, string message)
        {
            Debug.Log("加载开屏广告失败：" + code + ":" + message);
        }

        /// <summary>
        /// 加载开屏广告成功回调
        /// </summary>
        /// <param name="ad"></param>
        public void OnSplashAdLoad(BUSplashAd ad)
        {
            if (ad != null)  //
            {
                if (adBase is Splash)
                {
                    (adBase as Splash).SplashAd = ad;
                }

                if (adBase is ExpressSplash)
                {
                    (adBase as ExpressSplash).SplashAd = ad;
                }
            }
            Debug.Log("加载开屏广告成功");
#if UNITY_IOS   //注册交互回调监听事件
            ad.SetSplashInteractionListener(new SplashAdInteractionListener(this.adComponent));
#else
            ad.SetSplashInteractionListener(new SplashAdInteractionListener(this.adBase, this.activity, this.splashAdManager));
#endif

#if UNITY_ANDROID
            if (adBase != null && this.splashAdManager != null && this.activity != null)
            {
                this.splashAdManager.Call("showSplashAd", this.activity, ad.getCurrentSplshAd());
            }
#endif
        }
    }

    /// <summary>
    /// 开屏广告的交互回调（即玩家做了什么操作）
    /// </summary>
    class SplashAdInteractionListener : ISplashAdInteractionListener
    {
        private AndroidJavaObject activity;
        private AndroidJavaObject splashAdManager;
        private AdBase adBase;
        private const int INTERACTION_TYPE_DOWNLOAD = 4;


        public SplashAdInteractionListener(AdBase adBase)
        {
            this.adBase = adBase;
        }

        public SplashAdInteractionListener(AdBase adBase, AndroidJavaObject activity, AndroidJavaObject splashAdManager)
        {
            this.adBase = adBase;
            this.activity = activity;
            this.splashAdManager = splashAdManager;
        }


        private void DestorySplash()
        {
#if UNITY_ANDROID
            if (splashAdManager != null && this.activity != null)
            {
                splashAdManager.Call("destorySplashView", this.activity);
            }
#else
                this.adComponent.SplashAd = null;
#endif
        }

        public void OnAdClicked(int type)
        {
#if UNITY_ANDROID
            if (type != INTERACTION_TYPE_DOWNLOAD)
            {
                DestorySplash();
            }
#endif
        }

        public void OnAdClose()
        {
            DestorySplash();
        }

        public void OnAdShow(int type)
        {

        }

        public void OnAdSkip()
        {
            DestorySplash();
        }

        public void OnAdTimeOver()
        {
            DestorySplash();
        }
    }
}

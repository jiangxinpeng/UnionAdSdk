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
    /// 穿山甲广告组件
    /// 一般用RewardVideo  Splash   ExpressBanner即可 其他根据需求来
    /// </summary>
    public class UnionAdComponent
    {
        private AndroidJavaObject currentActivity;
        public AndroidJavaObject CurrentActivity
        {
            get
            {
                if (currentActivity == null)
                {
                    var unityPlayer = new AndroidJavaClass(
              "com.unity3d.player.UnityPlayer");
                    currentActivity = unityPlayer.GetStatic<AndroidJavaObject>(
                   "currentActivity");
                }
                return currentActivity;
            }
        }

        private static UnionAdComponent unionAdComponent;
        public static UnionAdComponent GetUnionAdComponent()
        {
            if (unionAdComponent==null)
            {
                unionAdComponent = new UnionAdComponent();
            }

            return unionAdComponent;
        }

        /// <summary>
        /// 先初始化  然后申请权限
        /// </summary>
        public void Init()
        {
            var jc = new AndroidJavaClass("com.bytedance.android.UnionApplication");
            jc.CallStatic("Init", CurrentActivity,UnionAdParam.AppId,UnionAdParam.AppName,UnionAdParam.IsDebug);

            RequestPermissionIfNecessary();
        }


        public void Destory()
        {
          
        }

        /// <summary>
        /// 安卓平台申请必要的权限
        /// </summary>
        private void RequestPermissionIfNecessary()
        {
#if UNITY_ANDROID
            SDK.RequestPermissionIfNecessary();
#endif
        }

        public void ShowNativeBanner()
        {
            NativeBanner.GetNativeBanner().LoadAndShowNativeBanner();
        }

        public void ShowNativeInterstitial()
        {
            NativeIntersititial.GetNativeIntersititial().LoadAndShowIntersititial();
        }

        public void ShowFullScreen()
        {
            FullScreenVideo.GetFullScreenVideo().LoadAndShowFullScreenVideoAd();
        }

        public void ShowRewardVideo<T>(Action<T> successCallback,T t)
        {
            RewardVideo.GetRewardVideo().LoadAndShowRewardVideo(successCallback,t);
        }

        public void ShowExpressBanner()
        {
            ExpressBanner.GetExpressBanner().LoadAndShowExpressBanner();
        }

        public void RemoveExpressBanner()
        {
            ExpressBanner.GetExpressBanner().RemoveExpressBanner();
        }

        public void ShowExpressInterstitial()
        {
            ExpressInterstital.GetExpressInterstital().LoadAndShowExpressInterstitialAd();
        }

        public void ShowExpressFeed()
        {
            ExpressFeed.GetExpressFeed().LoadAndShowExpressFeedAd();
        }

        public void ShowSplash()
        {
            Splash.GetSplash().LoadSplashAd();
        }

        public void ShowExpressSplash()
        {
            ExpressSplash.GetExpressSplash().LoadExpressSplashAd();
        }


    }
}

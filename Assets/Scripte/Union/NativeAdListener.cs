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
    /// 原生广告(原生Banner/原生插屏)加载成功或者失败的回调
    /// </summary>
    public class NativeAdListener : INativeAdListener
    {
        private AdBase adBase;
        private bool isShow;

        public NativeAdListener(AdBase adBase,bool isShow)
        {
            this.adBase = adBase;
            this.isShow = isShow;
        }

        public void OnError(int code, string message)
        {
            Debug.LogError("OnNativeAdError: " + message + "errCode：" + code);
        }

        /// <summary>
        /// 加载原生广告成功的回调
        /// </summary>
        /// <param name="list">Android平台加载到的广告</param>
        /// <param name="ad">ios平台加载到的广告</param>
        public void OnNativeAdLoad(AndroidJavaObject list, NativeAd ad)
        {
#if UNITY_IOS
            if (ad.GetAdType() == AdSlotType.Banner)
            {
                (this.adBase as NativeBanner).BannerAd = ad;
               if (isShow)
                    {
                        (this.adBase as NativeBanner).ShowNativeBannerAd();
                    }
            } else if (ad.GetAdType() == AdSlotType.InteractionAd)
            {
                (this.adBase as NativeIntersititial).IntersititialAd = ad;
            }

            ad.SetNativeAdInteractionListener(
                new NativeAdInteractionListener(this.adBase, (int)(ad.GetAdType()))
            );
#else

            var size = list.Call<int>("size");

            if (size > 0)
            {
                if (adBase is NativeBanner)
                {
                    (this.adBase as NativeBanner).BannerAdObject = list.Call<AndroidJavaObject>("get", 0);
                    //this.example.mBannerAd = list.Call<AndroidJavaObject>("get", 0);
                    if (isShow)
                    {
                        (this.adBase as NativeBanner).ShowNativeBannerAd();
                    }
                }

                if (adBase is NativeIntersititial)
                {
                    (this.adBase as NativeIntersititial).IntersititialObject = list.Call<AndroidJavaObject>("get", 0);
                    // this.example.mIntersititialAd = list.Call<AndroidJavaObject>("get", 0);
                }
            }

#endif
            Debug.Log("OnNativeAdLoad");
        }
    }
}

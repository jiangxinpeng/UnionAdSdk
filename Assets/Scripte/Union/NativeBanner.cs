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
    /// 原生Banner
    /// 广告场景需要开发者自渲染广告视图  需要基于Android/IOS平台自定义实现
    /// </summary>
    public class NativeBanner:AdBase
    {
        /// <summary>
        /// 单例对象
        /// </summary>
        private static NativeBanner nativeBanner;

        public static NativeBanner GetNativeBanner()
        {
            if (nativeBanner == null)
            {
                nativeBanner = new NativeBanner();
            }
            return nativeBanner;
        }
#if UNITY_IOS
        /// <summary>
        /// IOS使用的原生广告对象
        /// </summary>
        public NativeAd BannerAd
        {
            get;set;
        }
#endif

        /// <summary>
        /// Android端的Banner对象
        /// </summary>
        public AndroidJavaObject BannerAdObject
        {
            get;set;
        }

        /// <summary>
        /// 加载原生Banner广告  
        /// isShow 加载完是否立即展示
        /// </summary>
        private void LoadNativeBannerAd(bool isShow)
        {
            IsRemoveBanner = false;
#if UNITY_IOS
        if (this.BannerAd != null)
        {
            Debug.LogError("广告已经加载");
            return;
        }
#else
            if (this.BannerAdObject != null)
            {
                Debug.LogError("广告已经加载");
                if (isShow)
                {
                    ShowNativeBannerAd();
                }
                return;
            }
#endif

            var adSlot = new AdSlot.Builder()
#if UNITY_IOS
            .SetCodeId(UnionAdParam.NativeBannerIOSId)
#else
            .SetCodeId(UnionAdParam.NativeBannerAndroidId)
#endif
            .SetSupportDeepLink(true)
                .SetImageAcceptedSize((int)size.x,(int)size.y)
                .SetNativeAdType(AdSlotType.Banner)
                .SetAdCount(1)
                .Build();
            this.AdNative.LoadNativeAd(adSlot, new NativeAdListener(this,isShow));
        }

        /// <summary>
        /// 展示原生Banner广告
        /// </summary>
        public void ShowNativeBannerAd()
        {

            if (IsRemoveBanner)
            {
                return;
            }
            //这里注意下  ios要自传入banner的位置，(0,0)的位置是顶部正中间
            //banner一般放在下面，如果原生banner的大小为600*90
            //那么 x =0  y = Screen.height - Mathf.CeilToInt(Screen.width / 600 * 90);
#if UNITY_IOS
       if (BannerAd == null)
        {
            Debug.LogError("请先加载广告");
            return;
        }

            int x = 0;
            int y =Screen.height - Mathf.CeilToInt(Screen.width / 600 * 90);
            this.BannerAd.ShowNativeAd(AdSlotType.Banner, x, y);
#else
            if (BannerAdObject == null)
            {
                Debug.LogError("请先加载广告");
                return;
            }
        
            NativeAdManager.Call("showNativeBannerAd", CurrentActivity, BannerAdObject);
#endif
        }


        /// <summary>
        /// 加载完就展示原生Banner
        /// </summary>
        public void LoadAndShowNativeBanner()
        {
            LoadNativeBannerAd(true);
        }

        /// <summary>
        /// 移除原生Banner广告
        /// </summary>
        public void RemovwNativeBanner()
        {
            IsRemoveBanner = true;
#if UNITY_IOS
             this.BannerAd.Dispose();
             this.BannerAd = null;
#else
            NativeAdManager.Call("removeBannerView");
            BannerAdObject = null;
#endif
        }
    }


 

}

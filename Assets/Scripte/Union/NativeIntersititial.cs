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
    /// 原生插屏广告
    /// </summary>
    public class NativeIntersititial : AdBase
    {
        private static NativeIntersititial nativeIntersititial;
        public static NativeIntersititial GetNativeIntersititial()
        {
            if (nativeIntersititial == null)
            {
                nativeIntersititial = new NativeIntersititial();
            }

            return nativeIntersititial;
        }
#if UNITY_IOS
        /// <summary>
        /// IOS加载原生插屏广告的广告对象
        /// </summary>
        public NativeAd IntersititialAd;
#endif

        /// <summary>
        /// 原生插屏广告Android对象
        /// </summary>
        public AndroidJavaObject IntersititialObject;

        /// <summary>
        /// 加载原生插屏广告
        /// </summary>
        private void LoadNativeIntersititialAd(bool isShow)
        {
#if UNITY_IOS
        if (this.IntersititialAd != null)
        {
            Debug.LogError("广告已经加载");
            return;
        }
#else
            if (this.IntersititialObject != null)
            {
                Debug.LogError("广告已经加载");
                if (isShow)
                {
                    ShowNativeIntersititialAd();
                }
                return;
            }
#endif
            var adSlot = new AdSlot.Builder()
#if UNITY_IOS
            .SetCodeId(UnionAdParam.NativeIntersititialIOSId)
#else
            .SetCodeId(UnionAdParam.NativeIntersititialAndroidId)
#endif
            .SetSupportDeepLink(true)
                .SetImageAcceptedSize(Screen.width, Mathf.CeilToInt(Screen.width / 600 * 90))
                .SetNativeAdType(AdSlotType.InteractionAd)
                .SetAdCount(1)
                .Build();
            this.AdNative.LoadNativeAd(adSlot, new NativeAdListener(this,isShow));
        }

        /// <summary>
        /// 展示原生插屏广告
        /// </summary>
        private void ShowNativeIntersititialAd()
        {
#if UNITY_IOS
        if (IntersititialAd == null)
        {
            Debug.LogError("请先加载广告");
            this.information.text = "请先加载广告";
            return;
        }

        int x = 0;
        int y =Screen.height - Mathf.CeilToInt(Screen.width / 600 * 90);
        this.IntersititialAd.ShowNativeAd(AdSlotType.InteractionAd, x, y);
#else
            if (IntersititialObject == null)
            {
                Debug.LogError("请先加载广告");
                return;
            }

            NativeAdManager.Call("showNativeIntersititialAd", CurrentActivity, IntersititialObject);
#endif
        }

        public void LoadAndShowIntersititial()
        {
            LoadNativeIntersititialAd(true);
        }

    }
}

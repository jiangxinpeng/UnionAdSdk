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
    /// 个性化模板 开屏广告
    /// </summary>
    public class ExpressSplash : AdBase
    {
        private static ExpressSplash expressSplash;
        public static ExpressSplash GetExpressSplash()
        {
            if (expressSplash == null)
            {
                expressSplash = new ExpressSplash();
            }

            return expressSplash;
        }

#if UNITY_IOS
        /// <summary>
        /// IOS  个性化模板开屏广告
        /// </summary>
        public BUExpressSplashAd ExpressSplashAd;
#endif
        /// <summary>
        /// Android 个性化模板开屏广告
        /// </summary>
        public BUSplashAd SplashAd;

        public void LoadExpressSplashAd()
        {

            var adSlot = new AdSlot.Builder()
#if UNITY_IOS
            .SetCodeId(UnionAdParam.ExpressSplashIOSId)
#else
            .SetCodeId(UnionAdParam.ExpressSplashAndroidId)
#endif
            .SetImageAcceptedSize(1080, 1920)
                .SetExpressViewAcceptedSize(UnityEngine.Screen.width, UnityEngine.Screen.height)
                .Build();
#if UNITY_IOS
           this.AdNative.LoadExpressSplashAd(adSlot, new ExpressSplashAdListener(this));
#else
            this.AdNative.LoadSplashAd(adSlot, new SplashAdListener(this, CurrentActivity, SplashAdManager));
#endif

        }

        public void Dsetory()
        {
#if UNITY_IOS
this.ExpressSplashAd.Dispose();
        this.ExpressSplashAd = null;
#else
            if (this.SplashAd != null)
            {
                this.SplashAd = null;
            }
#endif
        }

    }

    public class ExpressSplashAdListener : ISplashAdListener
    {
        private ExpressSplash expressSplash;

        public ExpressSplashAdListener(ExpressSplash expressSplash)
        {
            this.expressSplash = expressSplash;
        }

        public void OnError(int code, string message)
        {
            Debug.Log("加载个性化开屏广告错误" + message + "错误码" + code);
        }

        public void OnSplashAdLoad(BUSplashAd ad)
        {
#if UNITY_IOS
        if (ad != null)
        {
                this.expressSplash.ExpressSplashAd = ad as BUExpressSplashAd;
                Debug.Log("expressSplash load Onsucc:");
                this.expressSplash.ExpressSplashAd.SetSplashInteractionListener(new ExpressSplashAdInteractionListener(this.expressSplash));
        }
#endif
        }
    }

    public class ExpressSplashAdInteractionListener : ISplashAdInteractionListener
    {
        private ExpressSplash expressSplash;

        public ExpressSplashAdInteractionListener(ExpressSplash expressSplash)
        {
            this.expressSplash = expressSplash;
        }

        /// <summary>
        /// Invoke when the Ad is clicked.
        /// </summary>
        public void OnAdClicked(int type)
        {
            Debug.Log("expressSplash Ad OnAdClicked");
        }

        /// <summary>
        /// Invoke when the Ad is shown.
        /// </summary>
        public void OnAdShow(int type)
        {
            Debug.Log("expressSplash Ad OnAdShow");
        }

        /// <summary>
        /// Invoke when the Ad is skipped.
        /// </summary>
        public void OnAdSkip()
        {
            Debug.Log("expressSplash Ad OnAdSkip");
        }

        /// <summary>
        /// Invoke when the Ad time over.
        /// </summary>
        public void OnAdTimeOver()
        {
            Debug.Log("expressSplash Ad OnAdTimeOver");
        }

        public void OnAdClose()
        {
            Debug.Log("expressSplash Ad OnAdClose");
#if UNITY_IOS
            this.expressSplash.ExpressSplashAd = null;
#endif
        }

    }
}

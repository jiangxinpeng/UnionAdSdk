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
    /// 全屏视频广告   
    /// Android使用FullScreenVideo  IOS使用ExpressFullScreenVideo
    /// </summary>
    public class FullScreenVideo : AdBase
    {
        private static FullScreenVideo fullScreen;
        public static FullScreenVideo GetFullScreenVideo()
        {
            if (fullScreen==null)
            {
                fullScreen = new FullScreenVideo();
            }

            return fullScreen;
        }

        /// <summary>
        /// Android 全屏视频广告对象
        /// </summary>
        public FullScreenVideoAd FullScreenVideoAd;
#if UNITY_IOS
        /// <summary>
        /// IOS 全屏视频广告对象
        /// </summary>
        public ExpressFullScreenVideoAd ExpressFullScreenVideoAd;
#endif
        /// <summary>
        /// 加载全屏视频广告
        /// </summary>
        private void LoadFullScreenVideoAd(bool isShow)
        {
#if UNITY_IOS
            if(this.ExpressFullScreenVideoAd !=null)
            {
                Debug.LogError("广告已经加载");
                return;
            }
#else
            if (this.FullScreenVideoAd != null)
            {
                Debug.LogError("广告已经加载");
                if (isShow)
                {
                    ShowFullScreenVideoAd();
                }
                return;
            }
#endif

            var adSlot = new AdSlot.Builder()
#if UNITY_IOS
                             .SetCodeId(UnionAdParam.FullScreenVideoIOSId)
#else
                             .SetCodeId(UnionAdParam.FullScreenVideoAndroidId)
#endif
                             .SetSupportDeepLink(true)
                                 .SetImageAcceptedSize(1080, 1920)
                                 .SetOrientation(AdOrientation.Vertical)
                                 .Build();

#if UNITY_IOS
            this.AdNative.LoadExpressFullScreenVideoAd(adSlot, new ExpressFullScreenVideoAdListener(this,isShow));
#else
            this.AdNative.LoadFullScreenVideoAd(adSlot, new FullScreenVideoAdListener(this, isShow));
#endif

        }

        /// <summary>
        /// 展示全屏视频广告
        /// </summary>
        public void ShowFullScreenVideoAd()
        {
#if UNITY_IOS
       if (this.ExpressFullScreenVideoAd == null)
        {
            Debug.LogError("请先加载广告");
            return;
        }

        if (this.ExpressFullScreenVideoAd.IsDownloaded == true)
        {
            this.ExpressFullScreenVideoAd.ShowFullScreenVideoAd();
        }
#else
            if (this.FullScreenVideoAd == null)
            {
                Debug.LogError("请先加载广告");
                return;
            }

            if (this.FullScreenVideoAd.IsDownloaded == true)
            {
                this.FullScreenVideoAd.ShowFullScreenVideoAd();
            }
#endif
        }

        public void LoadAndShowFullScreenVideoAd()
        {
            LoadFullScreenVideoAd(true);
        }

        public void Destory()
        {
#if UNITY_IOS
              this.ExpressFullScreenVideoAd.Dispose();
              this.ExpressFullScreenVideoAd = null;
#else
            if (this.FullScreenVideoAd != null)
            {
                this.FullScreenVideoAd = null;
            }
#endif
        }
    }

#region Android设备的回调
    /// <summary>
    ///全屏视频的加载回调
    /// </summary>
    public class FullScreenVideoAdListener : IFullScreenVideoAdListener
    {
        private FullScreenVideo fullScreenVideo;
        private bool isShow;

        public FullScreenVideoAdListener(AdBase ad, bool isShow)
        {
            if (ad is FullScreenVideo)
            {
                this.fullScreenVideo = ad as FullScreenVideo;
            }

            this.isShow = isShow;
        }

        public void OnError(int code, string message)
        {
            Debug.LogError("OnFullScreenError: " + message + "erroCode：" + code);
        }

        public void OnFullScreenVideoAdLoad(FullScreenVideoAd ad)
        {
            Debug.Log("OnFullScreenAdLoad");
            ad.SetFullScreenVideoAdInteractionListener(
                new FullScreenAdInteractionListener(this.fullScreenVideo));
            ad.SetDownloadListener(
                new AppDownloadListener(this.fullScreenVideo));

            this.fullScreenVideo.FullScreenVideoAd = ad;
        }

        // iOS
        public void OnExpressFullScreenVideoAdLoad(ExpressFullScreenVideoAd ad)
        {
            // rewrite
        }
        public void OnFullScreenVideoCached()
        {
            Debug.Log("OnFullScreenVideoCached");
            if (this.fullScreenVideo.FullScreenVideoAd != null)
            {
                this.fullScreenVideo.FullScreenVideoAd.IsDownloaded = true;
            }

            if (isShow)
            {
                this.fullScreenVideo.ShowFullScreenVideoAd();
            }
        }
    }
#endregion


#region IOS设备的回调
    public class ExpressFullScreenVideoAdListener : IFullScreenVideoAdListener
    {
        private FullScreenVideo fullScreenVideo;
        private bool isShow;

        public ExpressFullScreenVideoAdListener(FullScreenVideo fullScreenVideo, bool isShow)
        {
            this.fullScreenVideo = fullScreenVideo;
            this.isShow = isShow;
        }

        public void OnError(int code, string message)
        {
            Debug.LogError("OnFullScreenError: " + message + "errCode" + code);
        }

        public void OnFullScreenVideoAdLoad(FullScreenVideoAd ad)
        {
            //Debug.Log("OnFullScreenAdLoad");

            //ad.SetFullScreenVideoAdInteractionListener(
            //    new FullScreenAdInteractionListener(this.example));
            //ad.SetDownloadListener(
            //    new AppDownloadListener(this.example));

            //this.example.fullScreenVideoAd = ad;
        }

        // iOS
        public void OnExpressFullScreenVideoAdLoad(ExpressFullScreenVideoAd ad)
        {
#if UNITY_IOS
            Debug.Log("OnExpressFullScreenAdLoad");

            ad.SetFullScreenVideoAdInteractionListener(
                new FullScreenAdInteractionListener(this.fullScreenVideo));
            //ad.SetDownloadListener(
            //    new AppDownloadListener(this.example));

            this.fullScreenVideo.ExpressFullScreenVideoAd = ad;
#else
#endif
        }

        public void OnFullScreenVideoCached()
        {
            Debug.Log("OnFullScreenVideoCached");
#if UNITY_IOS
       if (this.fullScreenVideo.ExpressFullScreenVideoAd != null)
            {
                this.fullScreenVideo.IsDownloaded = true;
            }

            if(isShow)
            {
             this.fullScreenVideo.ShowFullScreenVideoAd();
            }
#endif
        }
    }

#endregion


    /// <summary>
    /// 全屏视屏广告交互回调
    /// </summary>
    public class FullScreenAdInteractionListener : IFullScreenVideoAdInteractionListener
    {
        private FullScreenVideo fullScreen;

        public FullScreenAdInteractionListener(FullScreenVideo fullScreen)
        {
            this.fullScreen = fullScreen;
        }

        public void OnAdShow()
        {
            Debug.Log("fullScreenVideoAd show");
        }

        public void OnAdVideoBarClick()
        {
            Debug.Log("fullScreenVideoAd bar click");
        }

        public void OnAdClose()
        {
            Debug.Log("fullScreenVideoAd close");
            this.fullScreen.FullScreenVideoAd = null;
            //#if UNITY_IOS
            //            this.example.expressFullScreenVideoAd = null;
            //#endif
        }

        public void OnVideoComplete()
        {
            Debug.Log("fullScreenVideoAd complete");
        }

        public void OnVideoError()
        {
            Debug.Log("fullScreenVideoAd OnVideoError");
        }

        public void OnSkippedVideo()
        {
            Debug.Log("fullScreenVideoAd OnSkippedVideo");
        }
    }
}


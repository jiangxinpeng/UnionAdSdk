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
    /// 激励视频
    /// Android使用RewardVideoAd  IOS使用ExpressRewardVideoAd
    /// </summary>
    public class RewardVideo : AdBase
    {
        private static RewardVideo rewardVideo;
        public static RewardVideo GetRewardVideo()
        {
            if (rewardVideo == null)
            {
                rewardVideo = new RewardVideo();
            }

            return rewardVideo;
        }

        /// <summary>
        /// Android端 激励视频广告对象
        /// </summary>
        public RewardVideoAd RewardVideoAd;
#if UNITY_IOS
        /// <summary>
        /// IOS端 激励视频广告对象
        /// </summary>
        public ExpressRewardVideoAd ExpressRewardAd;
#endif

        /// <summary>
        /// 加载激励视频广告
        /// </summary>
        private void LoadRewardAd<T>(Action<T> callback, T t, bool isShow)
        {
#if UNITY_IOS

#else
            if (this.RewardVideoAd != null)
            {
                Debug.LogError("广告已经加载");
                if (isShow)
                {
                    ShowRewardVideo();
                }
                return;
            }
#endif

            var adSlot = new AdSlot.Builder()
#if UNITY_IOS
            .SetCodeId(UnionAdParam.RewardVideoIOSId)
#else
            .SetCodeId(UnionAdParam.RewardVideoAndroidId)
#endif
            .SetSupportDeepLink(true)
                           .SetImageAcceptedSize(Screen.width, Screen.height)
                           .SetRewardName("金币") // 奖励的名称
                           .SetRewardAmount(3) // 奖励的数量
                           .SetUserID("user123") // 用户id,必传参数
                           .SetMediaExtra("media_extra") // 附加参数，可选
                           .SetOrientation(AdOrientation.Vertical) // 必填参数，期望视频的播放方向
                           .Build();
#if UNITY_IOS
              this.AdNative.LoadExpressRewardAd(
            adSlot, new ExpressRewardVideoAdListener<T>(this, successCallback, t,isShow));
#else
            this.AdNative.LoadRewardVideoAd(adSlot, new RewardVideoAdListener<T>(this, callback, t, isShow));
#endif
        }

        /// <summary>
        /// 展示激励视频广告
        /// </summary>
        public void ShowRewardVideo()
        {
#if UNITY_IOS
        if (this.ExpressRewardAd == null)
        {
            Debug.LogError("请先加载广告");
            return;
        }

        if (this.ExpressRewardAd.IsDownloaded == true)
        {
            this.ExpressRewardAd.ShowRewardVideoAd();
        }
#else
            if (this.RewardVideoAd == null)
            {
                Debug.LogError("请先加载广告");
                return;
            }

            if (this.RewardVideoAd.IsDownloaded == true)
            {
                this.RewardVideoAd.ShowRewardVideoAd();
            }
#endif

        }

        public void LoadAndShowRewardVideo<T>(Action<T> callback, T t)
        {
            LoadRewardAd(callback, t, true);
        }

        public void Destory()
        {
#if UNITY_IOS
             this.ExpressRewardAd.Dispose();
        this.ExpressRewardAd = null;
#else
            if (this.RewardVideoAd != null)
            {
                this.RewardVideoAd = null;
            }
#endif
        }

    }



#region Android  回调
    public class RewardVideoAdListener<T> : IRewardVideoAdListener
    {
        private RewardVideo rewardVideo;
        private Action<T> successCallback;
        private T t;
        private bool isShow;

        public RewardVideoAdListener(RewardVideo rewardVideo, Action<T> successCallback, T t, bool isShow)
        {
            this.rewardVideo = rewardVideo;
            this.successCallback = successCallback;
            this.t = t;
            this.isShow = isShow;
        }

        public void OnError(int code, string message)
        {
            Debug.LogError("OnRewardError: " + message);
        }

        /// <summary>
        /// 加载激励视频广告成功 表示可以在线播放  并没有本地视频缓存
        /// </summary>
        /// <param name="ad"></param>
        public void OnRewardVideoAdLoad(RewardVideoAd ad)
        {
            Debug.Log("OnRewardVideoAdLoad");

            ad.SetRewardAdInteractionListener(
                new RewardAdInteractionListener<T>(this.rewardVideo, successCallback, t));
            ad.SetDownloadListener(
                new AppDownloadListener(this.rewardVideo));

            this.rewardVideo.RewardVideoAd = ad;
        }

        public void OnExpressRewardVideoAdLoad(ExpressRewardVideoAd ad)
        {
        }

        public void OnRewardVideoCached()
        {
            Debug.Log("OnRewardVideoCached");

            if (this.rewardVideo.RewardVideoAd != null)
            {
                this.rewardVideo.RewardVideoAd.IsDownloaded = true;
            }

            if (isShow)
            {
                this.rewardVideo.ShowRewardVideo();
            }
        }
    }
#endregion

#region IOS回调
    class ExpressRewardVideoAdListener<T> : IRewardVideoAdListener
    {
        private RewardVideo rewardVideo;
        private Action<T> successCallback;
        private T t;
        private bool isShow;

        public ExpressRewardVideoAdListener(RewardVideo rewardVideo, Action<T> successCallback, T t, bool isShow)
        {
            this.rewardVideo = rewardVideo;
            this.successCallback = successCallback;
            this.t = t;
            this.isShow = isShow;
        }

        public void OnError(int code, string message)
        {
            Debug.LogError("OnRewardError: " + message + "errCode" + code);
        }

        public void OnRewardVideoAdLoad(RewardVideoAd ad)
        {
            //Debug.Log("OnRewardVideoAdLoad");

            //ad.SetRewardAdInteractionListener(
            //    new RewardAdInteractionListener<T>(this.adComponent, successCallback, t));

            //this.adComponent.RewardAd = ad;
        }

        // iOS
        public void OnExpressRewardVideoAdLoad(ExpressRewardVideoAd ad)
        {
#if UNITY_IOS
            Debug.Log("OnRewardExpressVideoAdLoad");

            ad.SetRewardAdInteractionListener(
                new RewardAdInteractionListener<T>(this.rewardVideo, successCallback, t));
            this.rewardVideo.ExpressRewardAd = ad;
#else
#endif
        }

        public void OnRewardVideoCached()
        {
            Debug.Log("OnExpressRewardVideoCached");
#if UNITY_IOS
         if (this.rewardVideo.ExpressRewardAd != null)
            {
                this.rewardVideo.ExpressRewardAd.IsDownloaded = true;
            }

             if (isShow)
            {
                this.rewardVideo.ShowRewardVideo();
            }
#endif

        }
    }
#endregion



    class RewardAdInteractionListener<T> : IRewardAdInteractionListener
    {
        private RewardVideo rewardVideo;
        private Action<T> successCallback;
        private T t;

        public RewardAdInteractionListener(RewardVideo rewardVideo, Action<T> successCallback, T t)
        {
            this.rewardVideo = rewardVideo;
            this.successCallback = successCallback;
            this.t = t;
        }

        public void OnAdShow()
        {

        }

        public void OnAdVideoBarClick()
        {

        }

        public void OnAdClose()
        {
            Debug.Log("激励视频关闭");
#if UNITY_IOS
            if (this.adComponent.RewardAd != null)
            {
                this.adComponent.RewardAd.Dispose();
                this.adComponent.RewardAd = null;

                this.adComponent.ExpressRewardAd.Dispose();
                this.adComponent.ExpressRewardAd = null;
            }
#else
            if (this.rewardVideo.RewardVideoAd != null)
            {
                this.rewardVideo.RewardVideoAd = null;
            }
#endif

            //#if UNITY_IOS
            //            this.adComponent.expressRewardAd = null;
            //#endif
        }

        public void OnVideoComplete()
        {
            Debug.Log("激励视频完成");
        }

        public void OnVideoError()
        {
            Debug.LogError("激励视频播放失败");
        }

        public void OnRewardVerify(
            bool rewardVerify, int rewardAmount, string rewardName)
        {
            Debug.LogError("激励视频播放成功，执行成功回调");
            //Debug.Log("verify:" + rewardVerify + " amount:" + rewardAmount +
            //    " name:" + rewardName);
            //this.example.information.text =
            //    "verify:" + rewardVerify + " amount:" + rewardAmount +
            //    " name:" + rewardName;
            successCallback(t);
        }
    }
}

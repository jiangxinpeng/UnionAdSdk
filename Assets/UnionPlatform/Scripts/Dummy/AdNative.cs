//------------------------------------------------------------------------------
// Copyright (c) 2018-2019 Beijing Bytedance Technology Co., Ltd.
// All Right Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.
//------------------------------------------------------------------------------

namespace ByteDance.Union
{
#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IOS)
    using UnityEngine;

    /// <summary>
    /// 加载广告的入口  用户获取广告
    /// </summary>
    public sealed class AdNative
    {
        /// <summary>
        /// 加载feed流广告
        /// </summary>
        public void LoadFeedAd(AdSlot adSlot, IFeedAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// 加载竖版视频流广告
        /// </summary>
        public void LoadDrawFeedAd(AdSlot adSlot, IDrawFeedAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// 加载原生Banner广告
        /// </summary>
        public void LoadNativeAd(AdSlot adSlot, INativeAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// 加载模板Banner
        /// </summary>
        public void LoadBannerAd(AdSlot adSlot, IBannerAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// 加载模板插屏
        /// </summary>
        public void LoadInteractionAd(
            AdSlot adSlot, IInteractionAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// 加载开屏广告  可设置超时时间
        /// specify timeout.
        /// </summary>
        public void LoadSplashAd(
            AdSlot adSlot, ISplashAdListener listener, int timeOut)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// 加载开屏广告
        /// </summary>
        public void LoadSplashAd(AdSlot adSlot, ISplashAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        ///加载个性化的开屏广告
        /// </summary>
        public void LoadExpressSplashAd(AdSlot adSlot, ISplashAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// 加载激励视屏广告
        /// </summary>
        public void LoadRewardVideoAd(
            AdSlot adSlot, IRewardVideoAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// 加载全屏视频广告
        /// </summary>
        public void LoadFullScreenVideoAd(
            AdSlot adSlot, IFullScreenVideoAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// 加载个性化模板激励视频广告
        /// </summary>
        /// <param name="adSlot"></param>
        /// <param name="listener"></param>
        public void LoadExpressRewardAd(
            AdSlot adSlot, IRewardVideoAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// 加载个性化模板全屏视频广告
        /// </summary>
        /// <param name="adSlot"></param>
        /// <param name="listener"></param>
        public void LoadExpressFullScreenVideoAd(
           AdSlot adSlot, IFullScreenVideoAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// 加载个性化模板原生广告
        /// </summary>
        /// <param name="adSlot"></param>
        /// <param name="listener"></param>
        public void LoadNativeExpressAd(
            AdSlot adSlot, IExpressAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// 加载个性化模板插屏广告
        /// </summary>
        /// <param name="adSlot"></param>
        /// <param name="listener"></param>
        public void LoadExpressInterstitialAd(
            AdSlot adSlot, IExpressAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// 加载个性化模板Banner广告
        /// </summary>
        /// <param name="adSlot"></param>
        /// <param name="listener"></param>
        public void LoadExpressBannerAd(
            AdSlot adSlot, IExpressAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }
    }
#endif
}

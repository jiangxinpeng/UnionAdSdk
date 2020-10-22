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
    /// ���ع������  �û���ȡ���
    /// </summary>
    public sealed class AdNative
    {
        /// <summary>
        /// ����feed�����
        /// </summary>
        public void LoadFeedAd(AdSlot adSlot, IFeedAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// ����������Ƶ�����
        /// </summary>
        public void LoadDrawFeedAd(AdSlot adSlot, IDrawFeedAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// ����ԭ��Banner���
        /// </summary>
        public void LoadNativeAd(AdSlot adSlot, INativeAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// ����ģ��Banner
        /// </summary>
        public void LoadBannerAd(AdSlot adSlot, IBannerAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// ����ģ�����
        /// </summary>
        public void LoadInteractionAd(
            AdSlot adSlot, IInteractionAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// ���ؿ������  �����ó�ʱʱ��
        /// specify timeout.
        /// </summary>
        public void LoadSplashAd(
            AdSlot adSlot, ISplashAdListener listener, int timeOut)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// ���ؿ������
        /// </summary>
        public void LoadSplashAd(AdSlot adSlot, ISplashAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        ///���ظ��Ի��Ŀ������
        /// </summary>
        public void LoadExpressSplashAd(AdSlot adSlot, ISplashAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// ���ؼ����������
        /// </summary>
        public void LoadRewardVideoAd(
            AdSlot adSlot, IRewardVideoAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// ����ȫ����Ƶ���
        /// </summary>
        public void LoadFullScreenVideoAd(
            AdSlot adSlot, IFullScreenVideoAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// ���ظ��Ի�ģ�弤����Ƶ���
        /// </summary>
        /// <param name="adSlot"></param>
        /// <param name="listener"></param>
        public void LoadExpressRewardAd(
            AdSlot adSlot, IRewardVideoAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// ���ظ��Ի�ģ��ȫ����Ƶ���
        /// </summary>
        /// <param name="adSlot"></param>
        /// <param name="listener"></param>
        public void LoadExpressFullScreenVideoAd(
           AdSlot adSlot, IFullScreenVideoAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// ���ظ��Ի�ģ��ԭ�����
        /// </summary>
        /// <param name="adSlot"></param>
        /// <param name="listener"></param>
        public void LoadNativeExpressAd(
            AdSlot adSlot, IExpressAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// ���ظ��Ի�ģ��������
        /// </summary>
        /// <param name="adSlot"></param>
        /// <param name="listener"></param>
        public void LoadExpressInterstitialAd(
            AdSlot adSlot, IExpressAdListener listener)
        {
            listener.OnError(0, "Not Support on this platform");
        }

        /// <summary>
        /// ���ظ��Ի�ģ��Banner���
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

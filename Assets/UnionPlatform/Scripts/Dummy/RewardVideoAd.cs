//------------------------------------------------------------------------------
// Copyright (c) 2018-2019 Beijing Bytedance Technology Co., Ltd.
// All Right Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.
//------------------------------------------------------------------------------

namespace ByteDance.Union
{
#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IOS)
    using System;
    using UnityEngine;

    /// <summary>
    /// 激励视频广告
    /// </summary>
    public sealed class RewardVideoAd : IDisposable
    {
        public bool IsDownloaded;

        /// <inheritdoc/>
        public void Dispose()
        {
        }

        /// <summary>
        /// 设置广告交互监听
        /// </summary>
        public void SetRewardAdInteractionListener(
            IRewardAdInteractionListener listener)
        {
        }

        /// <summary>
        ///设置广告监听下载 Sets the download listener.
        /// </summary>
        public void SetDownloadListener(IAppDownloadListener listener)
        {
        }

        /// <summary>
        ///获取广告交互类型
        /// </summary>
        public int GetInteractionType()
        {
            return 0;
        }

        /// <summary>
        /// 展示激励视频广告
        /// </summary>
        public void ShowRewardVideoAd()
        {
        }

        /// <summary>
        /// 展示是否下载bar
        /// </summary>
        public void SetShowDownLoadBar(bool show)
        {
        }
    }
#endif
}

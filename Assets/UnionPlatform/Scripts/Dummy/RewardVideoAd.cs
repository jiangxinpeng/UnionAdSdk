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
    /// ������Ƶ���
    /// </summary>
    public sealed class RewardVideoAd : IDisposable
    {
        public bool IsDownloaded;

        /// <inheritdoc/>
        public void Dispose()
        {
        }

        /// <summary>
        /// ���ù�潻������
        /// </summary>
        public void SetRewardAdInteractionListener(
            IRewardAdInteractionListener listener)
        {
        }

        /// <summary>
        ///���ù��������� Sets the download listener.
        /// </summary>
        public void SetDownloadListener(IAppDownloadListener listener)
        {
        }

        /// <summary>
        ///��ȡ��潻������
        /// </summary>
        public int GetInteractionType()
        {
            return 0;
        }

        /// <summary>
        /// չʾ������Ƶ���
        /// </summary>
        public void ShowRewardVideoAd()
        {
        }

        /// <summary>
        /// չʾ�Ƿ�����bar
        /// </summary>
        public void SetShowDownLoadBar(bool show)
        {
        }
    }
#endif
}

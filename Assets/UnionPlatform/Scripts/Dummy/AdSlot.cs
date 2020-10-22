//------------------------------------------------------------------------------
// Copyright (c) 2018-2019 Beijing Bytedance Technology Co., Ltd.
// All Right Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.
//------------------------------------------------------------------------------

namespace ByteDance.Union
{
#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IOS)
    /// <summary>
    /// 加载广告时需要设置的广告信息
    /// </summary>
    public sealed class AdSlot
    {
        /// <summary>
        /// The builder used to build an Ad slot.
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// 设置CodeId
            /// </summary>
            public Builder SetCodeId(string codeId)
            {
                return this;
            }

            /// <summary>
            /// 必选参数  设置广告图片的最大尺寸和期望的图片宽高比  px
            /// 原生广告和你选择的尺寸会有差异
            /// </summary>
            public Builder SetImageAcceptedSize(int width, int height)
            {
                return this;
            }

            /// <summary>
            /// 个性化模板、插屏、Banner必选参数设置期望的个性化模板广告的大小   dp
            /// </summary>
            /// <returns>The Builder.</returns>
            /// <param name="width">Width.</param>
            /// <param name="height">Height.</param>
            public Builder SetExpressViewAcceptedSize(float width, float height)
            {
                return this;
            }

            /// <summary>
            ///可选参数 是否支持deeLink
            /// </summary>
            public Builder SetSupportDeepLink(bool support)
            {
                return this;
            }

            /// <summary>
            ///可选参数  针对信息流广告设置每次请求的广告返回个数  最多为三个 Sets the Ad count.
            /// </summary>
            public Builder SetAdCount(int count)
            {
                return this;
            }

            /// <summary>
            /// 请求原生广告的时候需要设置 广告参数类型
            /// </summary>
            public Builder SetNativeAdType(AdSlotType type)
            {
                return this;
            }

            /// <summary>
            /// 激励视频奖励名称  针对激励视频参数
            /// </summary>
            public Builder SetRewardName(string name)
            {
                return this;
            }

            /// <summary>
            /// 激励视频奖励个数
            /// </summary>
            public Builder SetRewardAmount(int amount)
            {
                return this;
            }

            /// <summary>
            /// 用户Id  使用激励视频必传参数
            /// 用来标识用户侧唯一用户；若非服务器回调模式或不需sdk透传 可设置为空字符串
            /// </summary>
            public Builder SetUserID(string id)
            {
                return this;
            }

            /// <summary>
            /// 设置期望视频播放方向
            /// </summary>
            public Builder SetOrientation(AdOrientation orientation)
            {
                return this;
            }

            /// <summary>
            /// 激励视频奖励透传参数 
            /// </summary>
            public Builder SetMediaExtra(string extra)
            {
                return this;
            }

            /// <summary>
            /// Build the Ad slot.
            /// </summary>
            public AdSlot Build()
            {
                return new AdSlot();
            }
        }
    }
#endif
}

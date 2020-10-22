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
    /// ���ع��ʱ��Ҫ���õĹ����Ϣ
    /// </summary>
    public sealed class AdSlot
    {
        /// <summary>
        /// The builder used to build an Ad slot.
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// ����CodeId
            /// </summary>
            public Builder SetCodeId(string codeId)
            {
                return this;
            }

            /// <summary>
            /// ��ѡ����  ���ù��ͼƬ�����ߴ��������ͼƬ��߱�  px
            /// ԭ��������ѡ��ĳߴ���в���
            /// </summary>
            public Builder SetImageAcceptedSize(int width, int height)
            {
                return this;
            }

            /// <summary>
            /// ���Ի�ģ�塢������Banner��ѡ�������������ĸ��Ի�ģ����Ĵ�С   dp
            /// </summary>
            /// <returns>The Builder.</returns>
            /// <param name="width">Width.</param>
            /// <param name="height">Height.</param>
            public Builder SetExpressViewAcceptedSize(float width, float height)
            {
                return this;
            }

            /// <summary>
            ///��ѡ���� �Ƿ�֧��deeLink
            /// </summary>
            public Builder SetSupportDeepLink(bool support)
            {
                return this;
            }

            /// <summary>
            ///��ѡ����  �����Ϣ���������ÿ������Ĺ�淵�ظ���  ���Ϊ���� Sets the Ad count.
            /// </summary>
            public Builder SetAdCount(int count)
            {
                return this;
            }

            /// <summary>
            /// ����ԭ������ʱ����Ҫ���� ����������
            /// </summary>
            public Builder SetNativeAdType(AdSlotType type)
            {
                return this;
            }

            /// <summary>
            /// ������Ƶ��������  ��Լ�����Ƶ����
            /// </summary>
            public Builder SetRewardName(string name)
            {
                return this;
            }

            /// <summary>
            /// ������Ƶ��������
            /// </summary>
            public Builder SetRewardAmount(int amount)
            {
                return this;
            }

            /// <summary>
            /// �û�Id  ʹ�ü�����Ƶ�ش�����
            /// ������ʶ�û���Ψһ�û������Ƿ������ص�ģʽ����sdk͸�� ������Ϊ���ַ���
            /// </summary>
            public Builder SetUserID(string id)
            {
                return this;
            }

            /// <summary>
            /// ����������Ƶ���ŷ���
            /// </summary>
            public Builder SetOrientation(AdOrientation orientation)
            {
                return this;
            }

            /// <summary>
            /// ������Ƶ����͸������ 
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

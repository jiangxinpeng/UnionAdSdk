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

    /// <summary>
    /// The union platform SDK.
    /// </summary>
    public static class SDK
    {
        /// <summary>
        /// ��ȡ�汾��
        /// </summary>
        public static string Version
        {
            get { return "1.0.0"; }
        }

        /// <summary>
        /// ����AdNative����  ���ڼ��ع��
        /// </summary>
        public static AdNative CreateAdNative()
        {
            return new AdNative();
        }

        /// <summary>
        /// Androidƽ̨����һЩ��Ҫ��Ȩ��
        /// Ϊ�˻�ø��õĹ��Ч��  ��߼�����Ƶ��桢��������ȵ������
        /// �����ڹ������ǰ�����ʵĻ�������������
        /// �����û���һ������app���������ʱ�����������
        /// </summary>
        public static void RequestPermissionIfNecessary()
        {
        }

        /// <summary>
        /// �˳�Ӧ�õ�ʱ�Ƿ�չʾ��װӦ�öԻ���
        /// </summary>
        /// <returns>True means show dialog.</returns>
        public static bool TryShowInstallDialogWhenExit(Action onExitInstall)
        {
            return false;
        }
    }
#endif
}

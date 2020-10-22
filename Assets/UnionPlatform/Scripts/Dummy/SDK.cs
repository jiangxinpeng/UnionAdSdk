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
        /// 获取版本号
        /// </summary>
        public static string Version
        {
            get { return "1.0.0"; }
        }

        /// <summary>
        /// 创建AdNative对象  用于加载广告
        /// </summary>
        public static AdNative CreateAdNative()
        {
            return new AdNative();
        }

        /// <summary>
        /// Android平台请求一些必要的权限
        /// 为了获得更好的广告效果  提高激励视频广告、下载类广告等的填充率
        /// 建议在广告请求前，合适的机会调用这个方法
        /// 如在用户第一次启动app后的主界面时调用这个方法
        /// </summary>
        public static void RequestPermissionIfNecessary()
        {
        }

        /// <summary>
        /// 退出应用的时是否展示安装应用对话框
        /// </summary>
        /// <returns>True means show dialog.</returns>
        public static bool TryShowInstallDialogWhenExit(Action onExitInstall)
        {
            return false;
        }
    }
#endif
}

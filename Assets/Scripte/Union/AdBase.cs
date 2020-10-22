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
    /// 广告基类
    /// </summary>
    public class AdBase
    {
        public AdNative adNative;
        public AdNative AdNative
        {
            get
            {
                if (this.adNative == null)
                {
                    this.adNative = SDK.CreateAdNative();
                }
#if UNITY_ANDROID
                //SDK.RequestPermissionIfNecessary();  进入游戏的时候就要申请权限
#endif
                return this.adNative;
            }
        }

        /// <summary>
        /// 是否移除Banner  防止调用了移除Banner方法但是由于加载没有完成，而后又展示了Banner的问题
        /// </summary>
        public bool IsRemoveBanner;

        /// <summary>
        /// 当前的Activity
        /// </summary>
        private AndroidJavaObject currentActivity;
        public AndroidJavaObject CurrentActivity
        {
            get
            {
                if (currentActivity==null)
                {
                    var unityPlayer = new AndroidJavaClass(
              "com.unity3d.player.UnityPlayer");
                    currentActivity = unityPlayer.GetStatic<AndroidJavaObject>(
                   "currentActivity");
                }
                return currentActivity;
            }
        }


        /// <summary>
        ///原生Banner广告、原生插屏广告、的管理对象 
        /// </summary>
        private AndroidJavaObject nativeAdManager;
        public AndroidJavaObject NativeAdManager
        {
            get
            {
                if (nativeAdManager == null)
                {
                    var jc = new AndroidJavaClass(
                        "com.bytedance.android.NativeAdManager");
                    nativeAdManager = jc.CallStatic<AndroidJavaObject>("getNativeAdManager");
                }
                return nativeAdManager;
            }
        }

        /// <summary>
        /// Android 开屏广告对象
        /// </summary>
        private AndroidJavaObject mSplashAdManager;
        public AndroidJavaObject SplashAdManager
        {
            get
            {
                if (mSplashAdManager == null)
                {
                    var jc = new AndroidJavaClass(
               "com.bytedance.android.SplashAdManager");
                    mSplashAdManager = jc.CallStatic<AndroidJavaObject>("getSplashAdManager");
                }
                return mSplashAdManager;
            }
        }


        /// <summary>
        /// 期望图片大小
        /// 使用的地方  ExpressBanner NativeBanner
        /// </summary>
        protected Vector2 size = new Vector2(600, 90);


        /// <summary>
        /// 外部设置期望的banner尺寸大小  和实际的会有偏差
        /// </summary>
        /// <param name="vector2"></param>
        public void SetImageAcceptedSize(Vector2 vector2)
        {
            size = vector2;
        }

    }
}

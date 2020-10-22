using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Library
{
    /// <summary>
    /// IOS原生Banner、IOS原生插屏 广告交互回调
    /// </summary>
    public class NativeAdInteractionListener
    {
        private AdBase adBase;
        int type;//0:feed   1:banner
        public NativeAdInteractionListener(AdBase ad, int type)
        {
            this.adBase = ad;
        }

        public void OnAdShow()
        {
            Debug.Log("NativeAd show");
        }

        public void OnAdClicked()
        {
            Debug.Log("NativeAd click");
        }

        public void OnAdDismiss()
        {
            Debug.Log("NativeAd close");

            //释放广告资源
            switch (type)
            {
                case 0:
                    //this.example.feedAd = null;
                    break;
                case 1:
#if UNITY_IOS
                    (this.adBase as NativeBanner).BannerAd = null;
#endif
                    break;

            }
        }
    }
}

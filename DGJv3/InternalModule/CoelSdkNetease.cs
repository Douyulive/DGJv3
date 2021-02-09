using Music.SDK.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGJv3.InternalModule
{
    sealed class CoelSdkNetease : CoelSdkBaseModule
    {
        internal CoelSdkNetease()
        {
            SetPlatform(PlatformType.NeteaseMusic);
            SetInfo("网易云音乐", INFO_AUTHOR, INFO_EMAIL, INFO_VERSION, "搜索网易云音乐的歌曲");
        }
    }
}

using Music.SDK.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGJv3.InternalModule
{
    sealed class CoelSdkQQ : CoelSdkBaseModule
    {
        internal CoelSdkQQ()
        {
            SetPlatform(PlatformType.QQMusic);
            SetInfo("QQ音乐", INFO_AUTHOR, INFO_EMAIL, INFO_VERSION, "搜索QQ音乐的歌曲");
        }
    }
}

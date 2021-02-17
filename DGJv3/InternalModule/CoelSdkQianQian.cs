using Music.SDK.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGJv3.InternalModule
{
    sealed class CoelSdkQianQian : CoelSdkBaseModule
    {
        internal CoelSdkQianQian()
        {
            SetPlatform(PlatformType.QianQianMusic);
            SetInfo("千千音乐", INFO_AUTHOR, INFO_EMAIL, INFO_VERSION, "搜索千千音乐的歌曲");
        }
    }
}

using Music.SDK.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGJv3.InternalModule
{
    sealed class CoelSdkBiliBili : CoelSdkBaseModule
    {
        internal CoelSdkBiliBili()
        {
            SetPlatform(PlatformType.BiliBiliMusic);
            SetInfo("哔哩哔哩音乐", INFO_AUTHOR, INFO_EMAIL, INFO_VERSION, "搜索哔哩哔哩音乐的歌曲");
        }
    }
}

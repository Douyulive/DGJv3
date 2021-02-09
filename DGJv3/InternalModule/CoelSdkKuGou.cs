using Music.SDK.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGJv3.InternalModule
{
    sealed class CoelSdkKuGou : CoelSdkBaseModule
    {
        internal CoelSdkKuGou()
        {
            SetPlatform(PlatformType.KuGouMusic);
            SetInfo("酷狗音乐", INFO_AUTHOR, INFO_EMAIL, INFO_VERSION, "搜索酷狗音乐的歌曲");
        }
    }
}

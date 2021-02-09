using Music.SDK.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGJv3.InternalModule
{
    sealed class CoelSdkKuWo : CoelSdkBaseModule
    {
        internal CoelSdkKuWo()
        {
            SetPlatform(PlatformType.KuWoMusic);
            SetInfo("酷我音乐", INFO_AUTHOR, INFO_EMAIL, INFO_VERSION, "搜索酷我音乐的歌曲");
        }
    }
}

﻿using Music.SDK.Models;
using System;
using System.Collections.Generic;

namespace DGJv3
{
    /// <summary>
    /// 空搜索模块
    /// </summary>
    internal sealed class NullSearchModule : SearchModule
    {
        public NullSearchModule() => SetInfo("不使用", string.Empty, string.Empty, string.Empty, string.Empty);

        protected override DownloadStatus Download(SongItem songItem)
        {
            return DownloadStatus.Failed;
        }

        protected override string GetDownloadUrl(SongItem songItem)
        {
            return null;
        }

        protected override string GetLyric(SongItem songItem)
        {
            return null;
        }

        protected override string GetLyricById(string Id, string albumId = "")
        {
            return null;
        }

        protected override List<SongInfo> GetPlaylist(string keyword)
        {
            return null;
        }

        protected override SongInfo Search(string keyword)
        {
            return null;
        }
    }
}

using Music.SDK.Models;
using Music.SDK.Models.Enums;
using Music_SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGJv3.InternalModule
{
    internal class CoelSdkBaseModule : SearchModule
    {
        private PlatformType Platform = PlatformType.None;

        protected void SetPlatform(PlatformType platform) => Platform = platform;

        protected const string INFO_PREFIX = "";
        protected const string INFO_AUTHOR = "Coel Wu";
        protected const string INFO_EMAIL = "coelwu78@protonmail.com";
        protected const string INFO_VERSION = "1.0";

        internal static int RoomId = 0;

        private MusicClient Music;

        public CoelSdkBaseModule()
        {
            Music = new MusicClient();
            IsPlaylistSupported = true;
        }

        protected override SongInfo Search(string keyword)
        {
            List<SongItem> songItems = new List<SongItem>();
            try
            {
                songItems = Music.SearchSong(Platform, keyword).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Log("搜索歌曲时网络错误：" + ex.Message);
            }

            SongItem songItem = null;
            try
            {
                songItem = songItems[0];
            }
            catch (Exception ex)
            {
                Log("搜索歌曲解析数据错误：" + ex.Message);
                return null;
            }

            SongInfo songInfo;
            try
            {
                songInfo = new SongInfo(this, Platform, songItem.SongGId, songItem.SongName, songItem.SongArtistName.ToArray(), Convert.ToString(songItem.SongAlbumId));
            }
            catch (Exception ex)
            {
                Log("歌曲信息获取结果错误：" + ex.Message);
                return null;
            }

            songInfo.Lyric = GetLyric(songItem);

            return songInfo;
        }

        protected override DownloadStatus Download(SongItem item)
        {
            throw new NotImplementedException();
        }

        protected override List<SongInfo> GetPlaylist(string keyword)
        {
            try
            {
                List<SongInfo> songInfos = new List<SongInfo>();

                PlayListItem playListItem = Music.GetPlayList(Platform, long.Parse(keyword)).GetAwaiter().GetResult();
                playListItem.Songs.ForEach(songItem =>
                {
                    try
                    {
                        var songInfo = new SongInfo(this, Platform, songItem.SongGId, songItem.SongName, songItem.SongArtistName.ToArray(), Convert.ToString(songItem.SongAlbumId));

                        songInfo.Lyric = null;

                        songInfos.Add(songInfo);
                    }
                    catch (Exception)
                    {

                    }
                });

                return songInfos;
            }
            catch (Exception ex)
            {
                Log("获取歌单信息时出错 " + ex.Message);
                return null;
            }
        }

        protected override string GetDownloadUrl(SongItem songItem)
        {
            try
            {
                string url = Music.GetSongPlayUrl(Platform, songItem).GetAwaiter().GetResult();
                return url;
            }
            catch (Exception ex)
            {
                Log($"歌曲 {songItem.SongName} 疑似版权不能下载(ex:{ex.Message})");
                return null;
            }
        }

        protected override string GetLyric(SongItem songItem)
        {
            try
            {
                LyricItem lyricItem = Music.GetLyric(Platform, songItem).GetAwaiter().GetResult();
                return lyricItem.ToString();
            }
            catch (Exception ex)
            {
                Log("歌词获取错误(ex:" + ex.ToString() + ",id:" + songItem.SongGId + ")");
                return null;
            }
        }

        protected override string GetLyricById(string Id, string AlbumId = "")
        {
            try
            {
                LyricItem lyricItem = Music.GetLyricById(Platform, Id, AlbumId).GetAwaiter().GetResult();
                return lyricItem.ToString();
            }
            catch (Exception ex)
            {
                Log("歌词获取错误(ex:" + ex.ToString() + ",id:" + Id + ")");
                return null;
            }
        }

    }
}

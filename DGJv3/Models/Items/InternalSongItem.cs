using Music.SDK.Models;
using Music.SDK.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DGJv3
{
    public class InternalSongItem : SongItem, INotifyPropertyChanged
    {

        internal InternalSongItem(SongInfo songInfo, string userName)
        {
            Status = SongStatus.WaitingDownload;

            UserName = userName;

            Module = songInfo.Module;

            switch (songInfo.Platform)
            {
                case PlatformType.QQMusic:
                    SongMId = songInfo.Id;
                    break;
                case PlatformType.NeteaseMusic:
                    SongId = long.Parse(songInfo.Id);
                    break;
                case PlatformType.KuWoMusic:
                    SongId = long.Parse(songInfo.Id);
                    break;
                case PlatformType.KuGouMusic:
                    SongFileHash = songInfo.Id;
                    SongAlbumId = long.Parse(songInfo.AlbumId);
                    break;
                case PlatformType.BiliBiliMusic:
                    SongId = long.Parse(songInfo.Id);
                    break;
                default:
                    break;
            }

            SongName = songInfo.Name;
            SongArtistName = new List<string>(songInfo.Singers);
            Lyric = (songInfo.Lyric == null) ? Lrc.NoLyric : Lrc.InitLrc(songInfo.Lyric);
            Note = songInfo.Note;
        }

        /// <summary>
        /// 搜索模块名称
        /// </summary>
        public string ModuleName
        { get { return Module.ModuleName; } }

        /// <summary>
        /// 搜索模块
        /// </summary>
        internal SearchModule Module
        { get; set; }

        /// <summary>
        /// string的歌手列表
        /// </summary>
        public string ArtistsText
        {
            get
            {
                string output = "";
                foreach (string str in SongArtistName)
                    output += str + ";";
                return output;
            }
        }

        /// <summary>
        /// 点歌人
        /// </summary>
        public string UserName
        { get; internal set; }

        // /// <summary>
        /// 下载地址
        /// </summary>
        // public string DownloadURL
        // { get; internal set; }

        /// <summary>
        /// 歌曲文件储存路径
        /// </summary>
        public string FilePath
        { get; internal set; }

        /// <summary>
        /// 文本歌词
        /// </summary>
        public Lrc Lyric
        { get; internal set; }

        /// <summary>
        /// 歌曲备注
        /// </summary>
        public string Note
        { get; internal set; }

        /// <summary>
        /// 歌曲状态
        /// </summary>
        public SongStatus Status
        { get => _status; internal set => SetField(ref _status, value); }

        private SongStatus _status;

        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
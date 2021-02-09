using Music.SDK.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel;

namespace DGJv3
{
    public class SongInfo : INotifyPropertyChanged
    {
        [JsonIgnore]
        public SearchModule Module;

        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("smid")]
        public string ModuleId { get; set; }

        [JsonIgnore]
        public PlatformType Platform { get; set; }

        [JsonProperty("siid")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sing")]
        public string[] Singers { get; set; }

        [JsonIgnore]
        public string SingersText { get => string.Join(";", Singers); }

        [JsonProperty("said")]
        public string AlbumId { get; set; }

        /// <summary>
        /// Lyric存储的是这个歌曲的歌词文件，为null时，会认为是延迟获取，在下载歌曲时再通过接口尝试获取lrc
        /// </summary>
        [JsonProperty("lrc")]
        public string Lyric { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonConstructor]
        private SongInfo() { }

        public SongInfo(SearchModule module) : this(module, PlatformType.None, string.Empty, string.Empty, null, string.Empty) { }
        public SongInfo(SearchModule module, PlatformType platform, string id, string name, string[] singers, string albumId) : this(module, platform, id, name, singers, string.Empty, string.Empty) { }
        public SongInfo(SearchModule module, PlatformType platform, string id, string name, string[] singers, string albumId, string lyric) : this(module, platform, id, name, singers, lyric, string.Empty, string.Empty) { }
        public SongInfo(SearchModule module, PlatformType platform, string id, string name, string[] singers, string albumId, string lyric, string note)
        {
            Module = module;

            ModuleId = Module.UniqueId;

            Platform = platform;

            Id = id;
            Name = name;
            Singers = singers;
            AlbumId = albumId;
            Lyric = lyric;
            Note = note;
        }
    }
}

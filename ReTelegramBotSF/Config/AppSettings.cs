namespace ReTelegramBotSF.Config
{
    internal class AppSettings
    {
        /// <summary>
        /// Telegram API Token
        /// </summary>
        public string BotToken { get; set; }
        /// <summary>
        /// Folder for audio files
        /// </summary>
        public string DownloadsFolder { get; set; }
        /// <summary>
        /// Download filename
        /// </summary>
        public string AudioFileName { get; set; }
        public string InputAudioFormat { get; set; }
        public string OutputAudioFormat { get; set; }
    }
}

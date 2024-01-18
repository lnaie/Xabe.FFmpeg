﻿using System;
using System.IO;
using System.Reflection;

namespace Xabe.FFmpeg.Test
{
    internal static class Resources
    {
        internal static readonly string PngSample = GetResourceFilePath("watermark.png");
        internal static readonly string Mp4WithAudio = GetResourceFilePath("input.mp4");
        internal static readonly string Mp3 = GetResourceFilePath("audio.mp3");
        internal static readonly string Mp4 = GetResourceFilePath("mute.mp4");
        internal static readonly string MkvWithAudio = GetResourceFilePath("SampleVideo_360x240_1mb.mkv");
        internal static readonly string MkvWithSubtitles = GetResourceFilePath("mkvWithSubtitles.mkv");
        internal static readonly string MultipleStream = GetResourceFilePath("multipleStreamSample.mkv");
        internal static readonly string TsWithAudio = GetResourceFilePath("sample.ts");
        internal static readonly string FlvWithAudio = GetResourceFilePath("sample.flv");
        internal static readonly string BunnyMp4 = GetResourceFilePath("bunny.mp4");
        internal static readonly string SloMoMp4 = GetResourceFilePath("slomo.mp4");
        internal static readonly string Dll = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Xabe.FFmpeg.Test.dll");

        internal static readonly string Images = GetResourceFilePath("Images");

        internal static readonly string SubtitleSrt = GetResourceFilePath("sampleSrt.srt");

        internal static readonly string FFbinariesInfo = GetResourceFilePath("ffbinaries.json");

        internal static string GetResourceFilePath(string fileName) => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", fileName);

        internal static readonly string SbVideo1 = GetResourceFilePath("sb-video.mp4");
        internal static readonly string SbVideo2 = GetResourceFilePath("sb-agent-static.mp4");
        internal static readonly string SbImage1 = GetResourceFilePath("sb-agent.png");
    }
}

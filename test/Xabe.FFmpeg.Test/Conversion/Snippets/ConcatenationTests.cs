using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xabe.FFmpeg.Test.Common.Fixtures;
using Xunit;

namespace Xabe.FFmpeg.Test
{
    public class ConcatenationTests : IClassFixture<StorageFixture>, IClassFixture<RtspServerFixture>
    {
        public static IEnumerable<object[]> JoinFiles => new[]
        {
            new object[] {Resources.SbVideo1, Resources.SbVideo2, 9, 1080, 1080, $"-filter_complex \"[0:v][1:v]xfade=transition=fade:duration=1:offset=4[v];\" -map \"[v]\"" },
            new object[] {Resources.SbImage1, null, 0, 1080, 1080, $"-loop 1 -framerate 30 -t 5 -vf \"scale=1080:1080:force_original_aspect_ratio=increase,crop=1080:1080,format=yuv420p\" -shortest" },
        };

        [Theory]
        [MemberData(nameof(JoinFiles))]
        public async Task ConcatenateWithFilter_Test(string firstFile, string secondFile, int duration, int width, int height, string parameters) {
            Xabe.FFmpeg.FFmpeg.SetExecutablesPath("C:\\Tools\\ffmpeg\\bin");
            var output = Path.ChangeExtension(Path.GetTempFileName(), FileExtensions.Mp4);
            var result = await (await FFmpeg.Conversions.FromSnippet.Transform(output, parameters, firstFile, secondFile)).Start();

            IMediaInfo mediaInfo = await FFmpeg.GetMediaInfo(output);
            Assert.Equal(duration, mediaInfo.Duration.Seconds);
            Assert.Single(mediaInfo.VideoStreams);
            IVideoStream videoStream = mediaInfo.VideoStreams.First();
            Assert.NotNull(videoStream);
            Assert.Equal(width, videoStream.Width);
            Assert.Equal(height, videoStream.Height);
        }
    }
}

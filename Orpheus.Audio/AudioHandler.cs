using Discord.Audio;
using NAudio.Wave;
using Orpheus.Logger;

namespace Orpheus.Audio
{
    public class AudioHandler
    {
        public async Task PlayTrack(string path, IAudioClient client)
        {
            try
            {
                await MainLogger.Log("Играет" + path);
                //var naudio = WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(path));
                var naudio = WaveFormatConversionStream.CreatePcmStream(new WaveFileReader(path));

                var dstream = client.CreatePCMStream(AudioApplication.Music);
                byte[] buffer = new byte[naudio.Length];

                int rest = (int)(naudio.Length - naudio.Position);
                await naudio.ReadAsync(buffer, 0, rest);
                await dstream.WriteAsync(buffer, 0, rest);
            }
            catch (Exception e)
            {
                await MainLogger.Log(e.Message);
                if (e.InnerException != null)
                    await MainLogger.Log(e.InnerException.Message);
            }
        }
    }
}

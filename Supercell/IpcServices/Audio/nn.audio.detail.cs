using System;
using System.Runtime.InteropServices;
using System.Text;
using Common;
using PrettyPrinter;

namespace Supercell.IpcServices.Nn.Audio.Detail {
	public unsafe partial class IAudioRendererManager {
		public override Nn.Audio.Detail.IAudioRenderer OpenAudioRenderer(
			Nn.Audio.Detail.AudioRendererParameterInternal* @params, ulong _1, ulong _2, ulong _3, KObject _4, KObject _5) =>
			new IAudioRenderer(ref *@params);

		public override ulong GetWorkBufferSize(Nn.Audio.Detail.AudioRendererParameterInternal* _0) => 0x10000;
		
		public override Nn.Audio.Detail.IAudioDevice GetAudioDeviceService(ulong _0) => new IAudioDevice();
		public override Nn.Audio.Detail.IAudioRenderer OpenAudioRendererAuto(Nn.Audio.Detail.AudioRendererParameterInternal* _0, ulong _1, ulong _2, ulong _3, ulong _4, KObject _5) => throw new NotImplementedException();
		public override Nn.Audio.Detail.IAudioDevice GetAudioDeviceServiceWithRevisionInfo(ulong _0, uint _1) => throw new NotImplementedException();
	}

	public unsafe partial class IAudioRenderer {
		AudioRendererParameterInternal Params;
		MemoryPoolState[] MemoryPools;
		Voice[] Voices;
		readonly Event Event = new Event(true);

		public IAudioRenderer(ref AudioRendererParameterInternal @params) {
			Params = @params;
			MemoryPools = new MemoryPoolState[Params.EffectCount + Params.VoiceCount * 4].Construct();
			Voices = new Voice[Params.VoiceCount].Construct();
			new System.Threading.Thread(() => {
				while(true)
					if(Event.Triggered)
						System.Threading.Thread.Sleep(1000);
					else
						Event.Triggered = true;
			}).Start();
		}

		public override uint GetSampleRate() => 44100;
		public override uint GetSampleCount() => throw new NotImplementedException();
		public override uint GetMixBufferCount() => throw new NotImplementedException();
		public override uint GetState() => throw new NotImplementedException();

		public int Fake;

		public override void RequestUpdateAudioRenderer(Buffer<Nn.Audio.Detail.AudioRendererUpdateDataHeader> input,
			Buffer<Nn.Audio.Detail.AudioRendererUpdateDataHeader> output,
			Buffer<Nn.Audio.Detail.AudioRendererUpdateDataHeader> unk
		) {
			var skipBehavior = (input + 1).As<byte>() + input.Value.BehaviorSize;
			var poolsIn = skipBehavior.As<MemoryPoolIn>(input.Value.MemoryPoolSize);
			for(var i = 0; i < poolsIn.Length; ++i)
				switch(poolsIn[i].State) {
					case MemoryPoolState.RequestAttach:
						MemoryPools[i] = MemoryPoolState.Attached;
						break;
					case MemoryPoolState.RequestDetach:
						MemoryPools[i] = MemoryPoolState.Detached;
						break;
				}

			var skipResource = poolsIn.End.As<byte>() + input.Value.VoiceResourceSize;
			var voicesIn = skipResource.As<VoiceIn>(input.Value.VoiceSize);
			for(var i = 0; i < voicesIn.Length; ++i) {
				var voice = voicesIn[i];
				var cvoice = Voices[i];
				cvoice.SetAcquireState(voice.Acquired != 0);
				if(voice.Acquired == 0) continue;

				if(voice.FirstUpdate != 0) {
					// TODO: Load ADPCM context and set buffer index
					cvoice.SampleFormat = voice.SampleFormat;
					cvoice.SampleRate = voice.SampleRate;
					cvoice.ChannelsCount = voice.ChannelsCount;
				}

				cvoice.WaveBuffers[0] = voice.WaveBuffer0;
				cvoice.WaveBuffers[1] = voice.WaveBuffer1;
				cvoice.WaveBuffers[2] = voice.WaveBuffer2;
				cvoice.WaveBuffers[3] = voice.WaveBuffer3;
				cvoice.Volume = voice.Volume;
				cvoice.PlayState = voice.PlayState;
			}

			var to = output.Value = new AudioRendererUpdateDataHeader {
				Revision = 0x30564552 + (5 << 24), 
				BehaviorSize = 0xB0, 
				MemoryPoolSize = (Params.EffectCount + Params.VoiceCount * 4) * 0x10, 
				VoiceSize = Params.VoiceCount * 0x10, 
				EffectSize = Params.EffectCount * 0x10, 
				SinkSize = Params.SinkCount * 0x20, 
				PerformanceManagerSize = 0x10
			};
			output.Value.TotalSize = Marshal.SizeOf<AudioRendererUpdateDataHeader>() + to.BehaviorSize +
			                         to.MemoryPoolSize + to.VoiceSize + to.EffectSize + to.SinkSize +
			                         to.PerformanceManagerSize;
			var mpo = (output + 1).As<MemoryPoolOut>();
			for(var i = 0; i < MemoryPools.Length; ++i)
				mpo[i].State = MemoryPools[i];
			var vo = (mpo + MemoryPools.Length).As<VoiceOut>();
			for(var i = 0; i < Voices.Length; ++i)
				vo[i] = new VoiceOut { // TODO: Real values!
					PlayedSamplesCount = Fake++, 
					VoiceDropsCount = 0, 
					PlayedWaveBuffersCount = Fake / 100
				};
		}
		
		public override void Start() => "Stub hit for Nn.Audio.Detail.IAudioRenderer.Start [5]".Debug();
		public override void Stop() => "Stub hit for Nn.Audio.Detail.IAudioRenderer.Stop [6]".Debug();
		public override KObject QuerySystemEvent() => Event;
		public override void SetAudioRendererRenderingTimeLimit(uint limit) => "Stub hit for Nn.Audio.Detail.IAudioRenderer.SetAudioRendererRenderingTimeLimit [8]".Debug();
		public override uint GetAudioRendererRenderingTimeLimit() => throw new NotImplementedException();
		public override void RequestUpdateAudioRendererAuto(Buffer<Nn.Audio.Detail.AudioRendererUpdateDataHeader> _0, Buffer<Nn.Audio.Detail.AudioRendererUpdateDataHeader> _1, Buffer<Nn.Audio.Detail.AudioRendererUpdateDataHeader> _2) => throw new NotImplementedException();
		public override void ExecuteAudioRendererRendering() => "Stub hit for Nn.Audio.Detail.IAudioRenderer.ExecuteAudioRendererRendering [11]".Debug();
	}

	public partial class IAudioDevice {
		public override void ListAudioDeviceName(out uint _0, Buffer<byte> _1) => throw new NotImplementedException();
		public override void SetAudioDeviceOutputVolume(uint _0, Buffer<byte> _1) => "Stub hit for Nn.Audio.Detail.IAudioDevice.SetAudioDeviceOutputVolume [1]".Debug();
		public override uint GetAudioDeviceOutputVolume(Buffer<byte> _0) => throw new NotImplementedException();
		public override void GetActiveAudioDeviceName(Buffer<byte> _0) => throw new NotImplementedException();
		public override KObject QueryAudioDeviceSystemEvent() => new Event(true);
		
		public override uint GetActiveChannelCount() => 2;
		
		public override void ListAudioDeviceNameAuto(out uint count, Buffer<byte> buf) {
			var names = new[] {
				"AudioTvOutput",
				"AudioStereoJackOutput",
				"AudioBuiltInSpeakerOutput"
			};
			count = (uint) names.Length;
			var i = 0;
			foreach(var name in names) {
				var bytes = Encoding.ASCII.GetBytes(name + '\0');
				bytes.AsSpan().CopyTo(buf + i);
				i += bytes.Length;
			}
		}

		public override void SetAudioDeviceOutputVolumeAuto(uint _0, Buffer<byte> _1) => "Stub hit for Nn.Audio.Detail.IAudioDevice.SetAudioDeviceOutputVolumeAuto [7]".Debug();
		public override float GetAudioDeviceOutputVolumeAuto(Buffer<byte> _0) => 1f;

		public override void GetActiveAudioDeviceNameAuto(Buffer<byte> buf) =>
			Encoding.ASCII.GetBytes("AudioBuiltInSpeakerOutput\0").AsSpan().CopyTo(buf);

		public override KObject QueryAudioDeviceInputEvent() => new Event(true);
		public override KObject QueryAudioDeviceOutputEvent() => new Event(true);
	}
}
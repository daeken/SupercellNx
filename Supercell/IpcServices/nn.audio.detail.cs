using System;
using System.Runtime.InteropServices;
using PrettyPrinter;

namespace Supercell.IpcServices.Nn.Audio.Detail {
	[StructLayout(LayoutKind.Sequential, Size = 0x10, Pack = 4)]
	struct VoiceOut {
		public long PlayedSamplesCount;
		public int PlayedWaveBuffersCount, VoiceDropsCount;
	}

	enum MemoryPoolState {
		Invalid = 0,
		Unknown = 1,
		RequestDetach = 2,
		Detached = 3,
		RequestAttach = 4,
		Attached = 5,
		Released = 6
	}

	[StructLayout(LayoutKind.Sequential, Size = 0x10, Pack = 4)]
	struct MemoryPoolOut {
		public MemoryPoolState State;
	}
	
	public unsafe partial class IAudioRendererManager {
		public override Nn.Audio.Detail.IAudioRenderer OpenAudioRenderer(
			Nn.Audio.Detail.AudioRendererParameterInternal* @params, ulong _1, ulong _2, ulong _3, KObject _4, KObject _5) =>
			new IAudioRenderer(ref *@params);

		public override ulong GetWorkBufferSize(Nn.Audio.Detail.AudioRendererParameterInternal* _0) => 0x10000;
		
		public override Nn.Audio.Detail.IAudioDevice GetAudioDeviceService(ulong _0) => throw new NotImplementedException();
		public override Nn.Audio.Detail.IAudioRenderer OpenAudioRendererAuto(Nn.Audio.Detail.AudioRendererParameterInternal* _0, ulong _1, ulong _2, ulong _3, ulong _4, KObject _5) => throw new NotImplementedException();
		public override Nn.Audio.Detail.IAudioDevice GetAudioDeviceServiceWithRevisionInfo(ulong _0, uint _1) => throw new NotImplementedException();
	}

	public unsafe partial class IAudioRenderer {
		AudioRendererParameterInternal Params;

		public IAudioRenderer(ref AudioRendererParameterInternal @params) => Params = @params;
		
		public override uint GetSampleRate() => 44100;
		public override uint GetSampleCount() => throw new NotImplementedException();
		public override uint GetMixBufferCount() => throw new NotImplementedException();
		public override uint GetState() => throw new NotImplementedException();

		public override void RequestUpdateAudioRenderer(Buffer<Nn.Audio.Detail.AudioRendererUpdateDataHeader> input,
			Buffer<Nn.Audio.Detail.AudioRendererUpdateDataHeader> output,
			Buffer<Nn.Audio.Detail.AudioRendererUpdateDataHeader> unk) {
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
		}
		
		public override void Start() => "Stub hit for Nn.Audio.Detail.IAudioRenderer.Start [5]".Debug();
		public override void Stop() => "Stub hit for Nn.Audio.Detail.IAudioRenderer.Stop [6]".Debug();
		public override KObject QuerySystemEvent() => new KEvent();
		public override void SetAudioRendererRenderingTimeLimit(uint limit) => "Stub hit for Nn.Audio.Detail.IAudioRenderer.SetAudioRendererRenderingTimeLimit [8]".Debug();
		public override uint GetAudioRendererRenderingTimeLimit() => throw new NotImplementedException();
		public override void RequestUpdateAudioRendererAuto(Buffer<Nn.Audio.Detail.AudioRendererUpdateDataHeader> _0, Buffer<Nn.Audio.Detail.AudioRendererUpdateDataHeader> _1, Buffer<Nn.Audio.Detail.AudioRendererUpdateDataHeader> _2) => throw new NotImplementedException();
		public override void ExecuteAudioRendererRendering() => "Stub hit for Nn.Audio.Detail.IAudioRenderer.ExecuteAudioRendererRendering [11]".Debug();
	}
}
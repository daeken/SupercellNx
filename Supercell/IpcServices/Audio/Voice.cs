using System.Runtime.InteropServices;

namespace Supercell.IpcServices.Nn.Audio.Detail {
	public enum PlayState : byte {
		Playing = 0,
		Stopped = 1,
		Paused  = 2
	}
	
	public enum SampleFormat : byte {
		Invalid  = 0,
		PcmInt8  = 1,
		PcmInt16 = 2,
		PcmInt24 = 3,
		PcmInt32 = 4,
		PcmFloat = 5,
		Adpcm    = 6
	}

	public class AdpcmDecoder {
		public short[] Coefficients;
		public short History0, History1;
	}
	
	[StructLayout(LayoutKind.Sequential, Size = 0x38, Pack = 1)]
	public struct WaveBuffer {
		public long  Position;
		public long  Size;
		public int   FirstSampleOffset;
		public int   LastSampleOffset;
		public byte  Looping;
		public byte  LastBuffer;
		public short Unknown1A;
		public int   Unknown1C;
		public long  AdpcmLoopContextPosition;
		public long  AdpcmLoopContextSize;
		public long  Unknown30;
	}
	
	[StructLayout(LayoutKind.Sequential, Size = 0xC, Pack = 1)]
	public struct BiquadFilter {
		public byte  Enable;
		public byte  Padding;
		public short B0;
		public short B1;
		public short B2;
		public short A1;
		public short A2;
	}
	
	[StructLayout(LayoutKind.Sequential, Size = 0x10, Pack = 4)]
	public struct VoiceOut {
		public long PlayedSamplesCount;
		public int PlayedWaveBuffersCount, VoiceDropsCount;
	}

	[StructLayout(LayoutKind.Sequential, Size = 0x170, Pack = 1)]
	public struct VoiceIn {
		public int VoiceSlot, NodeId;
		public byte FirstUpdate, Acquired;
		public PlayState PlayState;
		public SampleFormat SampleFormat;
		public int SampleRate, Priority, Unk14, ChannelsCount;
		public float Pitch, Volume;
		public BiquadFilter Filter0, Filter1;
		public int AppendedWaveBuffersCount, BaseWaveBufferIndex, Unk44;
		public long AdpcmCoeffsPosition, AdpcmCoeffsSize;
		public int VoiceDestination, Padding;
		public WaveBuffer WaveBuffer0, WaveBuffer1, WaveBuffer2, WaveBuffer3;
	}

	public class Voice {
		bool Acquired;
		
		public int SampleRate, ChannelsCount;
		public float Volume;
		public PlayState PlayState;
		public SampleFormat SampleFormat;
		public AdpcmDecoder AdpcmDecoder;
		public WaveBuffer[] WaveBuffers;
		public VoiceOut OutStatus;

		public Voice() => WaveBuffers = new WaveBuffer[4];

		public void SetAcquireState(bool state) {
			if(Acquired && !state)
				Reset();
			Acquired = state;
		}

		void Reset() {}
	}
}
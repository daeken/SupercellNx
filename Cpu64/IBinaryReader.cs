namespace Cpu64 {
	public unsafe interface IBinaryReader {
		void* Load(byte[] file, ulong blockAddr);
	}
}
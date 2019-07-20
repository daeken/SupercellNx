#pragma warning disable 169, 465
using System;
using static Supercell.Globals;
namespace Supercell.IpcServices.Nn.Usb {
	public unsafe struct UsbEndpointDescriptor {
		public byte BLength;
		public byte BDescriptorType;
		public byte BEndpointAddress;
		public byte BmAttributes;
		public ushort WMaxPacketSize;
		public byte BInterval;
	}
	
	public unsafe struct UsbDeviceDescriptor {
		public byte BLength;
		public byte BDescriptorType;
		public ushort BcdUSB;
		public byte BDeviceClass;
		public byte BDeviceSubClass;
		public byte BDeviceProtocol;
		public byte BMaxPacketSize0;
		public ushort IdVendor;
		public ushort IdProduct;
		public ushort BcdDevice;
		public byte IManufacturer;
		public byte IProduct;
		public byte ISerialNumber;
		public byte BNumConfigurations;
	}
	
	public unsafe struct UsbBosDevCapabilityDescriptor {
		public byte BLength;
		public byte BDescriptorType;
		public byte BDevCapabilityType;
	}
	
	public unsafe struct UsbBosDescriptor {
		public byte BLength;
		public byte BDescriptorType;
		public ushort WTotalLength;
		public byte BNumDeviceCaps;
	}
	
	public enum UsbDeviceSpeed : uint {
		Unknown = 0x0, 
		Low = 0x1, 
		Full = 0x2, 
		High = 0x3, 
		SuperSpeed = 0x4, 
	}
	
	public unsafe struct UsbDescriptorData {
		public ushort IdVendor;
		public ushort IdProduct;
		public ushort BcdDevice;
		public fixed byte Manufacturer[32];
		public fixed byte Product[32];
		public fixed byte SerialNumber[32];
	}
	
	public unsafe struct UsbReportEntry {
		public uint UrbId;
		public uint RequestedSize;
		public uint TransferredSize;
		public uint UrbStatus;
	}
	
	public unsafe struct UsbInterfaceDescriptor {
		public byte BLength;
		public byte BDescriptorType;
		public byte BInterfaceNumber;
		public byte BAlternateSetting;
		public byte BNumEndpoints;
		public byte BInterfaceClass;
		public byte BInterfaceSubClass;
		public byte BInterfaceProtocol;
		public byte IInterface;
	}
}

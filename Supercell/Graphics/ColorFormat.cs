namespace Supercell.Graphics {
	class ColorShift {
		public const int Swizzle = 16;
		public const int DataType = 14;
		public const int Space = 32;
		public const int Component = 8;
	}

	enum ColorSwizzle {
		XYZW = 0x688 << ColorShift.Swizzle,
		ZYXW = 0x60a << ColorShift.Swizzle,
		WZYX = 0x053 << ColorShift.Swizzle,
		YZWX = 0x0d1 << ColorShift.Swizzle,
		XYZ1 = 0xa88 << ColorShift.Swizzle,
		YZW1 = 0xad1 << ColorShift.Swizzle,
		XXX1 = 0xa00 << ColorShift.Swizzle,
		XZY1 = 0xa50 << ColorShift.Swizzle,
		ZYX1 = 0xa0a << ColorShift.Swizzle,
		WZY1 = 0xa53 << ColorShift.Swizzle,
		X000 = 0x920 << ColorShift.Swizzle,
		Y000 = 0x921 << ColorShift.Swizzle,
		XY01 = 0xb08 << ColorShift.Swizzle,
		X001 = 0xb20 << ColorShift.Swizzle,
		X00X = 0x121 << ColorShift.Swizzle,
		X00Y = 0x320 << ColorShift.Swizzle,
		_0YX0 = 0x80c << ColorShift.Swizzle,
		_0ZY0 = 0x814 << ColorShift.Swizzle,
		_0XZ0 = 0x884 << ColorShift.Swizzle,
		_0X00 = 0x904 << ColorShift.Swizzle,
		_00X0 = 0x824 << ColorShift.Swizzle,
		_000X = 0x124 << ColorShift.Swizzle,
		_0XY0 = 0x844 << ColorShift.Swizzle,
		XXXY = 0x200 << ColorShift.Swizzle,
		YYYX = 0x049 << ColorShift.Swizzle
	}

	enum ColorBytePerPixel {
		Bpp1 = 1,
		Bpp2 = 2,
		Bpp4 = 4,
		Bpp8 = 8,
		Bpp16 = 16,
		Bpp24 = 24,
		Bpp32 = 32,
		Bpp48 = 48,
		Bpp64 = 64,
		Bpp96 = 96,
		Bpp128 = 128
	}

	enum ColorComponent : uint {
		X1 = (0x01 << ColorShift.Component) | ColorBytePerPixel.Bpp1,
		X2 = (0x02 << ColorShift.Component) | ColorBytePerPixel.Bpp2,
		X4 = (0x03 << ColorShift.Component) | ColorBytePerPixel.Bpp4,
		X8 = (0x04 << ColorShift.Component) | ColorBytePerPixel.Bpp8,
		Y4X4 = (0x05 << ColorShift.Component) | ColorBytePerPixel.Bpp8,
		X3Y3Z2 = (0x06 << ColorShift.Component) | ColorBytePerPixel.Bpp8,
		X8Y8 = (0x07 << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		X8Y8X8Z8 = (0x08 << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		Y8X8Z8X8 = (0x09 << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		X16 = (0x0A << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		Y2X14 = (0x0B << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		Y4X12 = (0x0C << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		Y6X10 = (0x0D << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		Y8X8 = (0x0E << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		X10 = (0x0F << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		X12 = (0x10 << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		Z5Y5X6 = (0x11 << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		X5Y6Z5 = (0x12 << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		X6Y5Z5 = (0x13 << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		X1Y5Z5W5 = (0x14 << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		X4Y4Z4W4 = (0x15 << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		X5Y1Z5W5 = (0x16 << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		X5Y5Z1W5 = (0x17 << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		X5Y5Z5W1 = (0x18 << ColorShift.Component) | ColorBytePerPixel.Bpp16,
		X8Y8Z8 = (0x19 << ColorShift.Component) | ColorBytePerPixel.Bpp24,
		X24 = (0x1A << ColorShift.Component) | ColorBytePerPixel.Bpp24,
		X32 = (0x1C << ColorShift.Component) | ColorBytePerPixel.Bpp32,
		X16Y16 = (0x1D << ColorShift.Component) | ColorBytePerPixel.Bpp32,
		X11Y11Z10 = (0x1E << ColorShift.Component) | ColorBytePerPixel.Bpp32,
		X2Y10Z10W10 = (0x20 << ColorShift.Component) | ColorBytePerPixel.Bpp32,
		X8Y8Z8W8 = (0x21 << ColorShift.Component) | ColorBytePerPixel.Bpp32,
		Y10X10 = (0x22 << ColorShift.Component) | ColorBytePerPixel.Bpp32,
		X10Y10Z10W2 = (0x23 << ColorShift.Component) | ColorBytePerPixel.Bpp32,
		Y12X12 = (0x24 << ColorShift.Component) | ColorBytePerPixel.Bpp32,
		X20Y20Z20 = (0x26 << ColorShift.Component) | ColorBytePerPixel.Bpp64,
		X16Y16Z16W16 = (0x27 << ColorShift.Component) | ColorBytePerPixel.Bpp64,
	}

	enum ColorDataType {
		Integer = 0x0 << ColorShift.DataType,
		Float = 0x1 << ColorShift.DataType,
		Stencil = 0x2 << ColorShift.DataType
	}

	enum ColorSpace : ulong {
		NonColor = 0x0L << ColorShift.Space,
		LinearRGBA = 0x1L << ColorShift.Space,
		SRGB = 0x2L << ColorShift.Space,

		RGB709 = 0x3L << ColorShift.Space,
		LinearRGB709 = 0x4L << ColorShift.Space,

		LinearScRGB = 0x5L << ColorShift.Space,

		RGB2020 = 0x6L << ColorShift.Space,
		LinearRGB2020 = 0x7L << ColorShift.Space,
		RGB2020_PQ = 0x8L << ColorShift.Space,

		ColorIndex = 0x9L << ColorShift.Space,

		YCbCr601 = 0xAL << ColorShift.Space,
		YCbCr601_RR = 0xBL << ColorShift.Space,
		YCbCr601_ER = 0xCL << ColorShift.Space,
		YCbCr709 = 0xDL << ColorShift.Space,
		YCbCr709_ER = 0xEL << ColorShift.Space,

		BayerRGGB = 0x10L << ColorShift.Space,
		BayerBGGR = 0x11L << ColorShift.Space,
		BayerGRBG = 0x12L << ColorShift.Space,
		BayerGBRG = 0x13L << ColorShift.Space,

		XYZ = 0x14L << ColorShift.Space,
	}

	enum ColorFormat : ulong {
		NonColor8 = ColorSpace.NonColor | ColorSwizzle.X000 | ColorComponent.X8 | ColorDataType.Integer,
		NonColor16 = ColorSpace.NonColor | ColorSwizzle.X000 | ColorComponent.X16 | ColorDataType.Integer,
		NonColor24 = ColorSpace.NonColor | ColorSwizzle.X000 | ColorComponent.X24 | ColorDataType.Integer,
		NonColor32 = ColorSpace.NonColor | ColorSwizzle.X000 | ColorComponent.X32 | ColorDataType.Integer,
		X4C4 = ColorSpace.NonColor | ColorSwizzle.Y000 | ColorComponent.Y4X4 | ColorDataType.Integer,
		A4L4 = ColorSpace.LinearRGBA | ColorSwizzle.YYYX | ColorComponent.Y4X4 | ColorDataType.Integer,
		A8L8 = ColorSpace.LinearRGBA | ColorSwizzle.YYYX | ColorComponent.Y8X8 | ColorDataType.Integer,
		Float_A16L16 = ColorSpace.LinearRGBA | ColorSwizzle.YYYX | ColorComponent.X16Y16 | ColorDataType.Float,
		A1B5G5R5 = ColorSpace.LinearRGBA | ColorSwizzle.WZYX | ColorComponent.X1Y5Z5W5 | ColorDataType.Integer,
		A4B4G4R4 = ColorSpace.LinearRGBA | ColorSwizzle.WZYX | ColorComponent.X4Y4Z4W4 | ColorDataType.Integer,
		A5B5G5R1 = ColorSpace.LinearRGBA | ColorSwizzle.WZYX | ColorComponent.X5Y5Z5W1 | ColorDataType.Integer,
		A2B10G10R10 = ColorSpace.LinearRGBA | ColorSwizzle.WZYX | ColorComponent.X2Y10Z10W10 | ColorDataType.Integer,
		A8B8G8R8 = ColorSpace.LinearRGBA | ColorSwizzle.WZYX | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		A16B16G16R16 = ColorSpace.LinearRGBA | ColorSwizzle.WZYX | ColorComponent.X16Y16Z16W16 | ColorDataType.Integer,

		Float_A16B16G16R16 = ColorSpace.LinearRGBA | ColorSwizzle.WZYX | ColorComponent.X16Y16Z16W16 |
		                     ColorDataType.Float,
		A1R5G5B5 = ColorSpace.LinearRGBA | ColorSwizzle.YZWX | ColorComponent.X1Y5Z5W5 | ColorDataType.Integer,
		A4R4G4B4 = ColorSpace.LinearRGBA | ColorSwizzle.YZWX | ColorComponent.X4Y4Z4W4 | ColorDataType.Integer,
		A5R1G5B5 = ColorSpace.LinearRGBA | ColorSwizzle.YZWX | ColorComponent.X5Y1Z5W5 | ColorDataType.Integer,
		A2R10G10B10 = ColorSpace.LinearRGBA | ColorSwizzle.YZWX | ColorComponent.X2Y10Z10W10 | ColorDataType.Integer,
		A8R8G8B8 = ColorSpace.LinearRGBA | ColorSwizzle.YZWX | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		A1 = ColorSpace.LinearRGBA | ColorSwizzle._000X | ColorComponent.X1 | ColorDataType.Integer,
		A2 = ColorSpace.LinearRGBA | ColorSwizzle._000X | ColorComponent.X2 | ColorDataType.Integer,
		A4 = ColorSpace.LinearRGBA | ColorSwizzle._000X | ColorComponent.X4 | ColorDataType.Integer,
		A8 = ColorSpace.LinearRGBA | ColorSwizzle._000X | ColorComponent.X8 | ColorDataType.Integer,
		A16 = ColorSpace.LinearRGBA | ColorSwizzle._000X | ColorComponent.X16 | ColorDataType.Integer,
		A32 = ColorSpace.LinearRGBA | ColorSwizzle._000X | ColorComponent.X32 | ColorDataType.Integer,
		Float_A16 = ColorSpace.LinearRGBA | ColorSwizzle._000X | ColorComponent.X16 | ColorDataType.Float,
		L4A4 = ColorSpace.LinearRGBA | ColorSwizzle.XXXY | ColorComponent.Y4X4 | ColorDataType.Integer,
		L8A8 = ColorSpace.LinearRGBA | ColorSwizzle.XXXY | ColorComponent.Y8X8 | ColorDataType.Integer,
		B4G4R4A4 = ColorSpace.LinearRGBA | ColorSwizzle.ZYXW | ColorComponent.X4Y4Z4W4 | ColorDataType.Integer,
		B5G5R1A5 = ColorSpace.LinearRGBA | ColorSwizzle.ZYXW | ColorComponent.X5Y5Z1W5 | ColorDataType.Integer,
		B5G5R5A1 = ColorSpace.LinearRGBA | ColorSwizzle.ZYXW | ColorComponent.X5Y5Z5W1 | ColorDataType.Integer,
		B8G8R8A8 = ColorSpace.LinearRGBA | ColorSwizzle.ZYXW | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		B10G10R10A2 = ColorSpace.LinearRGBA | ColorSwizzle.ZYXW | ColorComponent.X10Y10Z10W2 | ColorDataType.Integer,
		R1G5B5A5 = ColorSpace.LinearRGBA | ColorSwizzle.XYZW | ColorComponent.X1Y5Z5W5 | ColorDataType.Integer,
		R4G4B4A4 = ColorSpace.LinearRGBA | ColorSwizzle.XYZW | ColorComponent.X4Y4Z4W4 | ColorDataType.Integer,
		R5G5B5A1 = ColorSpace.LinearRGBA | ColorSwizzle.XYZW | ColorComponent.X5Y5Z5W1 | ColorDataType.Integer,
		R8G8B8A8 = ColorSpace.LinearRGBA | ColorSwizzle.XYZW | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		R10G10B10A2 = ColorSpace.LinearRGBA | ColorSwizzle.XYZW | ColorComponent.X10Y10Z10W2 | ColorDataType.Integer,
		L1 = ColorSpace.LinearRGBA | ColorSwizzle.XXX1 | ColorComponent.X1 | ColorDataType.Integer,
		L2 = ColorSpace.LinearRGBA | ColorSwizzle.XXX1 | ColorComponent.X2 | ColorDataType.Integer,
		L4 = ColorSpace.LinearRGBA | ColorSwizzle.XXX1 | ColorComponent.X4 | ColorDataType.Integer,
		L8 = ColorSpace.LinearRGBA | ColorSwizzle.XXX1 | ColorComponent.X8 | ColorDataType.Integer,
		L16 = ColorSpace.LinearRGBA | ColorSwizzle.XXX1 | ColorComponent.X16 | ColorDataType.Integer,
		L32 = ColorSpace.LinearRGBA | ColorSwizzle.XXX1 | ColorComponent.X32 | ColorDataType.Integer,
		Float_L16 = ColorSpace.LinearRGBA | ColorSwizzle.XXX1 | ColorComponent.X16 | ColorDataType.Float,
		B5G6R5 = ColorSpace.LinearRGBA | ColorSwizzle.ZYX1 | ColorComponent.X5Y6Z5 | ColorDataType.Integer,
		B6G5R5 = ColorSpace.LinearRGBA | ColorSwizzle.ZYX1 | ColorComponent.X6Y5Z5 | ColorDataType.Integer,
		B5G5R5X1 = ColorSpace.LinearRGBA | ColorSwizzle.ZYX1 | ColorComponent.X5Y5Z5W1 | ColorDataType.Integer,
		B8_G8_R8 = ColorSpace.LinearRGBA | ColorSwizzle.ZYX1 | ColorComponent.X8Y8Z8 | ColorDataType.Integer,
		B8G8R8X8 = ColorSpace.LinearRGBA | ColorSwizzle.ZYX1 | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		Float_B10G11R11 = ColorSpace.LinearRGBA | ColorSwizzle.ZYX1 | ColorComponent.X11Y11Z10 | ColorDataType.Float,
		X1B5G5R5 = ColorSpace.LinearRGBA | ColorSwizzle.WZY1 | ColorComponent.X1Y5Z5W5 | ColorDataType.Integer,
		X8B8G8R8 = ColorSpace.LinearRGBA | ColorSwizzle.WZY1 | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		X16B16G16R16 = ColorSpace.LinearRGBA | ColorSwizzle.WZY1 | ColorComponent.X16Y16Z16W16 | ColorDataType.Integer,

		Float_X16B16G16R16 = ColorSpace.LinearRGBA | ColorSwizzle.WZY1 | ColorComponent.X16Y16Z16W16 |
		                     ColorDataType.Float,
		R3G3B2 = ColorSpace.LinearRGBA | ColorSwizzle.XYZ1 | ColorComponent.X3Y3Z2 | ColorDataType.Integer,
		R5G5B6 = ColorSpace.LinearRGBA | ColorSwizzle.XYZ1 | ColorComponent.Z5Y5X6 | ColorDataType.Integer,
		R5G6B5 = ColorSpace.LinearRGBA | ColorSwizzle.XYZ1 | ColorComponent.X5Y6Z5 | ColorDataType.Integer,
		R5G5B5X1 = ColorSpace.LinearRGBA | ColorSwizzle.XYZ1 | ColorComponent.X5Y5Z5W1 | ColorDataType.Integer,
		R8_G8_B8 = ColorSpace.LinearRGBA | ColorSwizzle.XYZ1 | ColorComponent.X8Y8Z8 | ColorDataType.Integer,
		R8G8B8X8 = ColorSpace.LinearRGBA | ColorSwizzle.XYZ1 | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		X1R5G5B5 = ColorSpace.LinearRGBA | ColorSwizzle.YZW1 | ColorComponent.X1Y5Z5W5 | ColorDataType.Integer,
		X8R8G8B8 = ColorSpace.LinearRGBA | ColorSwizzle.YZW1 | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		RG8 = ColorSpace.LinearRGBA | ColorSwizzle.XY01 | ColorComponent.Y8X8 | ColorDataType.Integer,
		R16G16 = ColorSpace.LinearRGBA | ColorSwizzle.XY01 | ColorComponent.X16Y16 | ColorDataType.Integer,
		Float_R16G16 = ColorSpace.LinearRGBA | ColorSwizzle.XY01 | ColorComponent.X16Y16 | ColorDataType.Float,
		R8 = ColorSpace.LinearRGBA | ColorSwizzle.X001 | ColorComponent.X8 | ColorDataType.Integer,
		R16 = ColorSpace.LinearRGBA | ColorSwizzle.X001 | ColorComponent.X16 | ColorDataType.Integer,
		Float_R16 = ColorSpace.LinearRGBA | ColorSwizzle.X001 | ColorComponent.X16 | ColorDataType.Float,
		A2B10G10R10_sRGB = ColorSpace.SRGB | ColorSwizzle.WZYX | ColorComponent.X2Y10Z10W10 | ColorDataType.Integer,
		A8B8G8R8_sRGB = ColorSpace.SRGB | ColorSwizzle.WZYX | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		A16B16G16R16_sRGB = ColorSpace.SRGB | ColorSwizzle.WZYX | ColorComponent.X16Y16Z16W16 | ColorDataType.Integer,
		A2R10G10B10_sRGB = ColorSpace.SRGB | ColorSwizzle.YZWX | ColorComponent.X2Y10Z10W10 | ColorDataType.Integer,
		B10G10R10A2_sRGB = ColorSpace.SRGB | ColorSwizzle.ZYXW | ColorComponent.X10Y10Z10W2 | ColorDataType.Integer,
		R10G10B10A2_sRGB = ColorSpace.SRGB | ColorSwizzle.XYZW | ColorComponent.X10Y10Z10W2 | ColorDataType.Integer,
		X8B8G8R8_sRGB = ColorSpace.SRGB | ColorSwizzle.WZY1 | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		X16B16G16R16_sRGB = ColorSpace.SRGB | ColorSwizzle.WZY1 | ColorComponent.X16Y16Z16W16 | ColorDataType.Integer,
		A2B10G10R10_709 = ColorSpace.RGB709 | ColorSwizzle.WZYX | ColorComponent.X2Y10Z10W10 | ColorDataType.Integer,
		A8B8G8R8_709 = ColorSpace.RGB709 | ColorSwizzle.WZYX | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		A16B16G16R16_709 = ColorSpace.RGB709 | ColorSwizzle.WZYX | ColorComponent.X16Y16Z16W16 | ColorDataType.Integer,
		A2R10G10B10_709 = ColorSpace.RGB709 | ColorSwizzle.YZWX | ColorComponent.X2Y10Z10W10 | ColorDataType.Integer,
		B10G10R10A2_709 = ColorSpace.RGB709 | ColorSwizzle.ZYXW | ColorComponent.X10Y10Z10W2 | ColorDataType.Integer,
		R10G10B10A2_709 = ColorSpace.RGB709 | ColorSwizzle.XYZW | ColorComponent.X10Y10Z10W2 | ColorDataType.Integer,
		X8B8G8R8_709 = ColorSpace.RGB709 | ColorSwizzle.WZY1 | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		X16B16G16R16_709 = ColorSpace.RGB709 | ColorSwizzle.WZY1 | ColorComponent.X16Y16Z16W16 | ColorDataType.Integer,

		A2B10G10R10_709_Linear = ColorSpace.LinearRGB709 | ColorSwizzle.WZYX | ColorComponent.X2Y10Z10W10 |
		                         ColorDataType.Integer,

		A8B8G8R8_709_Linear =
			ColorSpace.LinearRGB709 | ColorSwizzle.WZYX | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,

		A16B16G16R16_709_Linear = ColorSpace.LinearRGB709 | ColorSwizzle.WZYX | ColorComponent.X16Y16Z16W16 |
		                          ColorDataType.Integer,

		A2R10G10B10_709_Linear = ColorSpace.LinearRGB709 | ColorSwizzle.YZWX | ColorComponent.X2Y10Z10W10 |
		                         ColorDataType.Integer,

		B10G10R10A2_709_Linear = ColorSpace.LinearRGB709 | ColorSwizzle.ZYXW | ColorComponent.X10Y10Z10W2 |
		                         ColorDataType.Integer,

		R10G10B10A2_709_Linear = ColorSpace.LinearRGB709 | ColorSwizzle.XYZW | ColorComponent.X10Y10Z10W2 |
		                         ColorDataType.Integer,

		X8B8G8R8_709_Linear =
			ColorSpace.LinearRGB709 | ColorSwizzle.WZY1 | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,

		X16B16G16R16_709_Linear = ColorSpace.LinearRGB709 | ColorSwizzle.WZY1 | ColorComponent.X16Y16Z16W16 |
		                          ColorDataType.Integer,

		Float_A16B16G16R16_scRGB_Linear = ColorSpace.LinearScRGB | ColorSwizzle.WZYX | ColorComponent.X16Y16Z16W16 |
		                                  ColorDataType.Float,
		A2B10G10R10_2020 = ColorSpace.RGB2020 | ColorSwizzle.WZYX | ColorComponent.X2Y10Z10W10 | ColorDataType.Integer,
		A8B8G8R8_2020 = ColorSpace.RGB2020 | ColorSwizzle.WZYX | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,

		A16B16G16R16_2020 =
			ColorSpace.RGB2020 | ColorSwizzle.WZYX | ColorComponent.X16Y16Z16W16 | ColorDataType.Integer,
		A2R10G10B10_2020 = ColorSpace.RGB2020 | ColorSwizzle.YZWX | ColorComponent.X2Y10Z10W10 | ColorDataType.Integer,
		B10G10R10A2_2020 = ColorSpace.RGB2020 | ColorSwizzle.ZYXW | ColorComponent.X10Y10Z10W2 | ColorDataType.Integer,
		R10G10B10A2_2020 = ColorSpace.RGB2020 | ColorSwizzle.XYZW | ColorComponent.X10Y10Z10W2 | ColorDataType.Integer,
		X8B8G8R8_2020 = ColorSpace.RGB2020 | ColorSwizzle.WZY1 | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,

		X16B16G16R16_2020 =
			ColorSpace.RGB2020 | ColorSwizzle.WZY1 | ColorComponent.X16Y16Z16W16 | ColorDataType.Integer,

		A2B10G10R10_2020_Linear = ColorSpace.LinearRGB2020 | ColorSwizzle.WZYX | ColorComponent.X2Y10Z10W10 |
		                          ColorDataType.Integer,

		A8B8G8R8_2020_Linear = ColorSpace.LinearRGB2020 | ColorSwizzle.WZYX | ColorComponent.X8Y8Z8W8 |
		                       ColorDataType.Integer,

		A16B16G16R16_2020_Linear = ColorSpace.LinearRGB2020 | ColorSwizzle.WZYX | ColorComponent.X16Y16Z16W16 |
		                           ColorDataType.Integer,

		Float_A16B16G16R16_2020_Linear = ColorSpace.LinearRGB2020 | ColorSwizzle.WZYX | ColorComponent.X16Y16Z16W16 |
		                                 ColorDataType.Float,

		A2R10G10B10_2020_Linear = ColorSpace.LinearRGB2020 | ColorSwizzle.YZWX | ColorComponent.X2Y10Z10W10 |
		                          ColorDataType.Integer,

		B10G10R10A2_2020_Linear = ColorSpace.LinearRGB2020 | ColorSwizzle.ZYXW | ColorComponent.X10Y10Z10W2 |
		                          ColorDataType.Integer,

		R10G10B10A2_2020_Linear = ColorSpace.LinearRGB2020 | ColorSwizzle.XYZW | ColorComponent.X10Y10Z10W2 |
		                          ColorDataType.Integer,

		X8B8G8R8_2020_Linear = ColorSpace.LinearRGB2020 | ColorSwizzle.WZY1 | ColorComponent.X8Y8Z8W8 |
		                       ColorDataType.Integer,

		X16B16G16R16_2020_Linear = ColorSpace.LinearRGB2020 | ColorSwizzle.WZY1 | ColorComponent.X16Y16Z16W16 |
		                           ColorDataType.Integer,

		Float_A16B16G16R16_2020_PQ = ColorSpace.RGB2020_PQ | ColorSwizzle.WZYX | ColorComponent.X16Y16Z16W16 |
		                             ColorDataType.Float,
		A4I4 = ColorSpace.ColorIndex | ColorSwizzle.X00X | ColorComponent.Y4X4 | ColorDataType.Integer,
		A8I8 = ColorSpace.ColorIndex | ColorSwizzle.X00X | ColorComponent.Y8X8 | ColorDataType.Integer,
		I4A4 = ColorSpace.ColorIndex | ColorSwizzle.X00Y | ColorComponent.Y4X4 | ColorDataType.Integer,
		I8A8 = ColorSpace.ColorIndex | ColorSwizzle.X00Y | ColorComponent.Y8X8 | ColorDataType.Integer,
		I1 = ColorSpace.ColorIndex | ColorSwizzle.X000 | ColorComponent.X1 | ColorDataType.Integer,
		I2 = ColorSpace.ColorIndex | ColorSwizzle.X000 | ColorComponent.X2 | ColorDataType.Integer,
		I4 = ColorSpace.ColorIndex | ColorSwizzle.X000 | ColorComponent.X4 | ColorDataType.Integer,
		I8 = ColorSpace.ColorIndex | ColorSwizzle.X000 | ColorComponent.X8 | ColorDataType.Integer,
		A8Y8U8V8 = ColorSpace.YCbCr601 | ColorSwizzle.YZWX | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		A16Y16U16V16 = ColorSpace.YCbCr601 | ColorSwizzle.YZWX | ColorComponent.X16Y16Z16W16 | ColorDataType.Integer,
		Y8U8V8A8 = ColorSpace.YCbCr601 | ColorSwizzle.XYZW | ColorComponent.X8Y8Z8W8 | ColorDataType.Integer,
		V8_U8 = ColorSpace.YCbCr601 | ColorSwizzle._0YX0 | ColorComponent.X8Y8 | ColorDataType.Integer,
		V8U8 = ColorSpace.YCbCr601 | ColorSwizzle._0YX0 | ColorComponent.Y8X8 | ColorDataType.Integer,
		V10U10 = ColorSpace.YCbCr601 | ColorSwizzle._0ZY0 | ColorComponent.Y10X10 | ColorDataType.Integer,
		V12U12 = ColorSpace.YCbCr601 | ColorSwizzle._0ZY0 | ColorComponent.Y12X12 | ColorDataType.Integer,
		V8 = ColorSpace.YCbCr601 | ColorSwizzle._00X0 | ColorComponent.X8 | ColorDataType.Integer,
		V10 = ColorSpace.YCbCr601 | ColorSwizzle._00X0 | ColorComponent.X10 | ColorDataType.Integer,
		V12 = ColorSpace.YCbCr601 | ColorSwizzle._00X0 | ColorComponent.X12 | ColorDataType.Integer,
		U8_V8 = ColorSpace.YCbCr601 | ColorSwizzle._0XY0 | ColorComponent.X8Y8 | ColorDataType.Integer,
		U8V8 = ColorSpace.YCbCr601 | ColorSwizzle._0XY0 | ColorComponent.Y8X8 | ColorDataType.Integer,
		U10V10 = ColorSpace.YCbCr601 | ColorSwizzle._0XZ0 | ColorComponent.Y10X10 | ColorDataType.Integer,
		U12V12 = ColorSpace.YCbCr601 | ColorSwizzle._0XZ0 | ColorComponent.Y12X12 | ColorDataType.Integer,
		U8 = ColorSpace.YCbCr601 | ColorSwizzle._0X00 | ColorComponent.X8 | ColorDataType.Integer,
		U10 = ColorSpace.YCbCr601 | ColorSwizzle._0X00 | ColorComponent.X10 | ColorDataType.Integer,
		U12 = ColorSpace.YCbCr601 | ColorSwizzle._0X00 | ColorComponent.X12 | ColorDataType.Integer,
		Y8 = ColorSpace.YCbCr601 | ColorSwizzle.X000 | ColorComponent.X8 | ColorDataType.Integer,
		Y10 = ColorSpace.YCbCr601 | ColorSwizzle.X000 | ColorComponent.X10 | ColorDataType.Integer,
		Y12 = ColorSpace.YCbCr601 | ColorSwizzle.X000 | ColorComponent.X12 | ColorDataType.Integer,
		YVYU = ColorSpace.YCbCr601 | ColorSwizzle.XZY1 | ColorComponent.X8Y8X8Z8 | ColorDataType.Integer,
		VYUY = ColorSpace.YCbCr601 | ColorSwizzle.XZY1 | ColorComponent.Y8X8Z8X8 | ColorDataType.Integer,
		UYVY = ColorSpace.YCbCr601 | ColorSwizzle.XYZ1 | ColorComponent.Y8X8Z8X8 | ColorDataType.Integer,
		YUYV = ColorSpace.YCbCr601 | ColorSwizzle.XYZ1 | ColorComponent.X8Y8X8Z8 | ColorDataType.Integer,
		Y8_U8_V8 = ColorSpace.YCbCr601 | ColorSwizzle.XYZ1 | ColorComponent.X8Y8Z8 | ColorDataType.Integer,
		V8_U8_RR = ColorSpace.YCbCr601_RR | ColorSwizzle._0YX0 | ColorComponent.X8Y8 | ColorDataType.Integer,
		V8U8_RR = ColorSpace.YCbCr601_RR | ColorSwizzle._0YX0 | ColorComponent.Y8X8 | ColorDataType.Integer,
		V8_RR = ColorSpace.YCbCr601_RR | ColorSwizzle._00X0 | ColorComponent.X8 | ColorDataType.Integer,
		U8_V8_RR = ColorSpace.YCbCr601_RR | ColorSwizzle._0XY0 | ColorComponent.X8Y8 | ColorDataType.Integer,
		U8V8_RR = ColorSpace.YCbCr601_RR | ColorSwizzle._0XY0 | ColorComponent.Y8X8 | ColorDataType.Integer,
		U8_RR = ColorSpace.YCbCr601_RR | ColorSwizzle._0X00 | ColorComponent.X8 | ColorDataType.Integer,
		Y8_RR = ColorSpace.YCbCr601_RR | ColorSwizzle.X000 | ColorComponent.X8 | ColorDataType.Integer,
		V8_U8_ER = ColorSpace.YCbCr601_ER | ColorSwizzle._0YX0 | ColorComponent.X8Y8 | ColorDataType.Integer,
		V8U8_ER = ColorSpace.YCbCr601_ER | ColorSwizzle._0YX0 | ColorComponent.Y8X8 | ColorDataType.Integer,
		V8_ER = ColorSpace.YCbCr601_ER | ColorSwizzle._00X0 | ColorComponent.X8 | ColorDataType.Integer,
		U8_V8_ER = ColorSpace.YCbCr601_ER | ColorSwizzle._0XY0 | ColorComponent.X8Y8 | ColorDataType.Integer,
		U8V8_ER = ColorSpace.YCbCr601_ER | ColorSwizzle._0XY0 | ColorComponent.Y8X8 | ColorDataType.Integer,
		U8_ER = ColorSpace.YCbCr601_ER | ColorSwizzle._0X00 | ColorComponent.X8 | ColorDataType.Integer,
		Y8_ER = ColorSpace.YCbCr601_ER | ColorSwizzle.X000 | ColorComponent.X8 | ColorDataType.Integer,
		V8_U8_709 = ColorSpace.YCbCr709 | ColorSwizzle._0YX0 | ColorComponent.X8Y8 | ColorDataType.Integer,
		V8U8_709 = ColorSpace.YCbCr709 | ColorSwizzle._0YX0 | ColorComponent.Y8X8 | ColorDataType.Integer,
		V10U10_709 = ColorSpace.YCbCr709 | ColorSwizzle._0ZY0 | ColorComponent.Y10X10 | ColorDataType.Integer,
		V12U12_709 = ColorSpace.YCbCr709 | ColorSwizzle._0ZY0 | ColorComponent.Y12X12 | ColorDataType.Integer,
		V8_709 = ColorSpace.YCbCr709 | ColorSwizzle._00X0 | ColorComponent.X8 | ColorDataType.Integer,
		V10_709 = ColorSpace.YCbCr709 | ColorSwizzle._00X0 | ColorComponent.X10 | ColorDataType.Integer,
		V12_709 = ColorSpace.YCbCr709 | ColorSwizzle._00X0 | ColorComponent.X12 | ColorDataType.Integer,
		U8_V8_709 = ColorSpace.YCbCr709 | ColorSwizzle._0XY0 | ColorComponent.X8Y8 | ColorDataType.Integer,
		U8V8_709 = ColorSpace.YCbCr709 | ColorSwizzle._0XY0 | ColorComponent.Y8X8 | ColorDataType.Integer,
		U10V10_709 = ColorSpace.YCbCr709 | ColorSwizzle._0XZ0 | ColorComponent.Y10X10 | ColorDataType.Integer,
		U12V12_709 = ColorSpace.YCbCr709 | ColorSwizzle._0XZ0 | ColorComponent.Y12X12 | ColorDataType.Integer,
		U8_709 = ColorSpace.YCbCr709 | ColorSwizzle._0X00 | ColorComponent.X8 | ColorDataType.Integer,
		U10_709 = ColorSpace.YCbCr709 | ColorSwizzle._0X00 | ColorComponent.X10 | ColorDataType.Integer,
		U12_709 = ColorSpace.YCbCr709 | ColorSwizzle._0X00 | ColorComponent.X12 | ColorDataType.Integer,
		Y8_709 = ColorSpace.YCbCr709 | ColorSwizzle.X000 | ColorComponent.X8 | ColorDataType.Integer,
		Y10_709 = ColorSpace.YCbCr709 | ColorSwizzle.X000 | ColorComponent.X10 | ColorDataType.Integer,
		Y12_709 = ColorSpace.YCbCr709 | ColorSwizzle.X000 | ColorComponent.X12 | ColorDataType.Integer,
		V8_U8_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._0YX0 | ColorComponent.X8Y8 | ColorDataType.Integer,
		V8U8_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._0YX0 | ColorComponent.Y8X8 | ColorDataType.Integer,
		V10U10_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._0ZY0 | ColorComponent.Y10X10 | ColorDataType.Integer,
		V12U12_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._0ZY0 | ColorComponent.Y12X12 | ColorDataType.Integer,
		V8_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._00X0 | ColorComponent.X8 | ColorDataType.Integer,
		V10_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._00X0 | ColorComponent.X10 | ColorDataType.Integer,
		V12_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._00X0 | ColorComponent.X12 | ColorDataType.Integer,
		U8_V8_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._0XY0 | ColorComponent.X8Y8 | ColorDataType.Integer,
		U8V8_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._0XY0 | ColorComponent.Y8X8 | ColorDataType.Integer,
		U10V10_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._0XZ0 | ColorComponent.Y10X10 | ColorDataType.Integer,
		U12V12_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._0XZ0 | ColorComponent.Y12X12 | ColorDataType.Integer,
		U8_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._0X00 | ColorComponent.X8 | ColorDataType.Integer,
		U10_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._0X00 | ColorComponent.X10 | ColorDataType.Integer,
		U12_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle._0X00 | ColorComponent.X12 | ColorDataType.Integer,
		Y8_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle.X000 | ColorComponent.X8 | ColorDataType.Integer,
		Y10_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle.X000 | ColorComponent.X10 | ColorDataType.Integer,
		Y12_709_ER = ColorSpace.YCbCr709_ER | ColorSwizzle.X000 | ColorComponent.X12 | ColorDataType.Integer,
		V10U10_2020 = ColorSpace.YCbCr709_ER | ColorSwizzle._0ZY0 | ColorComponent.Y10X10 | ColorDataType.Integer,
		V12U12_2020 = ColorSpace.YCbCr709_ER | ColorSwizzle._0ZY0 | ColorComponent.Y12X12 | ColorDataType.Integer,
		V10_2020 = ColorSpace.YCbCr709_ER | ColorSwizzle._00X0 | ColorComponent.X10 | ColorDataType.Integer,
		V12_2020 = ColorSpace.YCbCr709_ER | ColorSwizzle._00X0 | ColorComponent.X12 | ColorDataType.Integer,
		U10V10_2020 = ColorSpace.YCbCr709_ER | ColorSwizzle._0XZ0 | ColorComponent.Y10X10 | ColorDataType.Integer,
		U12V12_2020 = ColorSpace.YCbCr709_ER | ColorSwizzle._0XZ0 | ColorComponent.Y12X12 | ColorDataType.Integer,
		U10_2020 = ColorSpace.YCbCr709_ER | ColorSwizzle._0X00 | ColorComponent.X10 | ColorDataType.Integer,
		U12_2020 = ColorSpace.YCbCr709_ER | ColorSwizzle._0X00 | ColorComponent.X12 | ColorDataType.Integer,
		Y10_2020 = ColorSpace.YCbCr709_ER | ColorSwizzle.X000 | ColorComponent.X10 | ColorDataType.Integer,
		Y12_2020 = ColorSpace.YCbCr709_ER | ColorSwizzle.X000 | ColorComponent.X12 | ColorDataType.Integer,
		Bayer8RGGB = ColorSpace.BayerRGGB | ColorSwizzle.X000 | ColorComponent.X8 | ColorDataType.Integer,
		Bayer16RGGB = ColorSpace.BayerRGGB | ColorSwizzle.X000 | ColorComponent.X16 | ColorDataType.Integer,
		BayerS16RGGB = ColorSpace.BayerRGGB | ColorSwizzle.X000 | ColorComponent.X16 | ColorDataType.Stencil,
		X2Bayer14RGGB = ColorSpace.BayerRGGB | ColorSwizzle.Y000 | ColorComponent.Y2X14 | ColorDataType.Integer,
		X4Bayer12RGGB = ColorSpace.BayerRGGB | ColorSwizzle.Y000 | ColorComponent.Y4X12 | ColorDataType.Integer,
		X6Bayer10RGGB = ColorSpace.BayerRGGB | ColorSwizzle.Y000 | ColorComponent.Y6X10 | ColorDataType.Integer,
		Bayer8BGGR = ColorSpace.BayerBGGR | ColorSwizzle.X000 | ColorComponent.X8 | ColorDataType.Integer,
		Bayer16BGGR = ColorSpace.BayerBGGR | ColorSwizzle.X000 | ColorComponent.X16 | ColorDataType.Integer,
		BayerS16BGGR = ColorSpace.BayerBGGR | ColorSwizzle.X000 | ColorComponent.X16 | ColorDataType.Stencil,
		X2Bayer14BGGR = ColorSpace.BayerBGGR | ColorSwizzle.Y000 | ColorComponent.Y2X14 | ColorDataType.Integer,
		X4Bayer12BGGR = ColorSpace.BayerBGGR | ColorSwizzle.Y000 | ColorComponent.Y4X12 | ColorDataType.Integer,
		X6Bayer10BGGR = ColorSpace.BayerBGGR | ColorSwizzle.Y000 | ColorComponent.Y6X10 | ColorDataType.Integer,
		Bayer8GRBG = ColorSpace.BayerGRBG | ColorSwizzle.X000 | ColorComponent.X8 | ColorDataType.Integer,
		Bayer16GRBG = ColorSpace.BayerGRBG | ColorSwizzle.X000 | ColorComponent.X16 | ColorDataType.Integer,
		BayerS16GRBG = ColorSpace.BayerGRBG | ColorSwizzle.X000 | ColorComponent.X16 | ColorDataType.Stencil,
		X2Bayer14GRBG = ColorSpace.BayerGRBG | ColorSwizzle.Y000 | ColorComponent.Y2X14 | ColorDataType.Integer,
		X4Bayer12GRBG = ColorSpace.BayerGRBG | ColorSwizzle.Y000 | ColorComponent.Y4X12 | ColorDataType.Integer,
		X6Bayer10GRBG = ColorSpace.BayerGRBG | ColorSwizzle.Y000 | ColorComponent.Y6X10 | ColorDataType.Integer,
		Bayer8GBRG = ColorSpace.BayerGBRG | ColorSwizzle.X000 | ColorComponent.X8 | ColorDataType.Integer,
		Bayer16GBRG = ColorSpace.BayerGBRG | ColorSwizzle.X000 | ColorComponent.X16 | ColorDataType.Integer,
		BayerS16GBRG = ColorSpace.BayerGBRG | ColorSwizzle.X000 | ColorComponent.X16 | ColorDataType.Stencil,
		X2Bayer14GBRG = ColorSpace.BayerGBRG | ColorSwizzle.Y000 | ColorComponent.Y2X14 | ColorDataType.Integer,
		X4Bayer12GBRG = ColorSpace.BayerGBRG | ColorSwizzle.Y000 | ColorComponent.Y4X12 | ColorDataType.Integer,
		X6Bayer10GBRG = ColorSpace.BayerGBRG | ColorSwizzle.Y000 | ColorComponent.Y6X10 | ColorDataType.Integer,
		XYZ = ColorSpace.XYZ | ColorSwizzle.XYZ1 | ColorComponent.X20Y20Z20 | ColorDataType.Float,
	}
}
using System;

namespace ledstrip
{
    public class LedColor
    {
        public byte R { get; private set; }
        public byte G { get; private set;}
        public byte B {get; private set; }

        public LedColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public override string ToString() {
            return $"LedColor (R={R} G={G} B={B})";
        }
    }
}

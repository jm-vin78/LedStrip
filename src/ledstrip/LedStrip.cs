using Unosquare.PiGpio.NativeMethods;
using Unosquare.PiGpio.NativeEnums;

namespace ledstrip
{
    public class LedStrip
    {
        private LedColor ledColor = new LedColor(0, 0, 0);

        SystemGpio R_pin;
        SystemGpio G_pin;
        SystemGpio B_pin;
        

        public LedStrip()
        {
            Setup.GpioInitialise();

            R_pin = SystemGpio.Bcm22;
            G_pin = SystemGpio.Bcm23;
            B_pin = SystemGpio.Bcm24;

            IO.GpioSetMode(R_pin, PinMode.Output);
            IO.GpioSetMode(G_pin, PinMode.Output);
            IO.GpioSetMode(B_pin, PinMode.Output);
        }

        public void TurnOn()
        {
            SetColor(new LedColor(1, 1, 1));
        }

        public void TurnOff()
        {
            SetColor(new LedColor(0, 0, 0));
        }

        public void Edit(byte r, byte g, byte b)
        {
            SetColor(new LedColor(r, g, b));
        }

        private void SetColor(LedColor color)
        {
            ledColor = color;
            Pwm.GpioPwm((UserGpio)R_pin, ledColor.R);
            Pwm.GpioPwm((UserGpio)G_pin, ledColor.G);
            Pwm.GpioPwm((UserGpio)B_pin, ledColor.B);

            //IO.GpioWrite(R_pin, ledColor.R > 0);
            //IO.GpioWrite(G_pin, ledColor.G > 0);
            //IO.GpioWrite(B_pin, ledColor.B > 0);
        }

        public LedColor GetValues()
        {
            return ledColor;
        }
    }
}
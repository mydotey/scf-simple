using System;

namespace MyDotey.SCF.Type.String
{
    /**
    * @author koqizhao
    *
    * May 21, 2018
    */
    public class StringToByteConverter : StringConverter<byte?>
    {
        public static readonly StringToByteConverter Default = new StringToByteConverter();

        public override byte? Convert(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;

            return byte.Parse(source);
        }
    }
}
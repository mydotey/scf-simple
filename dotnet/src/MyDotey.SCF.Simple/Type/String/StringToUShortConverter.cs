using System;

namespace MyDotey.SCF.Type.String
{
    /**
    * @author koqizhao
    *
    * May 21, 2018
    */
    public class StringToUShortConverter : StringConverter<ushort?>
    {
        public static readonly StringToUShortConverter Default = new StringToUShortConverter();

        public override ushort? Convert(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;

            return ushort.Parse(source);
        }
    }
}
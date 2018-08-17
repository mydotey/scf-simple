using System;

namespace MyDotey.SCF.Facade
{
    /**
     * @author koqizhao
     *
     * May 21, 2018
     */
    public class StringProperties : StringValueProperties<string, IConfigurationManager>
    {
        public StringProperties(IConfigurationManager manager)
            : base(manager)
        {
        }
    }
}
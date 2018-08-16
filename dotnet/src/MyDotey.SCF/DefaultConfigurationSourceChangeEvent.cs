using System;

namespace MyDotey.SCF
{
    /**
     * @author koqizhao
     *
     * Jul 19, 2018
     */
    public class DefaultConfigurationSourceChangeEvent : ConfigurationSourceChangeEvent
    {
        public virtual ConfigurationSource Source { get; protected set; }
        public virtual long ChangeTime { get; protected set; }

        public DefaultConfigurationSourceChangeEvent(ConfigurationSource source)
            : this(source, DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond)
        {

        }

        public DefaultConfigurationSourceChangeEvent(ConfigurationSource source, long changeTime)
        {
            if (source == null)
                throw new ArgumentNullException("source is null");

            Source = source;
            ChangeTime = changeTime;
        }

        public override String ToString()
        {
            return string.Format("{0} {{ source: {1}, changeTime: {2} }}", GetType().Name, Source, ChangeTime);
        }
    }
}
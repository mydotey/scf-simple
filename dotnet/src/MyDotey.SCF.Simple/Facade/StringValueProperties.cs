using System;
using System.Collections.Generic;

using MyDotey.SCF.Type;
using MyDotey.SCF.Type.String;

namespace MyDotey.SCF.Facade
{
    /**
     * @author koqizhao
     *
     * May 21, 2018
     */
    public class StringValueProperties<K, M>
        where M: IConfigurationManager
    {
        private M _manager;

        public StringValueProperties(M manager)
        {
            if (manager == null)
                throw new ArgumentNullException("manager is null");
            _manager = manager;
        }

        public virtual M Manager { get { return _manager; } }

        public virtual IProperty<K, string> GetStringProperty(K key)
        {
            return GetStringProperty(key, null);
        }

        public virtual string GetStringPropertyValue(K key)
        {
            return GetStringPropertyValue(key, null);
        }

        public virtual IProperty<K, string> GetStringProperty(K key, string defaultValue)
        {
            return GetStringProperty(key, defaultValue, null);
        }

        public virtual string GetStringPropertyValue(K key, string defaultValue)
        {
            return GetStringPropertyValue(key, defaultValue, null);
        }

        public virtual IProperty<K, string> GetStringProperty(K key, string defaultValue, Func<string, string> valueFilter)
        {
            return GetProperty(key, defaultValue, StringInplaceConverter.Default, valueFilter);
        }

        public virtual string GetStringPropertyValue(K key, string defaultValue, Func<string, string> valueFilter)
        {
            return GetPropertyValue(key, defaultValue, StringInplaceConverter.Default, valueFilter);
        }

        public virtual IProperty<K, int?> GetIntProperty(K key)
        {
            return GetIntProperty(key, null);
        }

        public virtual int? GetIntPropertyValue(K key)
        {
            return GetIntPropertyValue(key, null);
        }

        public virtual IProperty<K, int?> GetIntProperty(K key, int? defaultValue)
        {
            return GetIntProperty(key, defaultValue, null);
        }

        public virtual int? GetIntPropertyValue(K key, int? defaultValue)
        {
            return GetIntPropertyValue(key, defaultValue, null);
        }

        public virtual IProperty<K, int?> GetIntProperty(K key, int? defaultValue, Func<int?, int?> valueFilter)
        {
            return GetProperty(key, defaultValue, StringToIntConverter.Default, valueFilter);
        }

        public virtual int? GetIntPropertyValue(K key, int? defaultValue, Func<int?, int?> valueFilter)
        {
            return GetPropertyValue(key, defaultValue, StringToIntConverter.Default, valueFilter);
        }

        public virtual IProperty<K, long?> GetLongProperty(K key)
        {
            return GetLongProperty(key, null);
        }

        public virtual long? GetLongPropertyValue(K key)
        {
            return GetLongPropertyValue(key, null);
        }

        public virtual IProperty<K, long?> GetLongProperty(K key, long? defaultValue)
        {
            return GetLongProperty(key, defaultValue, null);
        }

        public virtual long? GetLongPropertyValue(K key, long? defaultValue)
        {
            return GetLongPropertyValue(key, defaultValue, null);
        }

        public virtual IProperty<K, long?> GetLongProperty(K key, long? defaultValue, Func<long?, long?> valueFilter)
        {
            return GetProperty(key, defaultValue, StringToLongConverter.Default, valueFilter);
        }

        public virtual long? GetLongPropertyValue(K key, long? defaultValue, Func<long?, long?> valueFilter)
        {
            return GetPropertyValue(key, defaultValue, StringToLongConverter.Default, valueFilter);
        }

        public virtual IProperty<K, float?> GetFloatProperty(K key)
        {
            return GetFloatProperty(key, null);
        }

        public virtual float? GetFloatPropertyValue(K key)
        {
            return GetFloatPropertyValue(key, null);
        }

        public virtual IProperty<K, float?> GetFloatProperty(K key, float? defaultValue)
        {
            return GetFloatProperty(key, defaultValue, null);
        }

        public virtual float? GetFloatPropertyValue(K key, float? defaultValue)
        {
            return GetFloatPropertyValue(key, defaultValue, null);
        }

        public virtual IProperty<K, float?> GetFloatProperty(K key, float? defaultValue, Func<float?, float?> valueFilter)
        {
            return GetProperty(key, defaultValue, StringToFloatConverter.Default, valueFilter);
        }

        public virtual float? GetFloatPropertyValue(K key, float? defaultValue, Func<float?, float?> valueFilter)
        {
            return GetPropertyValue(key, defaultValue, StringToFloatConverter.Default, valueFilter);
        }

        public virtual IProperty<K, double?> GetDoubleProperty(K key)
        {
            return GetDoubleProperty(key, null);
        }

        public virtual double? GetDoublePropertyValue(K key)
        {
            return GetDoublePropertyValue(key, null);
        }

        public virtual IProperty<K, double?> GetDoubleProperty(K key, double? defaultValue)
        {
            return GetDoubleProperty(key, defaultValue, null);
        }

        public virtual double? GetDoublePropertyValue(K key, double? defaultValue)
        {
            return GetDoublePropertyValue(key, defaultValue, null);
        }

        public virtual IProperty<K, double?> GetDoubleProperty(K key, double? defaultValue, Func<double?, double?> valueFilter)
        {
            return GetProperty(key, defaultValue, StringToDoubleConverter.Default, valueFilter);
        }

        public virtual double? GetDoublePropertyValue(K key, double? defaultValue, Func<double?, double?> valueFilter)
        {
            return GetPropertyValue(key, defaultValue, StringToDoubleConverter.Default, valueFilter);
        }

        public virtual IProperty<K, bool?> GetBooleanProperty(K key)
        {
            return GetBooleanProperty(key, null);
        }

        public virtual bool? GetBooleanPropertyValue(K key)
        {
            return GetBooleanPropertyValue(key, null);
        }

        public virtual IProperty<K, bool?> GetBooleanProperty(K key, bool? defaultValue)
        {
            return GetBooleanProperty(key, defaultValue, null);
        }

        public virtual bool? GetBooleanPropertyValue(K key, bool? defaultValue)
        {
            return GetBooleanPropertyValue(key, defaultValue, null);
        }

        public virtual IProperty<K, bool?> GetBooleanProperty(K key, bool? defaultValue,
                Func<bool?, bool?> valueFilter)
        {
            return GetProperty(key, defaultValue, StringToBooleanConverter.Default, valueFilter);
        }

        public virtual bool? GetBooleanPropertyValue(K key, bool? defaultValue, Func<bool?, bool?> valueFilter)
        {
            return GetPropertyValue(key, defaultValue, StringToBooleanConverter.Default, valueFilter);
        }

        public virtual IProperty<K, List<string>> GetListProperty(K key)
        {
            return GetListProperty(key, (List<string>)null);
        }

        public virtual List<string> GetListPropertyValue(K key)
        {
            return GetListPropertyValue(key, (List<string>)null);
        }

        public virtual IProperty<K, List<string>> GetListProperty(K key, List<string> defaultValue)
        {
            return GetProperty(key, defaultValue, StringToListConverter.Default, null,
                ListComparator<string>.Default);
        }

        public virtual List<string> GetListPropertyValue(K key, List<string> defaultValue)
        {
            return GetPropertyValue(key, defaultValue, StringToListConverter.Default, null,
                ListComparator<string>.Default);
        }

        public virtual IProperty<K, List<V>> GetListProperty<V>(K key, ITypeConverter<string, V> typeConverter)
        {
            return GetListProperty(key, null, typeConverter);
        }

        public virtual List<V> GetListPropertyValue<V>(K key, ITypeConverter<string, V> typeConverter)
        {
            return GetListPropertyValue(key, null, typeConverter);
        }

        public virtual IProperty<K, List<V>> GetListProperty<V>(K key, List<V> defaultValue,
                ITypeConverter<string, V> typeConverter)
        {
            return GetListProperty(key, defaultValue, typeConverter, null);
        }

        public virtual List<V> GetListPropertyValue<V>(K key, List<V> defaultValue, ITypeConverter<string, V> typeConverter)
        {
            return GetListPropertyValue(key, defaultValue, typeConverter, null);
        }

        public virtual IProperty<K, List<V>> GetListProperty<V>(K key, List<V> defaultValue, ITypeConverter<string, V> typeConverter,
                Func<List<V>, List<V>> valueFilter)
        {
            return GetProperty(key, defaultValue, new StringToListConverter<V>(typeConverter),
                valueFilter, ListComparator<V>.Default);
        }

        public virtual List<V> GetListPropertyValue<V>(K key, List<V> defaultValue, ITypeConverter<string, V> typeConverter,
                Func<List<V>, List<V>> valueFilter)
        {
            return GetPropertyValue(key, defaultValue, new StringToListConverter<V>(typeConverter),
                valueFilter, ListComparator<V>.Default);
        }

        public virtual IProperty<K, Dictionary<string, string>> GetDictionaryProperty(K key)
        {
            return GetDictionaryProperty(key, null);
        }

        public virtual Dictionary<string, string> GetDictionaryPropertyValue(K key)
        {
            return GetDictionaryPropertyValue(key, null);
        }

        public virtual IProperty<K, Dictionary<string, string>> GetDictionaryProperty(K key, Dictionary<string, string> defaultValue)
        {
            return GetProperty(key, defaultValue, StringToDictionaryConverter.Default, null,
                DictionaryComparator<string, string>.Default);
        }

        public virtual Dictionary<string, string> GetDictionaryPropertyValue(K key, Dictionary<string, string> defaultValue)
        {
            return GetPropertyValue(key, defaultValue, StringToDictionaryConverter.Default, null,
                DictionaryComparator<string, string>.Default);
        }

        public virtual IProperty<K, Dictionary<MK, MV>> GetDictionaryProperty<MK, MV>(K key, ITypeConverter<string, MK> keyConverter,
                ITypeConverter<string, MV> valueConverter)
        {
            return GetDictionaryProperty(key, null, keyConverter, valueConverter);
        }

        public virtual Dictionary<MK, MV> GetDictionaryPropertyValue<MK, MV>(K key, ITypeConverter<string, MK> keyConverter,
                ITypeConverter<string, MV> valueConverter)
        {
            return GetDictionaryPropertyValue(key, null, keyConverter, valueConverter);
        }

        public virtual IProperty<K, Dictionary<MK, MV>> GetDictionaryProperty<MK, MV>(K key, Dictionary<MK, MV> defaultMValue,
                ITypeConverter<string, MK> keyConverter, ITypeConverter<string, MV> valueConverter)
        {
            return GetDictionaryProperty(key, defaultMValue, keyConverter, valueConverter, null);
        }

        public virtual Dictionary<MK, MV> GetDictionaryPropertyValue<MK, MV>(K key, Dictionary<MK, MV> defaultMValue,
                ITypeConverter<string, MK> keyConverter, ITypeConverter<string, MV> valueConverter)
        {
            return GetDictionaryPropertyValue(key, defaultMValue, keyConverter, valueConverter, null);
        }

        public virtual IProperty<K, Dictionary<MK, MV>> GetDictionaryProperty<MK, MV>(K key, Dictionary<MK, MV> defaultMValue,
                ITypeConverter<string, MK> keyConverter, ITypeConverter<string, MV> valueConverter,
                Func<Dictionary<MK, MV>, Dictionary<MK, MV>> valueFilter)
        {
            return GetProperty(key, defaultMValue, new StringToDictionaryConverter<MK, MV>(keyConverter, valueConverter),
                valueFilter, DictionaryComparator<MK, MV>.Default);
        }

        public virtual Dictionary<MK, MV> GetDictionaryPropertyValue<MK, MV>(K key, Dictionary<MK, MV> defaultValue,
                ITypeConverter<string, MK> keyConverter, ITypeConverter<string, MV> valueConverter,
                Func<Dictionary<MK, MV>, Dictionary<MK, MV>> valueFilter)
        {
            return GetPropertyValue(key, defaultValue, new StringToDictionaryConverter<MK, MV>(keyConverter, valueConverter),
                valueFilter, DictionaryComparator<MK, MV>.Default);
        }

        public virtual IProperty<K, V> GetProperty<V>(K key, ITypeConverter<string, V> valueConverter)
        {
            return GetProperty(key, default(V), valueConverter);
        }

        public virtual V GetPropertyValue<V>(K key, ITypeConverter<string, V> valueConverter)
        {
            return GetPropertyValue(key, default(V), valueConverter);
        }

        public virtual IProperty<K, V> GetProperty<V>(K key, V defaultValue, ITypeConverter<string, V> valueConverter)
        {
            return GetProperty(key, defaultValue, valueConverter, null);
        }

        public virtual V GetPropertyValue<V>(K key, V defaultValue, ITypeConverter<string, V> valueConverter)
        {
            return GetPropertyValue(key, defaultValue, valueConverter, null);
        }

        public virtual IProperty<K, V> GetProperty<V>(K key, V defaultValue,
                ITypeConverter<string, V> valueConverter, Func<V, V> valueFilter)
        {
            return GetProperty<V>(key, defaultValue, valueConverter, valueFilter, null);
        }

        public virtual V GetPropertyValue<V>(K key, V defaultValue, ITypeConverter<string, V> valueConverter,
                Func<V, V> valueFilter)
        {
            return GetPropertyValue<V>(key, defaultValue, valueConverter, valueFilter, null);
        }

        public virtual IProperty<K, V> GetProperty<V>(K key, V defaultValue,
            ITypeConverter<string, V> valueConverter, Func<V, V> valueFilter, IComparer<V> valueComparator)
        {
            PropertyConfig<K, V> propertyConfig = CreatePropertyConfig(key, defaultValue, valueConverter,
                    valueFilter, valueComparator);
            return _manager.GetProperty(propertyConfig);
        }

        public virtual V GetPropertyValue<V>(K key, V defaultValue, ITypeConverter<string, V> valueConverter,
            Func<V, V> valueFilter, IComparer<V> valueComparator)
        {
            PropertyConfig<K, V> propertyConfig = CreatePropertyConfig(key, defaultValue, valueConverter,
                    valueFilter, valueComparator);
            return _manager.GetPropertyValue(propertyConfig);
        }

        protected virtual PropertyConfig<K, V> CreatePropertyConfig<V>(K key, V defaultValue,
            ITypeConverter<string, V> valueConverter, Func<V, V> valueFilter)
        {
            return CreatePropertyConfig<V>(key, defaultValue, valueConverter, valueFilter, null);
        }

        protected virtual PropertyConfig<K, V> CreatePropertyConfig<V>(K key, V defaultValue,
            ITypeConverter<string, V> valueConverter, Func<V, V> valueFilter, IComparer<V> valueComparator)
        {
            return ConfigurationProperties.NewConfigBuilder<K, V>().SetKey(key)
                .SetDefaultValue(defaultValue).AddValueConverter(valueConverter)
                .SetValueFilter(valueFilter).SetValueComparator(valueComparator).Build();
        }
    }
}
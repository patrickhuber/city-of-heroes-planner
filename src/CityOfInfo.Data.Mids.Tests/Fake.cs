using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CityOfInfo.Data.Mids.Tests
{
    public class Fake
    {
        public static T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public static object Create(Type t)
        {
            if (t == typeof(string))
                return string.Empty;

            var instance = Activator.CreateInstance(t);
            if(t.IsPrimitive)
                return instance;

            var properties = t.GetProperties();
            var generator = new Generator();
            foreach (var property in properties)
            {
                var value = GenerateValue(generator, property);
                property.SetValue(instance, value);
            }
            return instance;
        }

        private static object GenerateValue(Generator generator, PropertyInfo property)
        {
            var propertyType = property.PropertyType;
            if (propertyType == typeof(string))
                return property.Name;
            return GenerateValue(generator, propertyType);
        }

        private static object GenerateValue(Generator generator, Type propertyType)
        {
            if (propertyType == typeof(int))
                return generator.GenerateInt();
            else if (propertyType == typeof(float))
                return generator.GenerateFloat();
            else if (propertyType == typeof(bool))
                return generator.GenerateBoolean();
            else if (propertyType == typeof(DateTime))
                return generator.GenerateDateTime();
            else if (propertyType.IsArray)
                return GenerateArray(generator, propertyType.GetElementType());

            return Create(propertyType);
        }

        private static object GenerateArray(Generator generator, Type elementType)
        {
            var arrayInstance = Array.CreateInstance(elementType, 2);
            var isStringType = elementType == typeof(string);
            for (var i = 0; i < arrayInstance.Length; i++)
            {
                if (isStringType)
                {
                    arrayInstance.SetValue(i.ToString(), i);
                    continue;
                }

                var value = GenerateValue(generator, elementType);
                arrayInstance.SetValue(value, i);
            }
            return arrayInstance;
        }

        private class Generator
        {
            private int _intBroker;
            private float _floatBroker;
            private bool _boolBroker;
            private DateTime _dateBroker;
            
            public Generator()
            {
                _intBroker = 0;
                _floatBroker = 0;
                _boolBroker = false;
                _dateBroker = new DateTime(2019, 04, 01);
            }

            public int GenerateInt()
            {
                return _intBroker++;
            }

            public float GenerateFloat()
            {
                var value = _floatBroker;
                _floatBroker += 1.0f;
                return value;
            }

            public bool GenerateBoolean()
            {
                var value = _boolBroker;
                _boolBroker = !_boolBroker;
                return value;
            }

            public DateTime GenerateDateTime()
            {
                var value = _dateBroker;
                _dateBroker = _dateBroker.AddDays(1);
                return _dateBroker;
            }
        }
    }
}

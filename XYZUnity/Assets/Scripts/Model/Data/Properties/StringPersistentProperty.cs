using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Model.Data.Properties
{
    public class StringPersistentProperty : PrefsPersistentProperty<string>
    {
        public StringPersistentProperty(string defaultValue, string key) : base(defaultValue, key)
        {
            Init();
        }

        protected override string Read(string defaultValue)
        {
            return PlayerPrefs.GetString(Key, defaultValue);
        }

        protected override void Write(string value)
        {
            PlayerPrefs.SetString(Key, value);
        }
    }
}
  
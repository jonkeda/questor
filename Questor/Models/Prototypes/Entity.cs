﻿using System.Diagnostics;
using Newtonsoft.Json;
using Questor.UI;

namespace Questor.Models.Prototypes
{
    [DebuggerDisplay("{Name}")]
    public class Entity : PropertyNotifier
    {

        public Entity()
        {
        }

        public Entity(string name)
        {
            Name = name;
        }

        private string _name;
        
        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}
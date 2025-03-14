﻿using System;

namespace Ipme.WikiBeer.Models
{
    public class CountryModel : ObservableObject, IDeepClonable<CountryModel>
    {
        public Guid Id { get;}

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public CountryModel(string name): this(Guid.Empty, name)
        {
        }

        public CountryModel(Guid id, string name)
        {
            Id = id;
            Name = name ?? String.Empty;
        }

        private CountryModel(CountryModel country) 
            : this(country.Id, country.Name)
        {
        }

        public CountryModel DeepClone()
        {
            return new CountryModel(this);
        }

    }
}
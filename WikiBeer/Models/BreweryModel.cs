﻿using AutoFixture;
using Ipme.WikiBeer.Models.Magic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ipme.WikiBeer.Models
{
    public class BreweryModel : ObservableObject, IDeepClonable<BreweryModel>
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        private CountryModel? _country;
        public CountryModel? Country 
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public BreweryModel(string name, string description, CountryModel? country)
            : this(Guid.Empty, name, description, country)
        {
        }

        public BreweryModel(Guid id, string name, string description, CountryModel? country)
        {
            Id = id;
            Name = name ?? String.Empty;
            Description = description ?? String.Empty;
            Country = country;
        }

        private BreweryModel(BreweryModel brewery)
            : this(brewery.Id, brewery.Name, brewery.Description, brewery.Country?.DeepClone())
        {
            Id = brewery.Id;
            Name = brewery.Name ?? String.Empty;
            Description = brewery.Description;            
        }

        public BreweryModel DeepClone()
        {            
            return new BreweryModel(this);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ipme.WikiBeer.Dtos.Ingredients
{
    [DataContract]
    internal class HopDto : IngredientDto
    {
        [DataMember]
        public float AlphaAcid { get; set; }
    }
}

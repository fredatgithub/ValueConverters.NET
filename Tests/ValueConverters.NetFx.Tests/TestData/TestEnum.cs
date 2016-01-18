﻿
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ValueConverters.NetFx.Tests.TestData
{
    [DataContract]
    public enum TestEnum
    {
        [EnumMember]
        [Display(Name = "LoremText", ResourceType = typeof(AppResources))]
        Lorem,

        [EnumMember]
        [Display(Name = "IpsumText", ResourceType = typeof(AppResources))]
        Ipsum,

        Dolor // Test if conversion works without annotation
    }
}

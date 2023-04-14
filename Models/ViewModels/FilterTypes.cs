using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace IntexII_0305.Models.ViewModels;
public class FilterTypes
{
    public long? BurialRecordId { get; set; }
    public string? Sexes { get; set; }
    public string? AgesAtDeath { get; set; }
    public string? Depths { get; set; }
    public string? HeadDirections { get; set; }
    public string? Wrappings { get; set; }
    public string? HairColors { get; set; }
    //public string? Areas { get; set; }

}
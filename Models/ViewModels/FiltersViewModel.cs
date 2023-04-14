using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace IntexII_0305.Models.ViewModels;
public class FiltersViewModel
{
    public IEnumerable<long> BurialRecordId { get; set; }
    public IEnumerable<string> Sexes { get; set; }
    public IEnumerable<string> AgesAtDeath { get; set; }
    public IEnumerable<string> Depths { get; set; }
    public IEnumerable<string> HeadDirections { get; set; }
    public IEnumerable<string> Wrappings { get; set; }
    public IEnumerable<string> HairColors { get; set; }
    //public IEnumerable<string> Areas { get; set; }
}
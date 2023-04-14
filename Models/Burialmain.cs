using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntexII_0305.Models;

public partial class Burialmain
{
    [Column("id")]
    public long Id { get; set; }
    [Column("squarenorthsouth")]
    public string? Squarenorthsouth { get; set; }
    [Column("headdirection")]
    public string? Headdirection { get; set; }
    [Column("sex")]
    public string? Sex { get; set; }
    [Column("northsouth")]
    public string? Northsouth { get; set; }
    [Column("depth")]       
    public string? Depth { get; set; }
    [Column("eastwest")]
    public string? Eastwest { get; set; }
    [Column("adultsubadult")]
    public string? Adultsubadult { get; set; }
    [Column("facebundles")]
    public string? Facebundles { get; set; }
    [Column("southtohead")]
    public string? Southtohead { get; set; }
    [Column("preservation")]
    public string? Preservation { get; set; }
    [Column("fieldbookpage")]
    public string? Fieldbookpage { get; set; }
    [Column("squareeastwest")]
    public string? Squareeastwest { get; set; }
    [Column("goods")]
    public string? Goods { get; set; }
    [Column("text")]
    public string? Text { get; set; }
    [Column("wrapping")]
    public string? Wrapping { get; set; }
    [Column("haircolor")]
    public string? Haircolor { get; set; }
    [Column("westtohead")]
    public string? Westtohead { get; set; }
    [Column("samplescollected")]
    public string? Samplescollected { get; set; }
    [Column("area")]
    public string? Area { get; set; }
    [Column("burialid")]
    public long? Burialid { get; set; }
    [Column("length")]
    public string? Length { get; set; }
    [Column("burialnumber")]
    public string? Burialnumber { get; set; }
    [Column("dataexpertinitials")]
    public string? Dataexpertinitials { get; set; }
    [Column("westtofeet")]
    public string? Westtofeet { get; set; }
    [Column("ageatdeath")]
    public string? Ageatdeath { get; set; }
    [Column("southtofeet")]
    public string? Southtofeet { get; set; }
    [Column("excavationrecorder")]
    public string? Excavationrecorder { get; set; }
    [Column("photos")]
    public string? Photos { get; set; }
    [Column("hair")]
    public string? Hair { get; set; }
    [Column("burialmaterials")]
    public string? Burialmaterials { get; set; }
    [Column("dateofexcavation")]
    public DateTime? Dateofexcavation { get; set; }
    [Column("fieldbookexcavationyear")]
    public string? Fieldbookexcavationyear { get; set; }
    [Column("clusternumber")]
    public string? Clusternumber { get; set; }
    [Column("shaftnumber")]
    public string? Shaftnumber { get; set; }
}

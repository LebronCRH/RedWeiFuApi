using System;
using Qing;
[PrimaryKey("UnitZoneId")]
public class UnitZone :baseEntity
{
private int? _Id;
 [Column(Qing.DataType.Interger)]
public int? Id
{
get{return _Id;}
set{ _Id=value;}
}
private int? _UnitZoneId;
 [Column(Qing.DataType.Interger)]
public int? UnitZoneId
{
get{return _UnitZoneId;}
set{ _UnitZoneId=value;}
}
private string _UnitZoneName;
public string UnitZoneName
{
get{return _UnitZoneName;}
set{ _UnitZoneName=value;}
}
}
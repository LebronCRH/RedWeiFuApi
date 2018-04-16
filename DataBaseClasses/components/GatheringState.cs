using System;
using Qing;
[PrimaryKey("GatheringStateId")]
public class GatheringState :baseEntity
{
private int? _Id;
 [Column(Qing.DataType.Interger)]
public int? Id
{
get{return _Id;}
set{ _Id=value;}
}
private int? _GatheringStateId;
 [Column(Qing.DataType.Interger)]
public int? GatheringStateId
{
get{return _GatheringStateId;}
set{ _GatheringStateId=value;}
}
private string _GatheringStateName;
public string GatheringStateName
{
get{return _GatheringStateName;}
set{ _GatheringStateName=value;}
}
}
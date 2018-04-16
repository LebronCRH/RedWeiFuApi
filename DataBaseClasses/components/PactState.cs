using System;
using Qing;
[PrimaryKey("PactStateId")]
public class PactState :baseEntity
{
private int? _Id;
 [Column(Qing.DataType.Interger)]
public int? Id
{
get{return _Id;}
set{ _Id=value;}
}
private int? _PactStateId;
 [Column(Qing.DataType.Interger)]
public int? PactStateId
{
get{return _PactStateId;}
set{ _PactStateId=value;}
}
private string _PactStateName;
public string PactStateName
{
get{return _PactStateName;}
set{ _PactStateName=value;}
}
}
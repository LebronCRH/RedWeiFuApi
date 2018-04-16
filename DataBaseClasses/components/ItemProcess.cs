using System;
using Qing;
[PrimaryKey("Id")]
public class ItemProcess :baseEntity
{
private int? _Id;
 [Column(Qing.DataType.Interger)]
public int? Id
{
get{return _Id;}
set{ _Id=value;}
}
private string _ItemPhase;
public string ItemPhase
{
get{return _ItemPhase;}
set{ _ItemPhase=value;}
}
private string _ItemTache;
public string ItemTache
{
get{return _ItemTache;}
set{ _ItemTache=value;}
}
private string _OperationTypeName;
public string OperationTypeName
{
get { return _OperationTypeName; }
set { _OperationTypeName = value; }
}
}
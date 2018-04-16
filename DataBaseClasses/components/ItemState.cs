using System;
using Qing;
[PrimaryKey("ItemStateId")]
public class ItemState :baseEntity
{
private int? _Id;
 [Column(Qing.DataType.Interger)]
public int? Id
{
get{return _Id;}
set{ _Id=value;}
}
private int? _ItemStateId;
 [Column(Qing.DataType.Interger)]
public int? ItemStateId
{
get{return _ItemStateId;}
set{ _ItemStateId=value;}
}
private string _ItemStateName;
public string ItemStateName
{
get{return _ItemStateName;}
set{ _ItemStateName=value;}
}
}
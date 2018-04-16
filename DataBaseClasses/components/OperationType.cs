using System;
using Qing;
[PrimaryKey("OperationTypeId")]
public class OperationType :baseEntity
{
private int? _Id;
 [Column(Qing.DataType.Interger)]
public int? Id
{
get{return _Id;}
set{ _Id=value;}
}
private int? _OperationTypeId;
 [Column(Qing.DataType.Interger)]
public int? OperationTypeId
{
get{return _OperationTypeId;}
set{ _OperationTypeId=value;}
}
private string _OperationTypeName;
public string OperationTypeName
{
get{return _OperationTypeName;}
set{ _OperationTypeName=value;}
}
}
using System;
using Qing;
[PrimaryKey("ItemFileTypeId")]
public class ItemFileType :baseEntity
{
private int? _Id;
 [Column(Qing.DataType.Interger)]
public int? Id
{
get{return _Id;}
set{ _Id=value;}
}
private string _ItemFileTypeId;
public string ItemFileTypeId
{
get{return _ItemFileTypeId;}
set{ _ItemFileTypeId=value;}
}
private string _ItemFileTypeName;
public string ItemFileTypeName
{
get{return _ItemFileTypeName;}
set{ _ItemFileTypeName=value;}
}
}
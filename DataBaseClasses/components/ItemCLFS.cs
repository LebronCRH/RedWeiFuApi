using System;
using Qing;
[PrimaryKey("Id")]
public class ItemCLFS :baseEntity
{
private int? _Id;
 [Column(Qing.DataType.Interger)]
public int? Id
{
get{return _Id;}
set{ _Id=value;}
}
private string _CLFS;
public string CLFS
{
get{return _CLFS;}
set{ _CLFS=value;}
}
}
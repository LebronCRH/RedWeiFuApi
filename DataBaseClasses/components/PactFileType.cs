using System;
using Qing;
[PrimaryKey("PactFileTypeId")]
public class PactFileType :baseEntity
{
private int? _Id;
 [Column(Qing.DataType.Interger)]
public int? Id
{
get{return _Id;}
set{ _Id=value;}
}
private String _PactFileTypeId;
public String PactFileTypeId
{
get{return _PactFileTypeId;}
set{ _PactFileTypeId=value;}
}
private string _PactFileTypeName;
public string PactFileTypeName
{
get{return _PactFileTypeName;}
set{ _PactFileTypeName=value;}
}
}
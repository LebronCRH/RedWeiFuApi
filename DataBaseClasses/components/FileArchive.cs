using System;
using Qing;
[PrimaryKey("Id")]
public class FileArchive :baseEntity
{
private int? _Id;
 [Column(Qing.DataType.Interger)]
public int? Id
{
get{return _Id;}
set{ _Id=value;}
}
private string _FileArchiveId;
public string FileArchiveId
{
get{return _FileArchiveId;}
set{ _FileArchiveId=value;}
}
private string _FileType;
public string FileType
{
get{return _FileType;}
set{ _FileType=value;}
}
private string _FileName;
public string FileName
{
get{return _FileName;}
set{ _FileName=value;}
}
private string _FileMpAddress;
public string FileMpAddress
{
get{return _FileMpAddress;}
set{ _FileMpAddress=value;}
}
private string _ArchiveDate;
public string ArchiveDate
{
get{return _ArchiveDate;}
set{ _ArchiveDate=value;}
}
}
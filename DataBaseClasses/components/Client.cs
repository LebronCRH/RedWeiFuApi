using System;
using Qing;
public class Client :baseEntity
{
private int? _Id;
 [Column(Qing.DataType.Interger)]
public int? Id
{
get{return _Id;}
set{ _Id=value;}
}
private string _ClientId;
public string ClientId
{
get{return _ClientId;}
set{ _ClientId=value;}
}
private string _ClientName;
public string ClientName
{
get{return _ClientName;}
set{ _ClientName=value;}
}
private string _Sex;
public string Sex
{
get{return _Sex;}
set{ _Sex=value;}
}
private string _UnitId;
public string UnitId
{
get{return _UnitId;}
set{ _UnitId=value;}
}
private int? _DeptId;
 [Column(Qing.DataType.Interger)]
public int? DeptId
{
get{return _DeptId;}
set{ _DeptId=value;}
}
private string _Deptappellation;
public string Deptappellation
{
get{return _Deptappellation;}
set{ _Deptappellation=value;}
}
private string _Headship;
public string Headship
{
get{return _Headship;}
set{ _Headship=value;}
}
private string _Postalcode;
public string Postalcode
{
get{return _Postalcode;}
set{ _Postalcode=value;}
}
private string _Address;
public string Address
{
get{return _Address;}
set{ _Address=value;}
}
private string _OfficePhone;
public string OfficePhone
{
get{return _OfficePhone;}
set{ _OfficePhone=value;}
}
private string _Mobile;
public string Mobile
{
get{return _Mobile;}
set{ _Mobile=value;}
}
private string _Email;
public string Email
{
get{return _Email;}
set{ _Email=value;}
}
private string _Wedlock;
public string Wedlock
{
get{return _Wedlock;}
set{ _Wedlock=value;}
}
private string _Xueli;
public string Xueli
{
get{return _Xueli;}
set{ _Xueli=value;}
}
private string _Jiguan;
public string Jiguan
{
get{return _Jiguan;}
set{ _Jiguan=value;}
}
private string _Birthday;
public string Birthday
{
get{return _Birthday;}
set{ _Birthday=value;}
}
private string _Like;
public string Like
{
get{return _Like;}
set{ _Like=value;}
}
private string _Bewrite;
public string Bewrite
{
get{return _Bewrite;}
set{ _Bewrite=value;}
}
private string _Remark;
public string Remark
{
get{return _Remark;}
set{ _Remark=value;}
}
private string _Booker;
public string Booker
{
get{return _Booker;}
set{ _Booker=value;}
}
private string _Time;
public string Time
{
get{return _Time;}
set{ _Time=value;}
}
}
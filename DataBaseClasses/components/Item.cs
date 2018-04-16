using System;
using Qing;
[PrimaryKey("Id")]
public class Item :baseEntity
{
private string _Id;
public string Id
{
get{return _Id;}
set{ _Id=value;}
}
private int? _ItemCharacterId;
 [Column(Qing.DataType.Interger)]
public int? ItemCharacterId
{
get{return _ItemCharacterId;}
set{ _ItemCharacterId=value;}
}
private string _ItemId;
public string ItemId
{
get{return _ItemId;}
set{ _ItemId=value;}
}
private string _ItemName;
public string ItemName
{
get{return _ItemName;}
set{ _ItemName=value;}
}
private int? _OperationTypeId;
 [Column(Qing.DataType.Interger)]
public int? OperationTypeId
{
get{return _OperationTypeId;}
set{ _OperationTypeId=value;}
}
private string _UnitId;
public string UnitId
{
get{return _UnitId;}
set{ _UnitId=value;}
}
private string _Pre_described;
public string Pre_described
{
get{return _Pre_described;}
set{ _Pre_described=value;}
}
private string _StartDate;
public string StartDate
{
get{return _StartDate;}
set{ _StartDate=value;}
}
private string _EndDate;
public string EndDate
{
get{return _EndDate;}
set{ _EndDate=value;}
}
private string _CostBudget;
public string CostBudget
{
get{return _CostBudget;}
set{ _CostBudget=value;}
}
private string _ClientId;
public string ClientId
{
    get { return _ClientId; }
    set { _ClientId = value; }
}
private string _UserName;
public string UserName
{
get{return _UserName;}
set{ _UserName=value;}
}
private string _Vendition;
public string Vendition
{
get{return _Vendition;}
set{ _Vendition=value;}
}
private string _ItemManager;
public string ItemManager
{
get{return _ItemManager;}
set{ _ItemManager=value;}
}
private string _PactId;
public string PactId
{
get{return _PactId;}
set{ _PactId=value;}
}
private int? _ItemStateId;
 [Column(Qing.DataType.Interger)]
public int? ItemStateId
{
get{return _ItemStateId;}
set{ _ItemStateId=value;}
}
 private string _Remark;
 public string Remark
 {
     get { return _Remark;}
     set { _Remark = value; }
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
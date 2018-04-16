using System;
using Qing;
[PrimaryKey("Id")]
public class Pact :baseEntity
{
private string _number;
public string number
{
get{return _number;}
set{ _number=value;}
}
private string _Id;
public string Id
{
get{return _Id;}
set{ _Id=value;}
}
private int? _UnitZoneId;
 [Column(Qing.DataType.Interger)]
public int? UnitZoneId
{
get{return _UnitZoneId;}
set{ _UnitZoneId=value;}
}
private int? _PactStateId;
 [Column(Qing.DataType.Interger)]
public int? PactStateId
{
get{return _PactStateId;}
set{ _PactStateId=value;}
}
private int? _OperationTypeId;
 [Column(Qing.DataType.Interger)]
public int? OperationTypeId
{
get{return _OperationTypeId;}
set{ _OperationTypeId=value;}
}
private string _Vendition;
public string Vendition
{
get{return _Vendition;}
set{ _Vendition=value;}
}
private string _PactId;
public string PactId
{
get{return _PactId;}
set{ _PactId=value;}
}
private string _PactName;
public string PactName
{
get{return _PactName;}
set{ _PactName=value;}
}
private string _ItemCount;
public string ItemCount
{
get{return _ItemCount;}
set{ _ItemCount=value;}
}
private string _SignDate;
public string SignDate
{
get{return _SignDate;}
set{ _SignDate=value;}
}
private string _EndDate;
public string EndDate
{
    get { return _EndDate; }
    set { _EndDate = value; }
}
private string _Total;
public string Total
{
get{return _Total;}
set{ _Total=value;}
}
private string _Margins;
public string Margins
{
get{return _Margins;}
set{ _Margins=value;}
}
private string _TimePlan;
public string TimePlan
{
get{return _TimePlan;}
set{ _TimePlan=value;}
}
private string _TermFact;
public string TermFact
{
get{return _TermFact;}
set{ _TermFact=value;}
}
private string _PaymentFact;
public string PaymentFact
{
get{return _PaymentFact;}
set{ _PaymentFact=value;}
}
private string _CommerceClause;
public string CommerceClause
{
get{return _CommerceClause;}
set{ _CommerceClause=value;}
}
private string _FactCollect;
public string FactCollect
{
get{return _FactCollect;}
set{ _FactCollect=value;}
}
private int? _GatheringStateId;
 [Column(Qing.DataType.Interger)]
public int? GatheringStateId
{
get{return _GatheringStateId;}
set{ _GatheringStateId=value;}
}
private string _ServiceCycle;
public string ServiceCycle
{
get{return _ServiceCycle;}
set{ _ServiceCycle=value;}
}
private string _TrainingInformation;
public string TrainingInformation
{
get{return _TrainingInformation;}
set{ _TrainingInformation=value;}
}
private string _UnitId;
public string UnitId
{
get{return _UnitId;}
set{ _UnitId=value;}
}
private string _Owner;
public string Owner
{
get{return _Owner;}
set{ _Owner=value;}
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
private string _IsInvoice;
public string IsInvoice
{
    get { return _IsInvoice; }
    set { _IsInvoice = value; }
}
private string _InvoiceTime;
public string InvoiceTime
{
    get { return _InvoiceTime; }
    set { _InvoiceTime = value; }
}
}

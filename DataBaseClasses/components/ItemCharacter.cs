using System;
using Qing;
[PrimaryKey("ItemCharacterId")]
public class ItemCharacter :baseEntity
{
private int? _Id;
 [Column(Qing.DataType.Interger)]
public int? Id
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
private string _ItemCharacterName;
public string ItemCharacterName
{
get{return _ItemCharacterName;}
set{ _ItemCharacterName=value;}
}
}
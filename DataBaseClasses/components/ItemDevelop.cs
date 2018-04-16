using System;
using Qing;
[PrimaryKey("Id")]
public class ItemDevelop : baseEntity
{
    private string _Id;
    public string Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
  
    private string _ItemLSH;
    public string ItemLSH
    {
        get { return _ItemLSH; }
        set { _ItemLSH = value; }
    }
    private string _ItemId;
    public string ItemId
    {
        get { return _ItemId; }
        set { _ItemId = value; }
    }
    private string _Milestone;
    public string Milestone
    {
        get { return _Milestone; }
        set { _Milestone = value; }
    }
    private string _ItemPhase;
    public string ItemPhase
    {
        get { return _ItemPhase; }
        set { _ItemPhase = value; }
    }
    private string _ItemTache;
    public string ItemTache
    {
        get { return _ItemTache; }
        set { _ItemTache = value; }
    }
    private string _Process;
    public string Process
    {
        get { return _Process; }
        set { _Process = value; }
    }
    private string _MasterName;
    public string MasterName
    {
        get { return _MasterName; }
        set { _MasterName = value; }
    }
    private string _Disposedate;
    public string Disposedate
    {
        get { return _Disposedate; }
        set { _Disposedate = value; }
    }
    private string _Dispose;
    public string Dispose
    {
        get { return _Dispose; }
        set { _Dispose = value; }
    }
    private string _Man_haur;
    public string Man_haur
    {
        get { return _Man_haur; }
        set { _Man_haur = value; }
    }
    private string _Client;
    public string Client
    {
        get { return _Client; }
        set { _Client = value; }
    }
    private string _Idea;
    public string Idea
    {
        get { return _Idea; }
        set { _Idea = value; }
    }
    private string _Remark;
    public string Remark
    {
        get { return _Remark; }
        set { _Remark = value; }
    }
    private string _Booker;
    public string Booker
    {
        get { return _Booker; }
        set { _Booker = value; }
    }
    private string _Time;
    public string Time
    {
        get { return _Time; }
        set { _Time = value; }
    }

    private string _VerifyPeople;
    /// <summary>
    /// 核实人
    /// </summary>
    public string VerifyPeople
    {
        get { return _VerifyPeople; }
        set { _VerifyPeople = value; }
    }

    private string _VerifyOpinion;
    /// <summary>
    /// 核实意见
    /// </summary>
    public string VerifyOpinion
    {
        get { return _VerifyOpinion; }
        set { _VerifyOpinion = value; }
    }


    private string _VerificationTime;
    /// <summary>
    /// 核实时间
    /// </summary>
    public string VerificationTime
    {
        get { return _VerificationTime; }
        set { _VerificationTime = value; }
    }
   
}
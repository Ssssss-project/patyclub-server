
using System.Collections.Generic;
using patyclub_server.Entities;


public class Event {
    public EventMst eventMst{get; set;}
    public List<EventAppendix> eventAppendixList{get; set;}
}
public class getEventWithConditionsArgs : PageRequest {
    public int? category {get; set;}
    public string TAG {get; set;}
    public List<string> queryList {get; set;}
    public YesNoEnums nonCompleteEvent {get; set;}
    public eventSortByEnums sortBy {get; set;}
    public eventPersonnelEnums eventPersonnel {get; set;}
}

public class eventIdArgs {
    public int eventId{get; set;}
}
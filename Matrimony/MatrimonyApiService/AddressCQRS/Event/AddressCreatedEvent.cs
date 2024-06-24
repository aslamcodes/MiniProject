﻿namespace MatrimonyApiService.AddressCQRS.Event;

public class AddressCreatedEvent
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
}
﻿#nullable disable
namespace MatrimonyApiService.Staff;

public record StaffPlainDto
{
    public string Email { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string PhoneNumber { get; init; }
    public int AddressId { get; init; }
    public bool IsVerified { get; init; }
    public string Role { get; init; }
    public int LoginAttempts { get; init; }
}
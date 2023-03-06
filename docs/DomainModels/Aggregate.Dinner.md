# Domain Models

## Dinner

```csharp
class Dinner
{
	Dinner Create();
	void AddReservation(Reservation reservation);
	void RemoveReservation(Reservation reservation);
}
```
 
```json
{
	"id": "00000000-0000-0000-0000-000000000000",
	"name": "Dinner1",
	"description": "dinner 1 descritioin",
	"hostId": "00000000-0000-0000-0000-000000000000",
	"menuId": "00000000-0000-0000-0000-000000000000",
	"reservations": [
	{
		"id": "00000000-0000-0000-0000-000000000000",
		"dinnerId": "00000000-0000-0000-0000-000000000000",
		"billId": "00000000-0000-0000-0000-000000000000",
		"detail": "reservationdetails"
	}]
}
```

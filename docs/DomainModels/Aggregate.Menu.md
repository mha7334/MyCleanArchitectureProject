# Domain Models

## Menu

```csharp
class Menu
{
	Menu Create();
	void AddDinner(Dinner dinner);
	void RemoveDinner(Dinner remove);
	void UpdateSection(MenuSection section);
}
```

```json
{
	"id": "00000000-0000-0000-0000-000000000000",
	"name": "Menu1",
	"description": "menu 1 descritioin",
	"averageRating" = 4.5,
	"sections": [
	{
		"id": "00000000-0000-0000-0000-000000000000",
		"name": "Sec 1",
		"description": "Sec 1 desc", 
		"items": [
		{
		"id": "00000000-0000-0000-0000-000000000000",
		"name": "item 1",
		"description": "item 1 desc", 
		"price": 5.99
		}
		]
	}],
	"hostId": "00000000-0000-0000-0000-000000000000",
	"dinnerIds": [
	"00000000-0000-0000-0000-000000000000",
	"00000000-0000-0000-0000-000000000000",
	"00000000-0000-0000-0000-000000000000",
	],
	"menuReviewIds": [
	"00000000-0000-0000-0000-000000000000",
	"00000000-0000-0000-0000-000000000000",
	"00000000-0000-0000-0000-000000000000",
	],
	"createdDateTime": "2020-01-01T00:00:00.00000000Z",
	"updatedDateTime": "2020-01-01T00:00:00.00000000Z",
}
```

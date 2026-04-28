---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.DoesBarExistAtPosition(System.Int32)
source: html/acd26ed2-3b9f-b240-04fe-e4da3dd14d66.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.DoesBarExistAtPosition Method

Checks whether a bar is included at the specified position.

## Syntax (C#)
```csharp
public bool DoesBarExistAtPosition(
	int barPosition
)
```

## Parameters
- **barPosition** (`System.Int32`) - A bar position index between 0 and NumberOfBarPositions-1.

## Returns
Returns true if the bar at the specified position is included, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPosition is not in the range [ 0, NumberOfBarPositions-1 ].


---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.DoesBarExistAtPosition(System.Int32)
zh: 钢筋、配筋
source: html/f223b762-1ef9-bf37-29e3-202dd570edb8.htm
---
# Autodesk.Revit.DB.Structure.Rebar.DoesBarExistAtPosition Method

**中文**: 钢筋、配筋

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


---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.DoesBarExistAtPosition(System.Int32)
source: html/ff2cf48e-9017-c8ad-c217-9466bfd34e22.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.DoesBarExistAtPosition Method

Checks whether a bar exists at the specified position.

## Syntax (C#)
```csharp
public bool DoesBarExistAtPosition(
	int barPosition
)
```

## Parameters
- **barPosition** (`System.Int32`) - A bar position index between 0 and NumberOfBarPositions-1.

## Remarks
Returns true, unless the bar position is the first or last
 in the set and it is suppressed by IncludeFirstBar or
 IncludeLastBar.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPosition is not in the range [ 0, NumberOfBarPositions-1 ].


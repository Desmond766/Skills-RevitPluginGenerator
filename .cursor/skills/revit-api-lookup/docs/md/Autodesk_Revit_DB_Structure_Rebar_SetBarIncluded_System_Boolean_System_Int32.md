---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.SetBarIncluded(System.Boolean,System.Int32)
zh: 钢筋、配筋
source: html/b6bd8b08-36ab-ec51-a533-8c918b2fe42c.htm
---
# Autodesk.Revit.DB.Structure.Rebar.SetBarIncluded Method

**中文**: 钢筋、配筋

Sets if the bar at the desired index is included or not.

## Syntax (C#)
```csharp
public void SetBarIncluded(
	bool include,
	int barPositionIndex
)
```

## Parameters
- **include** (`System.Boolean`) - True to include the bar, false to exclude the bar.
- **barPositionIndex** (`System.Int32`) - The bar index.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].


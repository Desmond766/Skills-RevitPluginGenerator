---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.SetBarIncluded(System.Boolean,System.Int32)
source: html/58132506-c018-6563-21dd-202f3327344f.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.SetBarIncluded Method

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
- **Autodesk.Revit.Exceptions.InapplicableDataException** - For this RebarInSystem element individual bars can't be moved, excluded or included.


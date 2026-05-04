---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.SetSegmentLength(Autodesk.Revit.DB.ElementId,System.Double)
source: html/0c2d43a6-7e9f-115a-65a2-56e370747aa5.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.SetSegmentLength Method

Sets the value of the bent fabric sheet segment(like A, B, C, D etc.)

## Syntax (C#)
```csharp
public void SetSegmentLength(
	ElementId segmentParameterId,
	double value
)
```

## Parameters
- **segmentParameterId** (`Autodesk.Revit.DB.ElementId`) - The segment ID of the bent fabric sheet.
- **value** (`System.Double`) - The length value to set

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for value is not a number
 -or-
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for value must be between 0 and 30000 feet.


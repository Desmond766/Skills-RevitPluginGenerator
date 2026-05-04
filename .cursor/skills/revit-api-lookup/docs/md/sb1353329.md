---
kind: method
id: M:Autodesk.Revit.DB.Electrical.AreaBasedLoadBoundaryLineData.IsElevationWithinRange(System.Double)
source: html/82226118-0ec1-ed1a-f8e0-7b2168163a44.htm
---
# Autodesk.Revit.DB.Electrical.AreaBasedLoadBoundaryLineData.IsElevationWithinRange Method

Checks whether the given elevation is between the bottom level and the top level(including
 the bottom level and the top level) of the area based load boundary line.

## Syntax (C#)
```csharp
public bool IsElevationWithinRange(
	double elev
)
```

## Parameters
- **elev** (`System.Double`) - The elevation value.

## Returns
True if given elevation is between the bottom level elevation and the top level elevation, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for elev is not a number
 -or-
 The given value for elev is not finite


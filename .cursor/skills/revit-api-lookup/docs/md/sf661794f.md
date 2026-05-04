---
kind: method
id: M:Autodesk.Revit.DB.ImageInstance.GetLocation(Autodesk.Revit.DB.BoxPlacement)
source: html/c275e3bf-00ab-2d2f-8c41-7d4cd7ff79fe.htm
---
# Autodesk.Revit.DB.ImageInstance.GetLocation Method

Returns the location of one of the points of the ImageInstance

## Syntax (C#)
```csharp
public XYZ GetLocation(
	BoxPlacement placementPoint
)
```

## Parameters
- **placementPoint** (`Autodesk.Revit.DB.BoxPlacement`) - The placementPoint specifies for which point of the ImageInstance the location should be returned.

## Returns
The location of the specified point

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration


---
kind: method
id: M:Autodesk.Revit.DB.ImageInstance.SetLocation(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.BoxPlacement)
source: html/2ca53d23-6e03-838c-b755-2478f778357d.htm
---
# Autodesk.Revit.DB.ImageInstance.SetLocation Method

Moves the ImageInstance to the specified location

## Syntax (C#)
```csharp
public void SetLocation(
	XYZ newLocation,
	BoxPlacement placementPoint
)
```

## Parameters
- **newLocation** (`Autodesk.Revit.DB.XYZ`) - The new location of the specified point
- **placementPoint** (`Autodesk.Revit.DB.BoxPlacement`) - The placementPoint specifies which point of the ImageInstance should be placed at the given location.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given newLocation is more than 10 miles from the origin of the model
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration


---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralSettings.GetLoadForceVectorReprLine(Autodesk.Revit.DB.Structure.LoadType,Autodesk.Revit.DB.XYZ)
source: html/1d9e4033-43bb-2d98-fdf5-f18bf24c8329.htm
---
# Autodesk.Revit.DB.Structure.StructuralSettings.GetLoadForceVectorReprLine Method

Returns the representative line of the load force vector according to loads display scaling.

## Syntax (C#)
```csharp
public XYZ GetLoadForceVectorReprLine(
	LoadType loadType,
	XYZ forceVector
)
```

## Parameters
- **loadType** (`Autodesk.Revit.DB.Structure.LoadType`) - LoadType::Point, Line, or Area
- **forceVector** (`Autodesk.Revit.DB.XYZ`) - The load force vector in internal units.

## Returns
The the representative line in internal units.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration


---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.AddReferencePoint(Autodesk.Revit.DB.XYZ)
source: html/76610683-c067-3981-af51-47bb90e0f22e.htm
---
# Autodesk.Revit.DB.DirectShape.AddReferencePoint Method

Adds a reference point to the DirectShape.

## Syntax (C#)
```csharp
public void AddReferencePoint(
	XYZ refPoint
)
```

## Parameters
- **refPoint** (`Autodesk.Revit.DB.XYZ`) - The coordinates of the new reference point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input point lies outside of Revit design limits.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


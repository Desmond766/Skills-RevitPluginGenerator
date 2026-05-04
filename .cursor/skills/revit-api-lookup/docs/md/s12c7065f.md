---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.AddReferencePoint(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.DirectShapeReferenceOptions)
source: html/18f765f4-0e13-b5eb-2d27-b486f93d8908.htm
---
# Autodesk.Revit.DB.DirectShape.AddReferencePoint Method

Adds a reference point to the DirectShape.

## Syntax (C#)
```csharp
public void AddReferencePoint(
	XYZ refPoint,
	DirectShapeReferenceOptions options
)
```

## Parameters
- **refPoint** (`Autodesk.Revit.DB.XYZ`) - The coordinates of the new reference point.
- **options** (`Autodesk.Revit.DB.DirectShapeReferenceOptions`) - The options that are used to configure the new reference point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input point lies outside of Revit design limits.
 -or-
 options cannot be used to add a reference object to this DirectShape.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


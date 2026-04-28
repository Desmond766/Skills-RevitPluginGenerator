---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.AddReferencePoint(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.DirectShapeReferenceOptions)
source: html/f97bae0e-e1fb-76f3-0b8e-868e82a87ac3.htm
---
# Autodesk.Revit.DB.DirectShapeType.AddReferencePoint Method

Adds a reference point to the DirectShapeType.

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
 options cannot be used to add a reference object to this DirectShapeType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


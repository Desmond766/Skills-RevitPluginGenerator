---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.AddReferencePoint(Autodesk.Revit.DB.XYZ)
source: html/f9ba1808-1a7e-c8c4-6ed8-deb4b34b85b2.htm
---
# Autodesk.Revit.DB.DirectShapeType.AddReferencePoint Method

Adds a reference point to the DirectShapeType.

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


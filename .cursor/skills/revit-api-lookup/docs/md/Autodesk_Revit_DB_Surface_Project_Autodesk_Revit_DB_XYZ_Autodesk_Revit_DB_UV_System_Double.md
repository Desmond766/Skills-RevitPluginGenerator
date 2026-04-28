---
kind: method
id: M:Autodesk.Revit.DB.Surface.Project(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.UV@,System.Double@)
zh: 项目
source: html/802cc09b-d0a4-dfc5-8ca1-e8c5e8cd4ced.htm
---
# Autodesk.Revit.DB.Surface.Project Method

**中文**: 项目

Project a 3D point orthogonally onto a surface (to find the nearest point).
 Throws InvalidOperationException if the projection fails.

## Syntax (C#)
```csharp
public void Project(
	XYZ point,
	out UV uv,
	out double distance
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The point to project.
- **uv** (`Autodesk.Revit.DB.UV %`) - The surface coordinates of the projected point.
- **distance** (`System.Double %`) - Holds the distance from input point to its projection.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The projection failed.


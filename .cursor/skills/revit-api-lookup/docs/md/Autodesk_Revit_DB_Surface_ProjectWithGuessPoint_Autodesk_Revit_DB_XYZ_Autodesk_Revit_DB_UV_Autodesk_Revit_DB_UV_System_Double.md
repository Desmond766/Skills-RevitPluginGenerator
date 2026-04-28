---
kind: method
id: M:Autodesk.Revit.DB.Surface.ProjectWithGuessPoint(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.UV,Autodesk.Revit.DB.UV@,System.Double@)
source: html/db8cc42a-9f34-611a-d9c5-852f3935887f.htm
---
# Autodesk.Revit.DB.Surface.ProjectWithGuessPoint Method

Project a 3D point orthogonally onto a surface (to find the nearest point).
 This method is meant to be used when a good approximate solution for the projection is available.
 Throws InvalidOperationException if the projection fails.

## Syntax (C#)
```csharp
public void ProjectWithGuessPoint(
	XYZ point,
	UV guessUV,
	out UV uv,
	out double distance
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The point to project.
- **guessUV** (`Autodesk.Revit.DB.UV`) - The calculation will look for a project near the provided UV.
- **uv** (`Autodesk.Revit.DB.UV %`) - The surface coordinates of the projected point.
- **distance** (`System.Double %`) - Holds the distance from input point to its projection.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The projection failed.


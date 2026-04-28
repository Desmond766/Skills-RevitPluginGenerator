---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.IsPermittedSurfaceType(Autodesk.Revit.DB.Surface)
source: html/040692f6-8493-74dc-4d6c-8b8668a2fe27.htm
---
# Autodesk.Revit.DB.BRepBuilder.IsPermittedSurfaceType Method

A validator function that checks whether the surface object is of type supported as face surface by BRepBuilder.

## Syntax (C#)
```csharp
public static bool IsPermittedSurfaceType(
	Surface surface
)
```

## Parameters
- **surface** (`Autodesk.Revit.DB.Surface`) - Surface object intended to be used as a face surface.

## Returns
True if surface of this type may be used as a face surface, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


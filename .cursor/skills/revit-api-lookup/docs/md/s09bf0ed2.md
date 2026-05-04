---
kind: method
id: M:Autodesk.Revit.DB.ViewOrientation3D.#ctor(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/882f774b-b290-14b8-2664-8f86ec42f458.htm
---
# Autodesk.Revit.DB.ViewOrientation3D.#ctor Method

Constructs a new ViewOrientation3D using the input eye position, up and forward directions.

## Syntax (C#)
```csharp
public ViewOrientation3D(
	XYZ eyePosition,
	XYZ upDirection,
	XYZ forwardDirection
)
```

## Parameters
- **eyePosition** (`Autodesk.Revit.DB.XYZ`) - The eye position
- **upDirection** (`Autodesk.Revit.DB.XYZ`) - The up direction. This vector will be normalized. Up direction must be perpendicular to the forward direction.
- **forwardDirection** (`Autodesk.Revit.DB.XYZ`) - The forward direction. This vector will be normalized. Forward direction must be perpendicular to the up direction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or both of the input vectors cannot be normalized.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - upDirection has zero length.
 -or-
 forwardDirection has zero length.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The vectors upDirection and forwardDirection are not perpendicular.


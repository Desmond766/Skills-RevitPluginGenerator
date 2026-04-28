---
kind: method
id: M:Autodesk.Revit.DB.Transform2D.#ctor(Autodesk.Revit.DB.UV,Autodesk.Revit.DB.UV,Autodesk.Revit.DB.UV)
source: html/8d260105-fb1c-b915-eb12-e038f536ee63.htm
---
# Autodesk.Revit.DB.Transform2D.#ctor Method

Constructs the transformation by specifying the vectors and the origin.

## Syntax (C#)
```csharp
public Transform2D(
	UV uVec,
	UV vVec,
	UV origin
)
```

## Parameters
- **uVec** (`Autodesk.Revit.DB.UV`) - The image of (1, 0) under OfVector(UV) .
- **vVec** (`Autodesk.Revit.DB.UV`) - The image of (0, 1) under OfVector(UV) .
- **origin** (`Autodesk.Revit.DB.UV`) - The image of (0, 0) under OfPoint(UV) .
 This defines the translational part of the transform.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


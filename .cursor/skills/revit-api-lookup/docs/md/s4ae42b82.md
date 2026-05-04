---
kind: method
id: M:Autodesk.Revit.DB.Structure.MemberForces.#ctor(System.Boolean,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/ce1dd67c-7814-f4dc-4cd8-c11e355c18f5.htm
---
# Autodesk.Revit.DB.Structure.MemberForces.#ctor Method

Creates a new instance of MemberForces.

## Syntax (C#)
```csharp
public MemberForces(
	bool start,
	XYZ force,
	XYZ moment
)
```

## Parameters
- **start** (`System.Boolean`) - Member Forces position on analytical element. True for start, false for end.
- **force** (`Autodesk.Revit.DB.XYZ`) - The Translational forces at specified position of the element.
 The x value of XYZ object represents force along x-axis of the analytical element coordinate system, y along y-axis, z along z-axis respectively.
- **moment** (`Autodesk.Revit.DB.XYZ`) - The Rotational forces at specified position of the element.
 The x value of XYZ object represents moment about x-axis of the analytical element coordinate system, y about y-axis, z about z-axis respectively.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


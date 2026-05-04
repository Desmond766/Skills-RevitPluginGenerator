---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalMember.SetMemberForces(System.Boolean,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/d72e983a-bb75-30e2-5dac-373a9c28d7cc.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalMember.SetMemberForces Method

Sets Member Forces to Analytical Member.

## Syntax (C#)
```csharp
public void SetMemberForces(
	bool start,
	XYZ force,
	XYZ moment
)
```

## Parameters
- **start** (`System.Boolean`) - Member Forces position on Analytical Member. True for start, false for end.
- **force** (`Autodesk.Revit.DB.XYZ`) - The translational forces at specified position of the element.
 The x value of XYZ object represents force along x-axis of the Analytical Member coordinate system, y along y-axis, z along z-axis respectively.
- **moment** (`Autodesk.Revit.DB.XYZ`) - The rotational forces at specified position of the element.
 The x value of XYZ object represents moment about x-axis of the Analytical Member coordinate system, y about y-axis, z about z-axis respectively.

## Remarks
If Analytical Member already have member forces defined for that end, newly provided values replace current one.
 Member forces are strictly related with releases. This means that setting member forces values is reasonable only for directions that have releases set to false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


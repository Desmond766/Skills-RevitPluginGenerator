---
kind: method
id: M:Autodesk.Revit.DB.GeometryCreationUtilities.CreateLoftGeometry(System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop},Autodesk.Revit.DB.SolidOptions)
source: html/9f58eb60-84cb-4c6b-9b06-1df8007b12e0.htm
---
# Autodesk.Revit.DB.GeometryCreationUtilities.CreateLoftGeometry Method

Creates a solid or open shell geometry by lofting between a sequence of curve loops.

## Syntax (C#)
```csharp
public static Solid CreateLoftGeometry(
	IList<CurveLoop> profileLoops,
	SolidOptions solidOptions
)
```

## Parameters
- **profileLoops** (`System.Collections.Generic.IList < CurveLoop >`) - The array of curve loops, where the order of the array determines the lofting sequence used.
- **solidOptions** (`Autodesk.Revit.DB.SolidOptions`) - The optional information to control the properties of the solid or open shell.

## Returns
The requested solid or open shell.

## Remarks
If all the curve loops are closed it will create a solid. No loop may contain just one closed curve - split such loops into two or more curves beforehand.
 If all the curve loops are open, then create an open shell.
 If there are both open and closed loops, only the first and/or last loop are allowed to be open,
 others (if they exist) must be closed. A solid will be created in this case.
 The surface of the solid or open shell will pass through these profiles blending smoothly between the profiles.
 Each profile loop must be free of intersections and degeneracies. No orientation conditions on the loops are imposed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The number of profile CurveLoops is less than 2.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


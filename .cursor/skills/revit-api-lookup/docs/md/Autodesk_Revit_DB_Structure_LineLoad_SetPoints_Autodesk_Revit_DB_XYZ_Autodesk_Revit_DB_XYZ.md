---
kind: method
id: M:Autodesk.Revit.DB.Structure.LineLoad.SetPoints(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/41589a19-523d-ab5f-d72e-4e3bd7bc020d.htm
---
# Autodesk.Revit.DB.Structure.LineLoad.SetPoints Method

Sets start and end point of the line load.

## Syntax (C#)
```csharp
public bool SetPoints(
	XYZ startPoint,
	XYZ endPoint
)
```

## Parameters
- **startPoint** (`Autodesk.Revit.DB.XYZ`) - The start point.
- **endPoint** (`Autodesk.Revit.DB.XYZ`) - The end point.

## Returns
Returns true if successful, false otherwise.

## Remarks
This method works with hosted line load only.
 This method works for loads which are not constrained to their host.
 The curve of the resulted load will be a line.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the end point is equal to the start point.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This LineLoad is not a hosted load.
 -or-
 This LineLoad is a constrained load.


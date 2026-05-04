---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaLoad.SetLoops(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
source: html/264cfd98-5af1-1019-5055-e14816eae450.htm
---
# Autodesk.Revit.DB.Structure.AreaLoad.SetLoops Method

Sets curve loops that define geometry of the area load.

## Syntax (C#)
```csharp
public bool SetLoops(
	Document doc,
	IList<CurveLoop> newLoops
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document that contains the area load.
- **newLoops** (`System.Collections.Generic.IList < CurveLoop >`) - Loops that define new geometry of the area load.
 The curve loop collection should contains a closed loops consisting of lines.

## Returns
Returns true if successful, false otherwise.

## Remarks
This method works for loads which are not constrained to their host.
 This method works with hosted area load only.
 All previously defined reference points will be removed.
 Curve Loop must be planar and not self-intersecting.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One of the following requirements is not satisfied :
 - curve loops newLoops are not planar
 - curve loops newLoops are self-intersecting
 - curve loops newLoops contains zero length curves
 -or-
 Thrown when newLoops collection is empty.
 -or-
 Thrown when newLoops contains open loop.
 -or-
 Thrown when newLoops contains a loop consisting of other elements then lines.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This AreaLoad is not a hosted load.
 -or-
 This AreaLoad is a constrained load.


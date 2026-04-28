---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalUtils.BreakCurve(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ)
source: html/baeec9be-b43d-d378-31b9-453432d44bfb.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalUtils.BreakCurve Method

Breaks the duct curve into two parts at the given position.

## Syntax (C#)
```csharp
public static ElementId BreakCurve(
	Document document,
	ElementId ductId,
	XYZ ptBreak
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **ductId** (`Autodesk.Revit.DB.ElementId`) - The element id of the duct curve to break.
- **ptBreak** (`Autodesk.Revit.DB.XYZ`) - The break point on the duct curve.

## Returns
The new duct curve element id if successful otherwise if a failure occurred an invalidElementId is returned.

## Remarks
This method is not applicable for breaking the flex duct.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - "The element is neither a duct nor a duct placeholder."
 -or-
 "The given point is not on the duct curve."
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


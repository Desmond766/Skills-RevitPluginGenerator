---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PlumbingUtils.BreakCurve(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ)
source: html/3c302b80-d1f8-0e17-154a-b809cad2e545.htm
---
# Autodesk.Revit.DB.Plumbing.PlumbingUtils.BreakCurve Method

Breaks the pipe curve into two parts at the given position.

## Syntax (C#)
```csharp
public static ElementId BreakCurve(
	Document document,
	ElementId pipeId,
	XYZ ptBreak
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **pipeId** (`Autodesk.Revit.DB.ElementId`) - The element id of the pipe curve to break.
- **ptBreak** (`Autodesk.Revit.DB.XYZ`) - The break point on the pipe curve.

## Returns
The new pipe curve element id if successful otherwise if a failure occurred an invalidElementId is returned.

## Remarks
This method is not applicable for breaking the flex pipe.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - "The element is neither a pipe nor a pipe placeholder."
 -or-
 "The given point is not on the pipe curve."
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CableTray.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/9c48be09-8466-3ad1-85a4-c0ac1eb0f9ed.htm
---
# Autodesk.Revit.DB.Electrical.CableTray.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of cable tray.

## Syntax (C#)
```csharp
public static CableTray Create(
	Document document,
	ElementId cabletrayType,
	XYZ startPoint,
	XYZ endPoint,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **cabletrayType** (`Autodesk.Revit.DB.ElementId`) - The cable tray type. This must be a cable tray type accepted by isValidCableTrayType().
 If the input cable tray type is InvalidElementId, the default cable tray type from the document will be used.
- **startPoint** (`Autodesk.Revit.DB.XYZ`) - The start point of the cable tray location line.
- **endPoint** (`Autodesk.Revit.DB.XYZ`) - The end point of the cable tray location line.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The element id of the level which this cable tray based.
 If the input level id is invalidElementId = -1, the nearest level will be used.

## Returns
The newly created cable tray.

## Remarks
This method will regenerate the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This cable tray type is invalid.
 -or-
 This level id is invalid.
 -or-
 The points of startPoint and endPoint are too close: for MEPCurve, the minimum length is 1/10 inch.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.


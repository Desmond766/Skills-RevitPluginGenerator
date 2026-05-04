---
kind: method
id: M:Autodesk.Revit.DB.Electrical.Conduit.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/d54ff31b-353b-eb13-337c-cee8abb021f7.htm
---
# Autodesk.Revit.DB.Electrical.Conduit.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of conduit.

## Syntax (C#)
```csharp
public static Conduit Create(
	Document document,
	ElementId conduitType,
	XYZ startPoint,
	XYZ endPoint,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **conduitType** (`Autodesk.Revit.DB.ElementId`) - The conduit type. This must be a conduit type accepted by isValidConduitType().
 If the input conduit type is InvalidElementId, the default conduit type from the document will be used.
- **startPoint** (`Autodesk.Revit.DB.XYZ`) - The start point of the conduit location line.
- **endPoint** (`Autodesk.Revit.DB.XYZ`) - The end point of the conduit location line.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The element id of the level which this conduit based.
 If the input level id is invalidElementId = -1, the nearest level will be used.

## Returns
The newly created conduit.

## Remarks
This method will regenerate the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This conduit type is invalid.
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


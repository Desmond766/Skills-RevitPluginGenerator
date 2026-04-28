---
kind: method
id: M:Autodesk.Revit.DB.SketchPlane.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
zh: 创建、新建、生成、建立、新增
source: html/fbd33f0f-2c2c-c001-8041-996bc0872b2b.htm
---
# Autodesk.Revit.DB.SketchPlane.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new sketch plane from a reference to a planar face.

## Syntax (C#)
```csharp
public static SketchPlane Create(
	Document document,
	Reference planarFaceReference
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **planarFaceReference** (`Autodesk.Revit.DB.Reference`) - The reference of the planar face where the sketch plane will be created.

## Returns
The newly created sketch plane.

## Remarks
A reference relationship will be created between the face and the sketch plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Sketch plane creation is not allowed in this family.
 -or-
 The reference is not a planar face.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.


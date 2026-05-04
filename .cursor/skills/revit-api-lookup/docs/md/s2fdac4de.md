---
kind: method
id: M:Autodesk.Revit.DB.SketchPlane.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Plane)
zh: 创建、新建、生成、建立、新增
source: html/25da7bd5-04d2-b50f-ff22-8e82e263f7fe.htm
---
# Autodesk.Revit.DB.SketchPlane.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new sketch plane from a geometric plane.

## Syntax (C#)
```csharp
public static SketchPlane Create(
	Document document,
	Plane plane
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **plane** (`Autodesk.Revit.DB.Plane`) - The geometry plane where the sketch plane will be created.

## Returns
The newly created sketch plane.

## Remarks
There will not be a reference relationship established from the sketch plane to the input face. To create a SketchPlane with a reference to other geometry,
 use the overload with a Reference input.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Sketch plane creation is not allowed in this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.


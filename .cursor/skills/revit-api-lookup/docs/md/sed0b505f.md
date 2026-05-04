---
kind: method
id: M:Autodesk.Revit.DB.SketchPlane.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/c121b511-bd4f-0c5a-12cb-41170cd06761.htm
---
# Autodesk.Revit.DB.SketchPlane.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a sketch plane from a grid, reference plane, or level.

## Syntax (C#)
```csharp
public static SketchPlane Create(
	Document document,
	ElementId datumId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **datumId** (`Autodesk.Revit.DB.ElementId`) - The id of the grid, reference plane, or level.

## Returns
The newly created sketch plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - datumId is not a valid Element identifier.
 -or-
 ElementId must correspond to a grid, reference plane, or level.
 -or-
 ElementId must correspond to a non-curved datum.
 -or-
 Sketch plane creation is not allowed in this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.


---
kind: method
id: M:Autodesk.Revit.DB.DividedPath.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.Reference},System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 创建、新建、生成、建立、新增
source: html/9b89e0ef-245e-80eb-0bb9-662c395a1862.htm
---
# Autodesk.Revit.DB.DividedPath.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a divided path whose points are determined by the intersecting elements.

## Syntax (C#)
```csharp
public static DividedPath Create(
	Document document,
	IList<Reference> curveReferences,
	ICollection<ElementId> intersectors
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **curveReferences** (`System.Collections.Generic.IList < Reference >`) - References that represent a connected set of curves or edges.
- **intersectors** (`System.Collections.Generic.ICollection < ElementId >`) - Elements whose intersection with the curve references result in additional divisions.

## Returns
The newly created divided path.

## Remarks
Intersectors can be curve elements, datum planes, or other divided paths.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document does not allow creation of a divided path.
 -or-
 Not all curve references in curveReferences represent a curve or an edge
 -or-
 The references in curveReferences are not connected.
 -or-
 Not all intersecting elements in intersectors are valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
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


---
kind: method
id: M:Autodesk.Revit.DB.DividedPath.Create(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.Reference})
zh: 创建、新建、生成、建立、新增
source: html/8e016f5f-7954-56a9-2759-17fb68b9e147.htm
---
# Autodesk.Revit.DB.DividedPath.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a divided path with a default layout.

## Syntax (C#)
```csharp
public static DividedPath Create(
	Document document,
	IList<Reference> curveReferences
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **curveReferences** (`System.Collections.Generic.IList < Reference >`) - References that represent a connected set of curves or edges.

## Returns
The newly created divided path.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document does not allow creation of a divided path.
 -or-
 Not all curve references in curveReferences represent a curve or an edge
 -or-
 The references in curveReferences are not connected.
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


---
kind: method
id: M:Autodesk.Revit.DB.Document.Delete(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 删除、移除
source: html/f4ce9113-b164-954e-5025-7b4edbdcc07d.htm
---
# Autodesk.Revit.DB.Document.Delete Method

**中文**: 删除、移除

Deletes a set of elements from the document.

## Syntax (C#)
```csharp
public ICollection<ElementId> Delete(
	ICollection<ElementId> elementIds
)
```

## Parameters
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The ids of the elements to delete.

## Returns
The deleted element id set.

## Remarks
This method will delete the elements and any elements that are totally dependent upon that element. Any references to the deleted elements will become invalid and hence cause an exception to be thrown if they are accessed.
 The elements will be deleted with no prompts for user confirmation. Pinned elements will be deleted with no warnings.
 Note: in a family document, the predefined elements (those elements inherited from its family template file) can't be deleted by this method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more elements in elementIds do not exist in the document.
 -or-
 One or more of the elementIds cannot be deleted.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.


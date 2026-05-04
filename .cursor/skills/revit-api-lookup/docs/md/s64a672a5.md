---
kind: method
id: M:Autodesk.Revit.DB.Document.GetUnusedElements(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
zh: 文档、文件
source: html/dcb1f497-dfa6-bb3a-b9dd-f9a580f990f2.htm
---
# Autodesk.Revit.DB.Document.GetUnusedElements Method

**中文**: 文档、文件

Returns the list of element ids that are not used and can be deleted from the document.

## Syntax (C#)
```csharp
public ISet<ElementId> GetUnusedElements(
	ISet<ElementId> categories
)
```

## Parameters
- **categories** (`System.Collections.Generic.ISet < ElementId >`) - Collection of categories to check for unused elements.

## Returns
Unused elements that can be deleted from the document.

## Remarks
This method returns unused element ids that are available in the Purge Unused window in the Revit.
 To get unused elements that do not have a category assigned add
 INVALID to the collection of categories.
 If the input categories collection is empty, the method returns all unused elements in the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


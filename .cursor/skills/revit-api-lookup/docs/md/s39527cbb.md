---
kind: method
id: M:Autodesk.Revit.DB.Document.GetAllUnusedElements(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
zh: 文档、文件
source: html/fc50a373-b2a9-8839-14c1-e64b693e445c.htm
---
# Autodesk.Revit.DB.Document.GetAllUnusedElements Method

**中文**: 文档、文件

Returns the list of element ids that are not used. The list of unused element ids may include elements that can't be deleted.

## Syntax (C#)
```csharp
public ISet<ElementId> GetAllUnusedElements(
	ISet<ElementId> categories
)
```

## Parameters
- **categories** (`System.Collections.Generic.ISet < ElementId >`) - Collection of categories to check for unused elements.

## Returns
Unused element ids.

## Remarks
This method returns unused element ids that are available in the Purge Unused window in the Revit, including elements that can't be deleted.
 To get unused elements that do not have a category assigned add
 INVALID to the collection of categories.
 If the input categories collection is empty, the method returns all unused elements in the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


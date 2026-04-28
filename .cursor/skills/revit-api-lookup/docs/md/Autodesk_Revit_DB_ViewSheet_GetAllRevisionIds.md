---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.GetAllRevisionIds
zh: 图纸
source: html/e6f4e79f-c076-8085-5288-6e0b5a431177.htm
---
# Autodesk.Revit.DB.ViewSheet.GetAllRevisionIds Method

**中文**: 图纸

Gets the ordered array of Revisions which participate in the sheet's revision schedules.

## Syntax (C#)
```csharp
public IList<ElementId> GetAllRevisionIds()
```

## Returns
The ordered array of ids of Revisions participating in the sheet's revision schedules.

## Remarks
The Revisions are ordered according to the revision sequence in the project.
 A Revision is considered to be participating in revision scheduling on the sheet
 if either a revision cloud belonging to that Revision is visible on the sheet or the Revision
 has been explicitly included using the Revisions On Sheet parameter.


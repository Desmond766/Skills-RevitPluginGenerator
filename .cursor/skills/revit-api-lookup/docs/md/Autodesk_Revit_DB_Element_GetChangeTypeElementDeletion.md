---
kind: method
id: M:Autodesk.Revit.DB.Element.GetChangeTypeElementDeletion
zh: 构件、图元、元素
source: html/d2f0d0dd-d01b-3296-8248-068baec486cf.htm
---
# Autodesk.Revit.DB.Element.GetChangeTypeElementDeletion Method

**中文**: 构件、图元、元素

Returns ChangeType associated with element deletion.

## Syntax (C#)
```csharp
public static ChangeType GetChangeTypeElementDeletion()
```

## Returns
ChangeType that can be used to define a trigger for an Updater,
 triggering on element deletion.

## Remarks
ChangeType that can be used to define a trigger for an Updater,
 Use this change type to trigger an Updater on the deletion of elements from a document.
 Note: This change type will not trigger on changes caused by Undo and Redo.


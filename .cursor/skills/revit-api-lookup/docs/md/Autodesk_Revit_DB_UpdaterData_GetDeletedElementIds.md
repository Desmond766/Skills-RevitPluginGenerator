---
kind: method
id: M:Autodesk.Revit.DB.UpdaterData.GetDeletedElementIds
source: html/d19575f3-a6cb-c532-78a2-2b513378af4a.htm
---
# Autodesk.Revit.DB.UpdaterData.GetDeletedElementIds Method

Returns set of elements that were deleted from the document.
 This set is mutually exclusive of elements returned by getAddedElementIds() and getModifiedElementIds().

## Syntax (C#)
```csharp
public ICollection<ElementId> GetDeletedElementIds()
```

## Returns
Set of elements that were deleted from the document and triggered the call to execute()
 Note: This will only return elements if the trigger registered for the associated updater
 contains the ChangeType returned by Element::getChangeTypeElementDeletion()


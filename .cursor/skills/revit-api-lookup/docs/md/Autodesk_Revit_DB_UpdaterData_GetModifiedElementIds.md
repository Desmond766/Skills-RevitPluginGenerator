---
kind: method
id: M:Autodesk.Revit.DB.UpdaterData.GetModifiedElementIds
source: html/f06a0804-5756-47e7-3dc3-bcc828e5adaf.htm
---
# Autodesk.Revit.DB.UpdaterData.GetModifiedElementIds Method

Returns set of elements that were modified.
 This set is mutually exclusive of elements returned by getAddedElementIds() and getDeletedElementIds().

## Syntax (C#)
```csharp
public ICollection<ElementId> GetModifiedElementIds()
```

## Returns
Set of elements that were modified in the document and triggered the call to execute()
 Note: This set only contains modified elements (i.e. it is mutually exclusive of elements returned
 by getAddedElementIds() and getDeletedElementIds()). It does not contain any elements that were
 added to or deleted from the document during the current transaction.
 Newly added/deleted elements will be reported by getAddedElementIds()/getDeletedElementIds(),
 even if they were also modified during the same transaction, but only if ChangeTypeElementAddition/Deletion
 is registered as a trigger for the current Updater. I.e. Element creation and modification in
 the same transaction is considered to be "creation" only. Newly created elements are not considered to be
 "modified" and are therefore not returned as part of getModifiedElementIds()


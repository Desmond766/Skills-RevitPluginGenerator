---
kind: method
id: M:Autodesk.Revit.DB.UpdaterData.GetAddedElementIds
source: html/b9676f82-ebc4-79f8-160e-4d3c4c1823a2.htm
---
# Autodesk.Revit.DB.UpdaterData.GetAddedElementIds Method

Returns set of elements newly added to the document.
 This set is mutually exclusive of elements returned by getDeletedElementIds() and getModifiedElementIds().

## Syntax (C#)
```csharp
public ICollection<ElementId> GetAddedElementIds()
```

## Returns
Set of elements that were added to the document and triggered the call to execute()
 Note: This will only return elements if the trigger registered for the associated updater
 contains the ChangeType returned by Element::getChangeTypeElementAddition()


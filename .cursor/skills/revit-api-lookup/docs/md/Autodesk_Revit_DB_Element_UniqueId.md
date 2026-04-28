---
kind: property
id: P:Autodesk.Revit.DB.Element.UniqueId
zh: 构件、图元、元素
source: html/f9a9cb77-6913-6d41-ecf5-4398a24e8ff8.htm
---
# Autodesk.Revit.DB.Element.UniqueId Property

**中文**: 构件、图元、元素

A stable unique identifier for an element within the document.

## Syntax (C#)
```csharp
public string UniqueId { get; }
```

## Remarks
The UniqueId can be used to store an identifier in an external database and to retrieve the same element in the future if it still exists.
 This id can be passed to the Document's Element property to retrieve the element. The UniqueId is stable across upgrades and workset
 operations such as Save To Central, while the ElementId property may change.


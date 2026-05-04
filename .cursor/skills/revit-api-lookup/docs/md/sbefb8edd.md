---
kind: method
id: M:Autodesk.Revit.DB.Element.GetTypeId
zh: 构件、图元、元素
source: html/cc66ca8e-302e-f072-edca-d847bcf14c86.htm
---
# Autodesk.Revit.DB.Element.GetTypeId Method

**中文**: 构件、图元、元素

Returns the identifier of this element's type.

## Syntax (C#)
```csharp
public ElementId GetTypeId()
```

## Returns
The id of the element's type, or invalid element id if the element cannot have type assigned.

## Remarks
Some elements cannot have type assigned,
 in which case this method returns invalid element id.


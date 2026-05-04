---
kind: method
id: M:Autodesk.Revit.DB.Element.CanHaveTypeAssigned
zh: 构件、图元、元素
source: html/051e2945-b690-5387-d083-7cdb7cb75332.htm
---
# Autodesk.Revit.DB.Element.CanHaveTypeAssigned Method

**中文**: 构件、图元、元素

Identifies if the element can have a type assigned.

## Syntax (C#)
```csharp
public bool CanHaveTypeAssigned()
```

## Returns
True if element can have a type assigned, false otherwise.

## Remarks
Some elements cannot have type assigned,
 in which case invalid element id is considered to be their type id.


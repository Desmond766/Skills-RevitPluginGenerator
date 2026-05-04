---
kind: method
id: M:Autodesk.Revit.DB.Subelement.CanHaveTypeAssigned
source: html/dec0c104-7808-4f07-9eb4-c9247cc3a65a.htm
---
# Autodesk.Revit.DB.Subelement.CanHaveTypeAssigned Method

Identifies if the subelement can have a type assigned.

## Syntax (C#)
```csharp
public bool CanHaveTypeAssigned()
```

## Returns
True if subelement can have a type assigned, false otherwise.

## Remarks
Some subelements cannot have type assigned,
 in which case invalid element id is considered to be their type id.


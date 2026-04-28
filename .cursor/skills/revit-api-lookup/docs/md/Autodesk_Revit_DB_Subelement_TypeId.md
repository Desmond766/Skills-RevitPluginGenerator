---
kind: property
id: P:Autodesk.Revit.DB.Subelement.TypeId
source: html/3480a4eb-8b80-c694-6a9b-9c5559cac920.htm
---
# Autodesk.Revit.DB.Subelement.TypeId Property

The identifier of this subelement's type.

## Syntax (C#)
```csharp
public ElementId TypeId { get; }
```

## Remarks
Some subelements cannot have type assigned,
 in which case this method returns invalid element id.


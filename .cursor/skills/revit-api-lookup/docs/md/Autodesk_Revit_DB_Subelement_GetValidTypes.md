---
kind: method
id: M:Autodesk.Revit.DB.Subelement.GetValidTypes
source: html/e39919d5-4bca-bdf4-4e24-c73e03cf147a.htm
---
# Autodesk.Revit.DB.Subelement.GetValidTypes Method

Obtains a set of types that are valid for this subelement.

## Syntax (C#)
```csharp
public ISet<ElementId> GetValidTypes()
```

## Returns
A set of element IDs of types that are valid for this subelement or an empty set if subelement cannot have type assigned.

## Remarks
A type is valid for a subelement if it can be assigned to the subelement.


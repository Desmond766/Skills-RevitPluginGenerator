---
kind: property
id: P:Autodesk.Revit.DB.ElementType.FamilyName
source: html/10de5c66-1b4b-9214-4036-27a6b24e5703.htm
---
# Autodesk.Revit.DB.ElementType.FamilyName Property

Gets the family name of this element type.

## Syntax (C#)
```csharp
public string FamilyName { get; }
```

## Remarks
This value is a localized string describing the family in which this ElementType
 belongs. For family symbols, this will be the name of the associated Family.
 For system family types, this will be the name used to group related types,
 such as "Oval Duct" or "Curtain Wall".


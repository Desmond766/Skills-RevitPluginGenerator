---
kind: property
id: P:Autodesk.Revit.DB.FamilyManager.CurrentType
source: html/3d37cd81-48ba-4011-82bc-dbb7ae14b270.htm
---
# Autodesk.Revit.DB.FamilyManager.CurrentType Property

The current family type.

## Syntax (C#)
```csharp
public FamilyType CurrentType { get; set; }
```

## Remarks
Only the current family type is editable using the methods 
in FamilyManager . If you want to modify the properties of
any family type, it must be set to be the current type first.
This value will be Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no type in the family. In order 
to modify parameter values, you will need to create one using 
 NewType(String) .


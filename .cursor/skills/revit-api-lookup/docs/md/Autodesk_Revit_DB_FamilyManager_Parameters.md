---
kind: property
id: P:Autodesk.Revit.DB.FamilyManager.Parameters
source: html/bef4c199-44d9-63b9-80e7-1a6b20a1062a.htm
---
# Autodesk.Revit.DB.FamilyManager.Parameters Property

All family parameters in this family.

## Syntax (C#)
```csharp
public FamilyParameterSet Parameters { get; }
```

## Remarks
These parameters will include the 'family parameter', 'shared parameter' and
'builtIn parameter' binding to the family types.
Some parameters might be created as placeholders without a currently assigned value.


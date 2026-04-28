---
kind: property
id: P:Autodesk.Revit.DB.FamilySymbol.IsActive
zh: 族类型、族符号
source: html/69706e35-87cc-a6d9-68fe-90a41c1c48db.htm
---
# Autodesk.Revit.DB.FamilySymbol.IsActive Property

**中文**: 族类型、族符号

Identifies whether the symbol is active.

## Syntax (C#)
```csharp
public bool IsActive { get; }
```

## Remarks
Symbols that are not used in the document may be deactivated to conserve memory and regeneration time.
 When the symbol is inactive, its geometry is empty and cannot be accessed.
 In order to access the geometry of a symbol that is not active in the document,
 the symbol should first be activated by calling Activate () () () .


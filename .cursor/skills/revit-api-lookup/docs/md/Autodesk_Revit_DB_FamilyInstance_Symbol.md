---
kind: property
id: P:Autodesk.Revit.DB.FamilyInstance.Symbol
zh: 族实例
source: html/4157fff5-cde3-cbb7-1df8-03f77d64712f.htm
---
# Autodesk.Revit.DB.FamilyInstance.Symbol Property

**中文**: 族实例

Returns or changes the FamilySymbol object that represents the type of the instance.

## Syntax (C#)
```csharp
public FamilySymbol Symbol { get; set; }
```

## Remarks
Setting this property will result in the type of the instance being changed. Related types
can be found by examining the Family to which the symbol belongs.


---
kind: property
id: P:Autodesk.Revit.DB.FamilyManager.Parameter(Autodesk.Revit.DB.BuiltInParameter)
zh: 参数、共享参数
source: html/58f07dc1-aa80-65d8-a7f7-d60b32366d11.htm
---
# Autodesk.Revit.DB.FamilyManager.Parameter Property

**中文**: 参数、共享参数

Obtains the parameter of this type with a given parameter id.

## Syntax (C#)
```csharp
public FamilyParameter this[
	BuiltInParameter parameterId
] { get; }
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.BuiltInParameter`)

## Remarks
Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if the parameter is not found.


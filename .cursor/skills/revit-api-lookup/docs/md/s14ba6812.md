---
kind: property
id: P:Autodesk.Revit.DB.FamilyManager.Parameter(System.String)
zh: 参数、共享参数
source: html/13bf2342-3818-d75b-110c-062d034f2cbd.htm
---
# Autodesk.Revit.DB.FamilyManager.Parameter Property

**中文**: 参数、共享参数

Obtains the parameter of this type with a given name.

## Syntax (C#)
```csharp
public FamilyParameter this[
	string parameterName
] { get; }
```

## Parameters
- **parameterName** (`System.String`)

## Remarks
Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if the parameter is not found.


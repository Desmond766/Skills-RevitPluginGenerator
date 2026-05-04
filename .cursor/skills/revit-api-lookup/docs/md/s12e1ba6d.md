---
kind: property
id: P:Autodesk.Revit.DB.FamilyManager.Parameter(Autodesk.Revit.DB.Definition)
zh: 参数、共享参数
source: html/a34849d3-53a8-fe8d-c441-274480da38d2.htm
---
# Autodesk.Revit.DB.FamilyManager.Parameter Property

**中文**: 参数、共享参数

Obtains the parameter of this type with a given definition.

## Syntax (C#)
```csharp
public FamilyParameter this[
	Definition definition
] { get; }
```

## Parameters
- **definition** (`Autodesk.Revit.DB.Definition`)

## Remarks
Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if the parameter is not found.


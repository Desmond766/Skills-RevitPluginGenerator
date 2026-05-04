---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarReinforcementData.Create(Autodesk.Revit.DB.ElementId,System.Int32)
zh: 创建、新建、生成、建立、新增
source: html/3be68918-5d12-01f9-c267-b44717592bd4.htm
---
# Autodesk.Revit.DB.Structure.RebarReinforcementData.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of RebarReinforcementData, or Nothing nullptr a null reference ( Nothing in Visual Basic) if the operation fails.

## Syntax (C#)
```csharp
public static RebarReinforcementData Create(
	ElementId rebarId,
	int iEnd
)
```

## Parameters
- **rebarId** (`Autodesk.Revit.DB.ElementId`) - the Id of the rebar
- **iEnd** (`System.Int32`) - The end of rebar where the coupler stays. This should be 0 or 1

## Returns
Creates a new instance of RebarReinforcementData

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


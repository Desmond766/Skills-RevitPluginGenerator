---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarCoupler.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Structure.ReinforcementData,Autodesk.Revit.DB.Structure.ReinforcementData,Autodesk.Revit.DB.Structure.RebarCouplerError@)
zh: 创建、新建、生成、建立、新增
source: html/52fc10f6-e5b0-0f47-20fa-90be57b48004.htm
---
# Autodesk.Revit.DB.Structure.RebarCoupler.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a Rebar Coupler element within the project.

## Syntax (C#)
```csharp
public static RebarCoupler Create(
	Document doc,
	ElementId typeId,
	ReinforcementData pFirstData,
	ReinforcementData pSecondData,
	out RebarCouplerError error
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A document.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - type id for coupler
- **pFirstData** (`Autodesk.Revit.DB.Structure.ReinforcementData`) - information about the first reinforcement to be coupled
- **pSecondData** (`Autodesk.Revit.DB.Structure.ReinforcementData`) - information about the second reinforcement to be coupled;
 if a nullptr is passed in the coupler is placed on one reinforcement
- **error** (`Autodesk.Revit.DB.Structure.RebarCouplerError %`) - will be ValidationSuccesfully(0) if ok, otherwise the failure reason

## Returns
The newly created Rebar Coupler instance, or Nothing nullptr a null reference ( Nothing in Visual Basic) if the operation fails.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration


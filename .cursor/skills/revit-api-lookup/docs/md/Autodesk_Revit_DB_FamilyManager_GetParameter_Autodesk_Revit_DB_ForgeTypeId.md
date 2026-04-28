---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.GetParameter(Autodesk.Revit.DB.ForgeTypeId)
source: html/9c22c68a-8fd5-850e-9aa8-cf7298ceebd0.htm
---
# Autodesk.Revit.DB.FamilyManager.GetParameter Method

Obtains the family parameter with the given built-in parameter identifier.

## Syntax (C#)
```csharp
public FamilyParameter GetParameter(
	ForgeTypeId parameterTypeId
)
```

## Parameters
- **parameterTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the built-in parameter.

## Remarks
Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if the parameter is not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - parameterTypeId does not identify a built-in parameter. See Parameter.IsBuiltInParameter(ForgeTypeId) and Parameter.GetParameterTypeId(BuiltInParameter).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL


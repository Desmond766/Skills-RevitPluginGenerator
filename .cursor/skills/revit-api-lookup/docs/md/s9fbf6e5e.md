---
kind: method
id: M:Autodesk.Revit.DB.ParameterUtils.GetBuiltInParameter(Autodesk.Revit.DB.ForgeTypeId)
source: html/9b2b9b94-5220-0e9f-d259-c05faaf86625.htm
---
# Autodesk.Revit.DB.ParameterUtils.GetBuiltInParameter Method

Gets the BuiltInParameter value corresponding to built-in parameter identified by the given ForgeTypeId.

## Syntax (C#)
```csharp
public static BuiltInParameter GetBuiltInParameter(
	ForgeTypeId parameterTypeId
)
```

## Parameters
- **parameterTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The parameter identifier.

## Returns
The BuiltInParameter value corresponding to the given parameter identifier.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - parameterTypeId is not a built-in parameter identifier. See IsBuiltInParameter(ForgeTypeId) and GetParameterTypeId(BuiltInParameter).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL


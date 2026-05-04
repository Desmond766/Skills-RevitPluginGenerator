---
kind: method
id: M:Autodesk.Revit.DB.ParameterUtils.IsBuiltInParameter(Autodesk.Revit.DB.ForgeTypeId)
source: html/dd94c332-1755-910b-d3db-65ad9d396ce1.htm
---
# Autodesk.Revit.DB.ParameterUtils.IsBuiltInParameter Method

Checks whether a ForgeTypeId identifies a built-in parameter.

## Syntax (C#)
```csharp
public static bool IsBuiltInParameter(
	ForgeTypeId parameterTypeId
)
```

## Parameters
- **parameterTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier to check.

## Returns
True if the ForgeTypeId identifies a built-in parameter, false otherwise.

## Remarks
A ForgeTypeId identifies a built-in parameter if it corresponds to a valid BuiltInParameter value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


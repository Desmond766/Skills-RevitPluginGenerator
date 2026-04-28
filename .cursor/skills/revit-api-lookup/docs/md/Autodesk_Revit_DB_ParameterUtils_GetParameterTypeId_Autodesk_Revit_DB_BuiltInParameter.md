---
kind: method
id: M:Autodesk.Revit.DB.ParameterUtils.GetParameterTypeId(Autodesk.Revit.DB.BuiltInParameter)
source: html/7756d26f-c271-8259-b668-5e8eb888b29e.htm
---
# Autodesk.Revit.DB.ParameterUtils.GetParameterTypeId Method

Gets the ForgeTypeId identifying the built-in parameter corresponding to the given BuiltInParameter value.

## Syntax (C#)
```csharp
public static ForgeTypeId GetParameterTypeId(
	BuiltInParameter builtInParam
)
```

## Parameters
- **builtInParam** (`Autodesk.Revit.DB.BuiltInParameter`) - The BuiltInParameter value.

## Returns
Identifier of the parameter corresponding to the given BuiltInParameter value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration


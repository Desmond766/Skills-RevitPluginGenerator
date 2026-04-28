---
kind: method
id: M:Autodesk.Revit.DB.ParameterUtils.GetParameterGroupTypeId(Autodesk.Revit.DB.BuiltInParameterGroup)
source: html/51728d1e-61d4-ecd3-5219-0dd007ec855c.htm
---
# Autodesk.Revit.DB.ParameterUtils.GetParameterGroupTypeId Method

Gets the ForgeTypeId identifying the built-in parameter group corresponding to BuiltInParameterGroup value.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 and may be removed in a future version of Revit. Please use members of the `GroupTypeId` class instead.")]
public static ForgeTypeId GetParameterGroupTypeId(
	BuiltInParameterGroup builtInParamGroup
)
```

## Parameters
- **builtInParamGroup** (`Autodesk.Revit.DB.BuiltInParameterGroup`) - The BuiltInParameterGroup value.

## Returns
Identifier of the parameter group corresponding to the given BuiltInParameterGroup value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration


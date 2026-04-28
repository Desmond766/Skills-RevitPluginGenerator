---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelFor(Autodesk.Revit.DB.BuiltInParameterGroup)
source: html/b48d806c-d7c5-7638-c6f8-041495c5d783.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelFor Method

Gets the user-visible name for a BuiltInParameterGroup.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 and may be removed in a future version of Revit. Please use the `GetLabelForGroup(ForgeTypeId)` method instead.")]
public static string GetLabelFor(
	BuiltInParameterGroup builtInParamGroup
)
```

## Parameters
- **builtInParamGroup** (`Autodesk.Revit.DB.BuiltInParameterGroup`) - The BuiltInParameterGroup to get the user-visible name.

## Remarks
The name is obtained in the current Revit language.


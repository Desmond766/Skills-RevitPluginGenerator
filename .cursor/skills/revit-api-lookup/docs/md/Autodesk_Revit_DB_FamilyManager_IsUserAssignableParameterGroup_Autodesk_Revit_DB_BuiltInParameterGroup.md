---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.IsUserAssignableParameterGroup(Autodesk.Revit.DB.BuiltInParameterGroup)
source: html/2c81a719-de51-f897-7f7b-8960a502e1de.htm
---
# Autodesk.Revit.DB.FamilyManager.IsUserAssignableParameterGroup Method

Checks if the given parameter group can be assigned to new parameters.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 and may be removed in a future version of Revit. Please use the `IsUserAssignableParameterGroup(ForgeTypeId)` method instead.")]
public bool IsUserAssignableParameterGroup(
	BuiltInParameterGroup parameterGroup
)
```

## Parameters
- **parameterGroup** (`Autodesk.Revit.DB.BuiltInParameterGroup`)

## Returns
True if the parameter group can be assigned to new parameters, false otherwise.


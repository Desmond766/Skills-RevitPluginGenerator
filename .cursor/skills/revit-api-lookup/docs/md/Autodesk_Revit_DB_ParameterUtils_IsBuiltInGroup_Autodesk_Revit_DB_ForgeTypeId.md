---
kind: method
id: M:Autodesk.Revit.DB.ParameterUtils.IsBuiltInGroup(Autodesk.Revit.DB.ForgeTypeId)
source: html/50a42579-6e5e-7f9d-30ff-fdf41036c8e7.htm
---
# Autodesk.Revit.DB.ParameterUtils.IsBuiltInGroup Method

Checks whether a ForgeTypeId identifies a built-in parameter group.

## Syntax (C#)
```csharp
public static bool IsBuiltInGroup(
	ForgeTypeId groupTypeId
)
```

## Parameters
- **groupTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier to check.

## Returns
True if the ForgeTypeId identifies a built-in parameter group, false otherwise.

## Remarks
A ForgeTypeId identifies a built-in parameter group if it corresponds to a valid BuiltInParameterGroup value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


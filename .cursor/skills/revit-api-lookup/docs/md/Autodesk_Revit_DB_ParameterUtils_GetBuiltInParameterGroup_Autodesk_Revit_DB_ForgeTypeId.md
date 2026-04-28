---
kind: method
id: M:Autodesk.Revit.DB.ParameterUtils.GetBuiltInParameterGroup(Autodesk.Revit.DB.ForgeTypeId)
source: html/3703f1ea-a444-518c-7112-e9a1303dac12.htm
---
# Autodesk.Revit.DB.ParameterUtils.GetBuiltInParameterGroup Method

Gets the BuiltInParameterGroup value corresponding to built-in parameter group identified by the given ForgeTypeId.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 and may be removed in a future version of Revit. Please use members of the `GroupTypeId` class instead.")]
public static BuiltInParameterGroup GetBuiltInParameterGroup(
	ForgeTypeId groupTypeId
)
```

## Parameters
- **groupTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The parameter group identifier.

## Returns
The BuiltInParameterGroup value corresponding to the given parameter group identifier.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - groupTypeId is not a built-in parameter group identifier. See IsBuiltInParameterGroup(ForgeTypeId) and GetParameterGroupTypeId(BuiltInParameter).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL


---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelForGroup(Autodesk.Revit.DB.ForgeTypeId)
source: html/fad046bf-b6c9-35cd-69f2-1d556ddbbc05.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelForGroup Method

Gets the user-visible name for a built-in parameter group. To get the name of parameter group "Other", pass an empty, default-constructed ForgeTypeId.

## Syntax (C#)
```csharp
public static string GetLabelForGroup(
	ForgeTypeId groupTypeId
)
```

## Parameters
- **groupTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier of the parameter group to get the user-visible name, or an empty ForgeTypeId for group "Other".

## Remarks
The name is obtained in the current Revit language.


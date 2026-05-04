---
kind: method
id: M:Autodesk.Revit.DB.InternalDefinition.SetGroupTypeId(Autodesk.Revit.DB.ForgeTypeId)
source: html/62a8a155-a7a6-e019-8cd8-9a7c9b4cd80a.htm
---
# Autodesk.Revit.DB.InternalDefinition.SetGroupTypeId Method

Sets the built-in parameter group to which the parameter defined by this definition belongs.

## Syntax (C#)
```csharp
public void SetGroupTypeId(
	ForgeTypeId groupTypeId
)
```

## Parameters
- **groupTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the built-in parameter group.

## Remarks
The parameter group can be changed, but only for parameters that are not built in.
In other words: This method is only valid for parameter definitions for which
GetParameterTypeId() returns a null identifier.


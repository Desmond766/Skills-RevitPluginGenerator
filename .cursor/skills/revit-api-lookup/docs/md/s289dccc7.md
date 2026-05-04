---
kind: method
id: M:Autodesk.Revit.DB.InternalDefinition.GetParameterTypeId
source: html/02934b67-77bc-c8f7-4a3d-4c57ffec4682.htm
---
# Autodesk.Revit.DB.InternalDefinition.GetParameterTypeId Method

Tests whether this definition identifies a built-in parameter or not.

## Syntax (C#)
```csharp
public ForgeTypeId GetParameterTypeId()
```

## Remarks
For a built-in parameter this method returns one of the ParameterTypeId static properties.
For custom-defined parameters, such as shared, global, or family parameters the value is null.


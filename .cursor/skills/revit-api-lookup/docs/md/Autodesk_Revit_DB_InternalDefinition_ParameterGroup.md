---
kind: property
id: P:Autodesk.Revit.DB.InternalDefinition.ParameterGroup
source: html/bc927bca-8fbe-9f2d-8acb-785f65c57969.htm
---
# Autodesk.Revit.DB.InternalDefinition.ParameterGroup Property

Id of a built-in parameter group to which the parameter defined by this definition belongs.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This property is deprecated in Revit 2024 and may be removed in a future version of Revit. Please use the `GetGroupTypeId()` method instead.")]
public override BuiltInParameterGroup ParameterGroup { get; set; }
```

## Remarks
The parameter group can be changed, but only for parameters that are not built in.
In other words: Modifying the value of this property is only valid for parameter definitions
whose BuiltInParameter property returns BuiltInParameter.INVALID, e.g. Global Parameters.


---
kind: method
id: M:Autodesk.Revit.DB.Definition.GetDataType
source: html/1c008d27-9e61-362c-308c-8b718ee0f8df.htm
---
# Autodesk.Revit.DB.Definition.GetDataType Method

Gets a ForgeTypeId identifying the data type describing values of the parameter.

## Syntax (C#)
```csharp
public ForgeTypeId GetDataType()
```

## Returns
A ForgeTypeId identifying the data type of the parameter or an empty ForgeTypeId.

## Remarks
The returned ForgeTypeId may be empty or may identify either a spec or a
 category. When it is a category, it indicates a Family Type
 parameter of that category. See 
 Parameter.IsSpec(ForgeTypeId), 
 UnitUtils.IsMeasurableSpec(ForgeTypeId),
 Category.IsBuiltInCategory(ForgeTypeId), and
 Parameter.IsValidDataType(ForgeTypeId).
Some built-in parameters, such as those for color or level, have special data types which are not
 available for use with user-defined parameters and which have no representation in the Revit user
 interface or API. For these built-in parameters, this method returns an empty ForgeTypeId instance.


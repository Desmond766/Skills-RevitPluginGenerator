---
kind: method
id: M:Autodesk.Revit.DB.Element.GetParameter(Autodesk.Revit.DB.ForgeTypeId)
zh: 构件、图元、元素
source: html/fc4e5245-d2e5-e31d-a6e3-177106e75e10.htm
---
# Autodesk.Revit.DB.Element.GetParameter Method

**中文**: 构件、图元、元素

Retrieves a parameter from the element given identifier.

## Syntax (C#)
```csharp
public Parameter GetParameter(
	ForgeTypeId parameterTypeId
)
```

## Parameters
- **parameterTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the built-in parameter.

## Remarks
Parameters are a generic form of data storage within elements. The parameters are visible
through the Autodesk Revit user interface in the Element Properties dialog. This method uses a
built in parameter identifier to access the parameter. Autodesk Revit has a large number of built in
parameters that are available via static properties.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - parameterTypeId does not identify a built-in parameter. See Parameter.IsBuiltInParameter(ForgeTypeId) and Parameter.GetParameterTypeId(BuiltInParameter).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL


---
kind: property
id: P:Autodesk.Revit.DB.Element.Parameter(Autodesk.Revit.DB.BuiltInParameter)
zh: 参数、共享参数
source: html/2f91a9f3-7f69-72f9-08d6-a2d71dfb33db.htm
---
# Autodesk.Revit.DB.Element.Parameter Property

**中文**: 参数、共享参数

Retrieves a parameter from the element given a parameter id.

## Syntax (C#)
```csharp
public Parameter this[
	BuiltInParameter parameterId
] { get; }
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.BuiltInParameter`) - The built in parameter id of the parameter to be retrieved.

## Remarks
Parameters are a generic form of data storage within elements. The parameters are visible
through the Autodesk Revit user interface in the Element Properties dialog. This method uses a
built in parameter id to access the parameter. Autodesk Revit has a large number of built in
parameters that are available via an enumerated type.


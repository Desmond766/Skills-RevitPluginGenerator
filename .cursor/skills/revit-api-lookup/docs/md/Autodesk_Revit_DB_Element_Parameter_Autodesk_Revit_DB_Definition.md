---
kind: property
id: P:Autodesk.Revit.DB.Element.Parameter(Autodesk.Revit.DB.Definition)
zh: 参数、共享参数
source: html/87d8a88c-906e-85a9-f575-f263788b8584.htm
---
# Autodesk.Revit.DB.Element.Parameter Property

**中文**: 参数、共享参数

Retrieves a parameter from the element based on its definition.

## Syntax (C#)
```csharp
public Parameter this[
	Definition definition
] { get; }
```

## Parameters
- **definition** (`Autodesk.Revit.DB.Definition`) - The internal or external definition of the parameter.

## Remarks
Parameters are a generic form of data storage within elements. The parameters are visible
through the Autodesk Revit user interface in the Element Properties dialog. An element can only
have one instance of a parameter with a specific definition. By using this method you can retrieve that parameter based on definition.


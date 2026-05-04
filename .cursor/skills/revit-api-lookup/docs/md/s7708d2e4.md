---
kind: method
id: M:Autodesk.Revit.DB.FormulaManager.Validate(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Document,System.String)
zh: 检查、审查、校验
source: html/8902b8e3-f037-a63a-a39b-0cf4dc78d371.htm
---
# Autodesk.Revit.DB.FormulaManager.Validate Method

**中文**: 检查、审查、校验

Validates the formuls

## Syntax (C#)
```csharp
public static string Validate(
	ElementId parameterId,
	Document document,
	string formula
)
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.ElementId`)
- **document** (`Autodesk.Revit.DB.Document`)
- **formula** (`System.String`)

## Remarks
It validates formula using list of global or family parameters depends on document type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


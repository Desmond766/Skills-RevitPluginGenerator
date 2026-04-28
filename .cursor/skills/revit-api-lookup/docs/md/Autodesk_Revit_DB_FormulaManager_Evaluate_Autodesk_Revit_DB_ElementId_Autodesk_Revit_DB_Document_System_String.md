---
kind: method
id: M:Autodesk.Revit.DB.FormulaManager.Evaluate(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Document,System.String)
source: html/89de4a10-562f-977f-02be-9f0333fad993.htm
---
# Autodesk.Revit.DB.FormulaManager.Evaluate Method

Evaluates value of the formula

## Syntax (C#)
```csharp
public static string Evaluate(
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
It evaluates formula using list of global or family parameters depends on document type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


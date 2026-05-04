---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.GetFormula
source: html/4fb83945-2484-3709-6036-adfa4f411f28.htm
---
# Autodesk.Revit.DB.GlobalParameter.GetFormula Method

Returns the parameter's expression in form of a string.

## Syntax (C#)
```csharp
public string GetFormula()
```

## Returns
The string representing the expression assigned to the parameter.

## Remarks
Returns an empty string a case the parameter is not determined by
 a formula, or if the the expression cannot be converted to a string.


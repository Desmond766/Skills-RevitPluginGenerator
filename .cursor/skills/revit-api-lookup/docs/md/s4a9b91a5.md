---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.IsValidFormula(System.String)
source: html/50c83d89-22da-4398-bba8-197345f76192.htm
---
# Autodesk.Revit.DB.GlobalParameter.IsValidFormula Method

Tests that the given expression is a valid as formula for this parameter.

## Syntax (C#)
```csharp
public bool IsValidFormula(
	string expression
)
```

## Parameters
- **expression** (`System.String`)

## Remarks
Use this method to test validity of a formula before assigning it to a global
 parameter when in doubt whether it is an acceptable expression or not.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


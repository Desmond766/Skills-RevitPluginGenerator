---
kind: method
id: M:Autodesk.Revit.DB.ColorFillScheme.IsValidSchemeName(System.String)
source: html/ecae1c30-8417-dae7-8364-30f75145bb06.htm
---
# Autodesk.Revit.DB.ColorFillScheme.IsValidSchemeName Method

Checks whether the name is valid for new generated scheme.

## Syntax (C#)
```csharp
public bool IsValidSchemeName(
	string name
)
```

## Parameters
- **name** (`System.String`)

## Returns
Returns true if the name is valid for new generated scheme, false otherwise.

## Remarks
The name should not be empty, or all spaces, or include prohibited characters or duplicated with existing schemes.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


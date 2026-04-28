---
kind: method
id: M:Autodesk.Revit.DB.ColorFillScheme.Duplicate(System.String)
source: html/095596ae-d215-bf22-ccfa-fae85109d1a0.htm
---
# Autodesk.Revit.DB.ColorFillScheme.Duplicate Method

Generates a copy of current scheme.

## Syntax (C#)
```csharp
public ElementId Duplicate(
	string name
)
```

## Parameters
- **name** (`System.String`) - The desired name of copied scheme.

## Returns
The id of copied scheme.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The name is not valid for new generated scheme.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


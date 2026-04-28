---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetLayoutAsFixedNumber(System.Int32)
source: html/18bde367-36cd-ed5b-33cc-9d908158be4a.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetLayoutAsFixedNumber Method

Sets the Layout Rule property of rebar set to Fixed Number.

## Syntax (C#)
```csharp
public void SetLayoutAsFixedNumber(
	int numberOfBars
)
```

## Parameters
- **numberOfBars** (`System.Int32`) - The number of bars in set.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor doesn't contain a valid rebar reference.
 -or-
 This RebarFreeFormAccessor Rebar doesn't contain a valid server GUID.


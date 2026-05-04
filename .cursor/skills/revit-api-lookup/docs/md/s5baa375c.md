---
kind: method
id: M:Autodesk.Revit.DB.Architecture.MultistoryStairs.IsAcceptableForMultistoryStairs(Autodesk.Revit.DB.Architecture.Stairs)
source: html/bd5ebf3c-cccc-7b4e-518d-25655532b981.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs.IsAcceptableForMultistoryStairs Method

Checks if the given stairs can be used to create a multistory stairs.

## Syntax (C#)
```csharp
public static bool IsAcceptableForMultistoryStairs(
	Stairs stairs
)
```

## Parameters
- **stairs** (`Autodesk.Revit.DB.Architecture.Stairs`) - The given stairs to check.

## Returns
Returns true if the stairs can be used to create a multistory stairs; otherwise returns false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


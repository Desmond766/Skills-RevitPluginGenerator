---
kind: method
id: M:Autodesk.Revit.DB.Structure.LoadCase.IsNumberUnique(Autodesk.Revit.DB.Document,System.Int32)
source: html/94a4dd77-2d95-b9fb-f019-366634eb47e5.htm
---
# Autodesk.Revit.DB.Structure.LoadCase.IsNumberUnique Method

Checks that a given number is unique among all load cases.

## Syntax (C#)
```csharp
public static bool IsNumberUnique(
	Document document,
	int number
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`)
- **number** (`System.Int32`) - The number to check.

## Returns
True if the given number is unique among all load cases, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


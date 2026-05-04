---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelFor(Autodesk.Revit.DB.BuiltInCategory)
source: html/3c5057a7-b59e-c650-0d46-643f3bae218d.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelFor Method

Gets the user-visible name for a BuiltInCategory.

## Syntax (C#)
```csharp
public static string GetLabelFor(
	BuiltInCategory builtInCategory
)
```

## Parameters
- **builtInCategory** (`Autodesk.Revit.DB.BuiltInCategory`) - The BuiltInCategory to get the user-visible name.

## Remarks
The name is obtained in the current Revit language.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the builtin category is not valid.


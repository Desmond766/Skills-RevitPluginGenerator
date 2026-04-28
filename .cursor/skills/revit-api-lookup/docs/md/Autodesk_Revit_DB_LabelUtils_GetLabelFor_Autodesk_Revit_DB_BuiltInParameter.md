---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelFor(Autodesk.Revit.DB.BuiltInParameter)
source: html/ca0f955c-7cfa-e894-c0bc-dfa269aae5b4.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelFor Method

Gets the user-visible name for a BuiltInParameter.

## Syntax (C#)
```csharp
public static string GetLabelFor(
	BuiltInParameter builtInParam
)
```

## Parameters
- **builtInParam** (`Autodesk.Revit.DB.BuiltInParameter`) - The BuiltInParameter to get the user-visible name.

## Remarks
The name is obtained in the current Revit language.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the BuiltInParameter cannot be found.


---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelFor(Autodesk.Revit.DB.BuiltInParameter,Autodesk.Revit.ApplicationServices.LanguageType)
source: html/c38e7823-31b3-9bcd-5ab0-d353e0d39fa8.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelFor Method

Gets the user-visible name for a BuiltInParameter in a specific LanguageType.

## Syntax (C#)
```csharp
public static string GetLabelFor(
	BuiltInParameter builtInParam,
	LanguageType language
)
```

## Parameters
- **builtInParam** (`Autodesk.Revit.DB.BuiltInParameter`) - The BuiltInParameter to get the user-visible name.
- **language** (`Autodesk.Revit.ApplicationServices.LanguageType`) - The desired LanguageType to get the user-visible name in.

## Returns
The BuiltInParameter name in the desired LanguageType.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the BuiltInParameter cannot be found.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the desired LanguageType cannot be found for the BuiltInParameter name.


---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelForBuiltInParameter(Autodesk.Revit.DB.ForgeTypeId,Autodesk.Revit.ApplicationServices.LanguageType)
source: html/c823565b-b71f-cc64-597a-eed82de7106f.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelForBuiltInParameter Method

Gets the user-visible name for a built-in parameter in a specific LanguageType.

## Syntax (C#)
```csharp
public static string GetLabelForBuiltInParameter(
	ForgeTypeId parameterTypeId,
	LanguageType language
)
```

## Parameters
- **parameterTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the built-in parameter to get the user-visible name.
- **language** (`Autodesk.Revit.ApplicationServices.LanguageType`) - The desired LanguageType to get the user-visible name in.

## Returns
The built-in parameter name in the desired LanguageType.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the built-in parameter cannot be found.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the desired LanguageType cannot be found for the built-in parameter name.


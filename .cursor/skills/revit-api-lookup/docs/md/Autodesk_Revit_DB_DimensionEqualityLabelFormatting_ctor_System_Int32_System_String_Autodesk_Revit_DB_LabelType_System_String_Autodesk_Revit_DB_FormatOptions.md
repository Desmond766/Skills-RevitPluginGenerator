---
kind: method
id: M:Autodesk.Revit.DB.DimensionEqualityLabelFormatting.#ctor(System.Int32,System.String,Autodesk.Revit.DB.LabelType,System.String,Autodesk.Revit.DB.FormatOptions)
source: html/72dd9385-9284-9c79-ac98-bfc2da582a5c.htm
---
# Autodesk.Revit.DB.DimensionEqualityLabelFormatting.#ctor Method

Constructs a new instance of a DimensionEqualityLabelFormatting object with specified settings.

## Syntax (C#)
```csharp
public DimensionEqualityLabelFormatting(
	int leadingSpaces,
	string prefix,
	LabelType labelType,
	string suffix,
	FormatOptions formatOptions
)
```

## Parameters
- **leadingSpaces** (`System.Int32`) - The number of spaces to include before the parameter value.
- **prefix** (`System.String`) - The prefix to include before the parameter value.
- **labelType** (`Autodesk.Revit.DB.LabelType`) - The parameter value to be shown.
- **suffix** (`System.String`) - The suffix to include after the parameter value.
- **formatOptions** (`Autodesk.Revit.DB.FormatOptions`) - The format options to use for the parameter value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration


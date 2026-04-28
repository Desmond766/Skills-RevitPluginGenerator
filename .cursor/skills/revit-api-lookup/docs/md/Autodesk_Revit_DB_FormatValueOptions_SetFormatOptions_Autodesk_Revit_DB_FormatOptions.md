---
kind: method
id: M:Autodesk.Revit.DB.FormatValueOptions.SetFormatOptions(Autodesk.Revit.DB.FormatOptions)
source: html/982d355e-6526-5e25-ac7e-970f2a03542c.htm
---
# Autodesk.Revit.DB.FormatValueOptions.SetFormatOptions Method

Sets the FormatOptions to optionally override the default settings in the Units class.

## Syntax (C#)
```csharp
public void SetFormatOptions(
	FormatOptions formatOptions
)
```

## Parameters
- **formatOptions** (`Autodesk.Revit.DB.FormatOptions`) - The FormatOptions.

## Remarks
By default, the FormatOptions represents default formatting
 (UseDefault is true) and the FormatOptions in the Units class will
 be used.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


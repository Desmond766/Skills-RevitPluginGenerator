---
kind: method
id: M:Autodesk.Revit.DB.ValueParsingOptions.SetFormatOptions(Autodesk.Revit.DB.FormatOptions)
source: html/2c1e6657-7c6a-2cde-d7cb-c0d060b2d664.htm
---
# Autodesk.Revit.DB.ValueParsingOptions.SetFormatOptions Method

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


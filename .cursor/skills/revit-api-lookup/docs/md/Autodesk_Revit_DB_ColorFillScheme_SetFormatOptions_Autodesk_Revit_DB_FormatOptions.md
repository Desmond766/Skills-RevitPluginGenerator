---
kind: method
id: M:Autodesk.Revit.DB.ColorFillScheme.SetFormatOptions(Autodesk.Revit.DB.FormatOptions)
source: html/6558114a-4587-ff68-17a9-e58f0dfea0bb.htm
---
# Autodesk.Revit.DB.ColorFillScheme.SetFormatOptions Method

Sets the FormatOptions of the scheme.

## Syntax (C#)
```csharp
public void SetFormatOptions(
	FormatOptions formatOptions
)
```

## Parameters
- **formatOptions** (`Autodesk.Revit.DB.FormatOptions`)

## Remarks
This method will set the FormatOptions if the scheme is by range, otherwise do nothing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


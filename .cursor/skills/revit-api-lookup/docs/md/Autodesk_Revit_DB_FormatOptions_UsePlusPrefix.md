---
kind: property
id: P:Autodesk.Revit.DB.FormatOptions.UsePlusPrefix
source: html/e19d1060-709b-c81e-2068-646307ec0956.htm
---
# Autodesk.Revit.DB.FormatOptions.UsePlusPrefix Property

Indicates if a plus sign prefix should be displayed for positive and zero values.

## Syntax (C#)
```csharp
public bool UsePlusPrefix { get; set; }
```

## Remarks
This property is applicable to length display units (e.g.
 meters or feet). It is not currently supported for other unit
 types like area or force. The UI also does not permit it to be
 enabled in the Units class that represents the document's default
 settings, but that restriction is not enforced in the API. When UsePlusPrefix is true, a plus sign ("+") will be
 displayed before positive and zero values, just as a minus sign
 ("-") is displayed before negative values. For example, 1.234 will
 be displayed as +1.234 and 0.0 will be displayed as +0.0.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.
 -or-
 When setting this property: UsePlusPrefix was set to true but a plus prefix cannot be displayed for the display unit in this FormatOptions.


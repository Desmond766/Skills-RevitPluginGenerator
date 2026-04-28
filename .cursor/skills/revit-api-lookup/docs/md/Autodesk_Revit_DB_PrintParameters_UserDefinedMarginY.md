---
kind: property
id: P:Autodesk.Revit.DB.PrintParameters.UserDefinedMarginY
source: html/272124bf-aa6c-e46e-eb54-0ea012536cf9.htm
---
# Autodesk.Revit.DB.PrintParameters.UserDefinedMarginY Property

The User defined Y value of offset from left bottom corner. Unit is inch.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This property is obsolete. Use OriginOffsetY instead.")]
public double UserDefinedMarginY { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if PaperPlacement is not Margins and MarginType is not User defined type.


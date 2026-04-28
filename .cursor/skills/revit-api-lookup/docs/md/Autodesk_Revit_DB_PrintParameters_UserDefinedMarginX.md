---
kind: property
id: P:Autodesk.Revit.DB.PrintParameters.UserDefinedMarginX
source: html/6767fbd3-bddd-f1f7-79b9-7f8a2b3cfcfa.htm
---
# Autodesk.Revit.DB.PrintParameters.UserDefinedMarginX Property

The User defined X value of offset from left bottom corner. Unit is inch.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This property is obsolete. Use OriginOffsetX instead.")]
public double UserDefinedMarginX { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if PaperPlacement is not Margins and MarginType is not User defined type.


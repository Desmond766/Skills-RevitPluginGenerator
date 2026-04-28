---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.ErrorMessage
source: html/858682bf-3961-9f2b-c515-6b6178ca7f36.htm
---
# Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.ErrorMessage Property

The reason for calculation failure. If the calculation fails, this message will be shown in an error, or warning if we are editing the constraints.

## Syntax (C#)
```csharp
public string ErrorMessage { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: errorMessage is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null


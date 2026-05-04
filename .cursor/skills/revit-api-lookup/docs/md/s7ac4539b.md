---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.HasValidTypeForReporting
source: html/8ec3a25e-018b-8903-01d1-6201531c50a0.htm
---
# Autodesk.Revit.DB.GlobalParameter.HasValidTypeForReporting Method

Tests that the global parameter has data of a type that supports reporting.

## Syntax (C#)
```csharp
public bool HasValidTypeForReporting()
```

## Returns
True if the parameter has data of a type that supports reporting; False otherwise.

## Remarks
Only few data types can be used for reporting parmeters. Currently, reporting
 global parameters must be either of type Lenght or Angle -
 basically, they need to be value-driven by standard dimensions.


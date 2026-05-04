---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsStructuralAnalysisEnabled
source: html/d54d32a4-6d9f-ca47-1fee-4c6e95624c78.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsStructuralAnalysisEnabled Property

Checks whether or not the structural analysis is enabled, and enable or disable it.

## Syntax (C#)
```csharp
public bool IsStructuralAnalysisEnabled { get; set; }
```

## Remarks
When structural analysis is disabled the structural analytical model will not be updated
 automatically by Revit. Enabling structural analysis will not take effect unless the structure discipline is also enabled.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The current product type is not ProductType.Revit and discipline controls are not enabled.


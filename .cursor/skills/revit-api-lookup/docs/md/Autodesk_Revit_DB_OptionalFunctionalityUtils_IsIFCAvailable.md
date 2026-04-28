---
kind: method
id: M:Autodesk.Revit.DB.OptionalFunctionalityUtils.IsIFCAvailable
source: html/c1c011d3-b6e9-2a64-8c58-c7c386100aae.htm
---
# Autodesk.Revit.DB.OptionalFunctionalityUtils.IsIFCAvailable Method

Checks whether IFC functionality is available in the installed Revit.

## Syntax (C#)
```csharp
public static bool IsIFCAvailable()
```

## Returns
True if the IFC functionality is available in the installed Revit.

## Remarks
IFC Import/Export requires presence of certain modules that are optional and may not be part of the installed Revit.


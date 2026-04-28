---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CircuitNamingSchemeSettings.IsValidCircuitNamingSchemeId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/8bcc2aff-09a1-ab45-2c32-3624af0b877a.htm
---
# Autodesk.Revit.DB.Electrical.CircuitNamingSchemeSettings.IsValidCircuitNamingSchemeId Method

Verifies that the circuit naming scheme id can be used with CircuitNamingSchemeSettings.

## Syntax (C#)
```csharp
public static bool IsValidCircuitNamingSchemeId(
	Document aDocument,
	ElementId circuitNamingSchemeId
)
```

## Parameters
- **aDocument** (`Autodesk.Revit.DB.Document`) - The document.
- **circuitNamingSchemeId** (`Autodesk.Revit.DB.ElementId`) - The circuit naming scheme id to be checked.

## Returns
True if the circuit naming scheme id is valid for CircuitNamingSchemeSettings.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalEquipment.IsValidCircuitNamingSchemeId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/5e9b1aa8-5d07-fc8d-5cf1-40fac9a57914.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalEquipment.IsValidCircuitNamingSchemeId Method

Verifies that the circuit naming scheme id can be used with Electrical Equipment.

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
True if the circuit naming scheme id is valid for Electrical Equipment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null


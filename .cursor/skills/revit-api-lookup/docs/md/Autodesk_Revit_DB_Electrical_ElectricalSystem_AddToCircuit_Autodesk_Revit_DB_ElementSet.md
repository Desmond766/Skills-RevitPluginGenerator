---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSystem.AddToCircuit(Autodesk.Revit.DB.ElementSet)
source: html/88440699-56ba-439b-48ec-6741b620df6f.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.AddToCircuit Method

Add a set of exist components to the Electrical System.

## Syntax (C#)
```csharp
public bool AddToCircuit(
	ElementSet components
)
```

## Parameters
- **components** (`Autodesk.Revit.DB.ElementSet`) - The components added to the electrical system.

## Returns
If successful, all the components will add to the system. Otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) is returned.

## Remarks
This method will only function with the 
 Autodesk Revit MEP application.


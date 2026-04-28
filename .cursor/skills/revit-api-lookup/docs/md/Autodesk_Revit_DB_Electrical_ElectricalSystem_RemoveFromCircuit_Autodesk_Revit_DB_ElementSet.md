---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSystem.RemoveFromCircuit(Autodesk.Revit.DB.ElementSet)
source: html/46a00712-3b2f-f84d-e061-d31a38ce8b78.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.RemoveFromCircuit Method

remove a set of exist components from the Electrical System.

## Syntax (C#)
```csharp
public void RemoveFromCircuit(
	ElementSet components
)
```

## Parameters
- **components** (`Autodesk.Revit.DB.ElementSet`) - The components removed from the electrical system.

## Remarks
If successful, all the components will remove from the system. Otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) is removed.
This method will only function with the Autodesk Revit MEP application.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the components parameter Value is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the components cannot be removed from the system.


---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSystem.SelectPanel(Autodesk.Revit.DB.FamilyInstance)
source: html/008dafa1-ca02-d3fb-6bb8-0b0ac7fadcbc.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.SelectPanel Method

Set the panel for the Electrical System.

## Syntax (C#)
```csharp
public void SelectPanel(
	FamilyInstance panel
)
```

## Parameters
- **panel** (`Autodesk.Revit.DB.FamilyInstance`) - The panel of the electrical system.

## Remarks
If successful, the panel will be set for the system. Otherwise the exception will be thrown.
 This method will only function with the Autodesk Revit MEP application.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The panel does not have enough slots and Feed Through Lugs is unchecked or already in use.
 -or-
 Thrown when the panel cannot be set for the electrical system.


---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSystem.DisconnectPanel
source: html/af36bfe7-48ac-c38f-dac2-5682228f8037.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.DisconnectPanel Method

Disconnect the panel for the Electrical System.

## Syntax (C#)
```csharp
public void DisconnectPanel()
```

## Remarks
If successful, the system will disconnect this panel. Otherwise the exception will be thrown.
 This method will only function with the Autodesk Revit MEP application.

## Exceptions
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the panel cannot be disconnected for the electrical system.


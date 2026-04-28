---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSystem.NewWires(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Electrical.WiringType)
source: html/e4aeb633-5e67-955f-dde6-6c5f36cd0edc.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.NewWires Method

Create a bunch of wires for the electrical system.

## Syntax (C#)
```csharp
public WireSet NewWires(
	View view,
	WiringType wiringType
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the wire is to be visible.
- **wiringType** (`Autodesk.Revit.DB.Electrical.WiringType`) - Specify the wiring type (Arc or Chamfer) that is to be applied to all newly created wires.

## Returns
New created wires

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This method can only be used to create a bunch of wires according to specific pairs of elements,
so if there exists a Nothing nullptr a null reference ( Nothing in Visual Basic) element in any pair of familyInstancePairs, the exception will be thrown.

